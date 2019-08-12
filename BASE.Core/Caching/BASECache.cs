using System;
using System.Collections.Generic;
using System.Text;

namespace BASE.Caching
{
	/// <summary>
	/// A Generic Cache Store supporting expiration times in minutes or explicit, also with sliding expiry support.
	/// </summary>
	/// <typeparam name="TKey">The key type</typeparam>
	/// <typeparam name="T">The Value type</typeparam>
	/// <remarks>The cache is thread safe, so it can be shared among multiple threads.</remarks>
	public class BASECache<TKey, T>
	{
		Dictionary<TKey, BASECacheItem<T>> _cacheStore;
		Object _cacheLock = new Object();
		/// <summary>
		/// Initializes a new empty cache.
		/// </summary>
		public BASECache()
		{
			_cacheStore = new Dictionary<TKey, BASECacheItem<T>>();
		}

		/// <summary>
		/// Adds a new item to the cache with the given key, expiring in the given amount of minutes, unless sliding expiry is activated.
		/// </summary>
		/// <param name="key">The cache key for the item.</param>
		/// <param name="item">The item to store.</param>
		/// <param name="expiryInMinutes">Expiry duration in minutes.</param>
		/// <param name="isSliding">If true, the expiry time will continue to be reset to its initial duration every time the item is accessed.</param>
		public void Add(TKey key, T item, int expiryInMinutes, bool isSliding)
		{
			lock (_cacheLock)
			{
				_cacheStore.Add(key, new BASECacheItem<T>(item, expiryInMinutes, isSliding));
			}
		}

		/// <summary>
		/// Adds a new item to the cache with the given key, expiring in the given amount of minutes.
		/// </summary>
		/// <param name="key">The cache key for the item.</param>
		/// <param name="item">The item to store.</param>
		/// <param name="expiryInMinutes">Expiry duration in minutes.</param>
		public void Add(TKey key, T item, int expiryInMinutes)
		{
			lock (_cacheLock)
			{
				_cacheStore.Add(key, new BASECacheItem<T>(item, expiryInMinutes));
			}
		}

		/// <summary>
		/// Adds a new item to the cache with the given key, expiring at the exact time given.
		/// </summary>
		/// <param name="key">The cache key for the item.</param>
		/// <param name="item">The item to store.</param>
		/// <param name="expiryTime">The exact time for this item to expire at.</param>
		public void Add(TKey key, T item, DateTime expiryTime)
		{
			lock (_cacheLock)
			{
				_cacheStore.Add(key, new BASECacheItem<T>(item, expiryTime));
			}
		}

		/// <summary>
		/// Adds a new item to the cache with the given key.
		/// </summary>
		/// <param name="key">The cache key for the item.</param>
		/// <param name="item">The item to store.</param>
		/// <remarks>This version of Add does not set an expiry for the item. the item will stay in the cache indefinitely.</remarks>
		public void Add(TKey key, T item)
		{
			lock (_cacheLock)
			{
				_cacheStore.Add(key, new BASECacheItem<T>(item));
			}
		}



		public T this[TKey key]
		{
			get
			{
				//If not in dictionary, return null
				if (!_cacheStore.ContainsKey(key))
					return default(T);
				//get the item
				BASECacheItem<T> item = _cacheStore[key];
				//MAYBE LOCK ITEM???
				//Check if item has expiry, if not return the item
				if (!item._hasExpiry)
					return item.Item;

				//Check if it is expired
				if (item.IsExpired)
				{
					//Its expired, remove item from store and return null;
					lock (this._cacheLock)
					{
						_cacheStore.Remove(key);
					}
					return default(T);
				}

				//Its a sliding item, update the expiry since its been accessed.
				if (item.ExpiryMinutes > 0 && item._isSliding)
					item._expiry = DateTime.Now.AddMinutes(item._expiryInMinutes);

				return item.Item;
				

			}
			set
			{
				//We are setting it, so just add a new item at that key location. No expiry since its added with indexer.
				lock (this._cacheStore)
				{
					_cacheStore.Add(key, new BASECacheItem<T>(value));
				}
			}
		}



	}

	internal class BASECacheItem<T>
	{
		internal DateTime _expiry = DateTime.MaxValue;
		internal int _expiryInMinutes = 0;
		internal T _item;
		internal bool _isSliding = false;
		internal bool _hasExpiry = false;

		internal BASECacheItem(T item, DateTime expiryTime, int expiryInMinutes, bool isSliding)
		{
			//Both cannot be set either
			if (expiryTime != DateTime.MaxValue && expiryInMinutes > 0)
				throw new ArgumentException("expiryTime AND ExpiryInMinutes cannot be set at the same time");
			if (item == null)
				throw new ArgumentNullException("CacheItem cannot be null", "item");

			_item = item;
			_isSliding = isSliding;
			_expiryInMinutes = expiryInMinutes;

			if (expiryTime == DateTime.MaxValue && expiryInMinutes < 1) //No expiry
			{
				_hasExpiry = false;
			}
			else if (expiryInMinutes > 0)   //timespan expiry
			{
				_expiry = DateTime.Now.AddMinutes(_expiryInMinutes);
				_hasExpiry = true;
			}
			else   //explicit expiry
			{
				//Explicit time cannot be used in a sliding scenario
				if (isSliding)
					throw new ArgumentException("expiryTime cannot be used with Sliding expiry", "expiryTime");
				_expiry = DateTime.Now.AddMinutes(_expiryInMinutes);
				_hasExpiry = true;
			} 
			


		}

		public BASECacheItem(T item, int expiryInMinutes, bool issliding)
			: this(item, DateTime.MaxValue, expiryInMinutes, issliding)
		{ }

		public BASECacheItem(T item, DateTime expiry)
			: this(item, expiry, 0, false)
		{ }

		public BASECacheItem(T item, int expiryInMinutes)
			: this(item, DateTime.MaxValue, expiryInMinutes, false)
		{ }

		public BASECacheItem(T item)
			: this(item, DateTime.MaxValue, 0, false)
		{ }

		public bool HasExpiry
		{
			get { return _hasExpiry; }
		}

		public DateTime ExpiryTime
		{
			get { return _expiry; }
		}

		public int ExpiryMinutes
		{
			get { return _isSliding ? (_expiry - DateTime.Now).Minutes : _expiryInMinutes; }
		}

		public bool IsSliding
		{
			get { return _isSliding; }
		}

		public T Item
		{
			get
			{
				return _item;
			}
		}

		public bool IsExpired
		{
			get
			{
				return _hasExpiry && (_expiry <= DateTime.Now);
			}
		}


	}
}
