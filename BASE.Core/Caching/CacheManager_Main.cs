using System;
using System.Collections.Generic;
using System.Text;

using BASE.Data;

namespace BASE.Caching
{
	public partial class CacheManager
	{
		private static CacheManager _current;

		public static CacheManager Current
		{ get { return _current; } }

		private CacheManager()
		{
		}
		internal void Init()
		{
			//make sure there is no cache manager yet. If so, this is an invalid call
			if (_current != null)
				throw new InvalidOperationException("CacheManager already exisists");

			_current = new CacheManager();
		}

	}

}
