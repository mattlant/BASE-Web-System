using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Principal;

using SD.LLBLGen.Pro.ORMSupportClasses;

using BASE.Web;
using BASE.Web.SessionState;
using BASE.Security;
using BASE.Data;
using BASE.Data.LLDAL.EntityClasses;
using BASE.Data.LLDAL.DatabaseSpecific;
using BASE.Data.LLDAL.HelperClasses;
using BASE.Data.LLDAL.DatabaseSpecific;


namespace BASE.Security
{
	[Serializable]
	public class UserIdentityToken : IIdentity
	{
		public static readonly string AnonUserName = "Anonymous";
		private bool _isAnonymous = true;
		private string _authType = "BASEAuthentication";
		private bool _isAuthenticated;

		bool _wasAddedToSession = false;
		List<int> _inGroups;

		Dictionary<Guid, Dictionary<string, bool>> _entityTypeEffPerms;
		Dictionary<Guid, Dictionary<string, bool>> _customEffPerms;

		private string _userName = "InvalidUserDoNotUse";
		private int _uid;
		private Guid _guid;
		private bool _canExpire = true;
		private DateTime _expiryDate = DateTime.MinValue;
		private bool _isDisabled = true;
		private bool _isSystemAdmin = false;
		private int _siteUID = -1;

		/// <summary>
		/// Static method to Create a user token using the supplied username and password. A valid token will only be provided if the username and password are valid and the account is not disabled nor expired.
		/// </summary>
		/// <param name="username"></param>
		/// <param name="password"></param>
		/// <returns></returns>
		public static UserIdentityToken CreateToken(string username, string password, int? siteUID, bool addToSession) //TODO: do not use session. Token will be stored in Context.User
		{
			UserEntity l_user = new UserEntity();
			l_user.UserNameLower = username.ToLower();
			l_user.SiteUID = siteUID;

			// Get the user
			DataAccessAdapter da = new DataAccessAdapter();
			bool didFetch = da.FetchEntityUsingUniqueConstraint(l_user, l_user.ConstructFilterForUCSiteUIDUserNameLower());
			if (!didFetch || l_user.IsNew)
				return null; //We dont have a valid user with that username;


			//Check password
			//TODO: Add hashing.
			if (l_user.Password != password)
				return null;

			UserIdentityToken l_usertoken = new UserIdentityToken(l_user);

			if (addToSession)
			{
				//Set WasAdd4edToSession with internal property method
				SessionManager.AddUserToken(l_usertoken);
			}

			return l_usertoken;

			//TODO: Add logging and auditing support
			//DONE*TODO: Add in effective entitytype perms and custom perms
			//TODO: Add in GroupList.
			//TODO: Need to change the UC's for users. Based on GUID, or Site/Username and be able to create tokens based on any of them.
			//TODO: Wee will need to add caching of some Sort. We cannot have it do round trips to database for every time a request is made.

		}		
		
		/// <summary>
		/// Static method to Create a user token using the supplied username and password. A valid token will only be provided if the username and password are valid and the account is not disabled nor expired.
		/// </summary>
		/// <param name="userGuid"></param>
		/// <returns></returns>
		internal static UserIdentityToken CreateTokenNoSecCheck(Guid userGuid) //TODO: do not use session. Token will be stored in Context.User
		{
			UserEntity l_user = new UserEntity();
			l_user.GUID = userGuid;

			// Get the user
			DataAccessAdapter da = new DataAccessAdapter();
			bool didFetch = da.FetchEntityUsingUniqueConstraint(l_user, l_user.ConstructFilterForUCGUID());
			if (!didFetch || l_user.IsNew)
				return null; //We dont have a valid user with that username;
			
			//UserManager.SetLastLogin(l_user);

			UserIdentityToken l_usertoken = new UserIdentityToken(l_user);

			return l_usertoken;

		}

		public static UserIdentityToken CreateAnonymousToken(Guid anonGuid)
		{
			UserEntity l_user = new UserEntity();
			l_user.GUID = anonGuid;
				
			// Get the user
			DataAccessAdapter da = new DataAccessAdapter();
			bool didFetch = da.FetchEntityUsingUniqueConstraint(l_user, l_user.ConstructFilterForUCGUID());
			if(!didFetch || l_user.IsNew)
				return null; //We dont have a valid user with that guid;

			UserIdentityToken l_usertoken = new UserIdentityToken(l_user);

			l_usertoken._isAnonymous = true;

			return l_usertoken;

		}

		public static UserIdentityToken CreateToken(string username, string password, int? siteUID)
		{
			return CreateToken(username, password, siteUID, true);
		}

		private UserIdentityToken(UserEntity user)
		{
			//Verify user [assed is valid
			//TODO: Add more validation checks.
			if (user == null)
				throw new ArgumentNullException("user", "paramater cannot be null.");
			if (user.IsNew)
				throw new ArgumentException("user", "User is not valid. Cannot pass a new user for token creation.");

			_guid = user.GUID;
			_uid = user.UID;
			_userName = user.UserName;
			_canExpire = user.CanExpire;
			_expiryDate = user.ExpiryDate.HasValue ? user.ExpiryDate.Value : DateTime.MinValue;
			_isDisabled = user.IsDisabled;
			_isSystemAdmin = user.IsSystemAdmin;
			_siteUID = user.SiteUID.HasValue ? user.SiteUID.Value : 0;

			//Internaly used GUID

			_inGroups = GroupManager.GetGroupMembershipAsUIDList(user.UID);
			_entityTypeEffPerms = SecurityManager.GetEffectiveEntityTypePermissions(user.UID, _inGroups);
			_customEffPerms = SecurityManager.GetEffectiveCustomPermissions(user.UID, _inGroups);



		}

		public void Destroy()
		{
			//TODO: Add FormsAuth.Sighout stuff as well as remove from the session if required.
		}


		//public static EntityCollection<PermissionEntity> GetPermissions(Guid accessToGUID)
		//{


		//}


		public bool IsValidToken
		{
			get
			{
				return !IsExpired && !IsDisabled;
			}
		}

		public bool IsExpired
		{
			get
			{
				if (_canExpire)
				{
					return _expiryDate < DateTime.Now;
				}
				else
					return false;
			}
		}

		public bool IsDisabled
		{
			get
			{
				return _isDisabled;
			}
		}

		public bool IsSystemAdmin
		{
			get
			{
				return IsValidToken && _isSystemAdmin;
			}
		}

		public bool IsAnonymous
		{
			get
			{
				return _isAnonymous;
			}
		}

		public Guid GUID
		{
			get
			{
				return _guid;
			}
		}

		public int SiteUID
		{
			get
			{
				return _siteUID;
			}
		}

		public int UID
		{
			get
			{
				return _uid;
			}
		}

		public bool HasAssociatedSite
		{
			get { return _siteUID > 0; }
		}

		public bool IsAllowedActionOnEntityType(string actionCode, Guid entityTypeGUID)
		{
			if (_isSystemAdmin)
				return true;

			if (!_entityTypeEffPerms.ContainsKey(entityTypeGUID))
				return false;
			Dictionary<string, bool> ePerms = _entityTypeEffPerms[entityTypeGUID];
			if (!ePerms.ContainsKey(actionCode))
				return false;
			return ePerms[actionCode];
		}

		public bool IsAllowedActionOnCustom(string actionCode, Guid customPermGUID)
		{
			if (_isSystemAdmin)
				return true;

			if (!_customEffPerms.ContainsKey(customPermGUID))
				return false;
			Dictionary<string, bool> cPerms = _customEffPerms[customPermGUID];
			if (!cPerms.ContainsKey(actionCode))
				return false;
			return cPerms[actionCode];
		}

		public bool IsAllowedActionOnEntity(string actionCode, EntityTypeGUIDRecordUIDPair entityTypeUID)
		{
			if (_isSystemAdmin)
				return true;

			int allow = 0;
			int retVal = ActionProcedures.CanUserExecActionOnEntity(entityTypeUID.EntityTypeGUID, entityTypeUID.RecordUID, _uid, actionCode, ref allow);

			if (allow == 1)
				return true;

			//TODO, Make this a global settable flag.
			bool NotSetWillAllow = true;

			//If the value returned is not set, we chekc the gloabl flag to find out if user is allowed or not
			if (allow == -1)
			{
				if (NotSetWillAllow)
					return true;
				else
					return false;
			}

			return false;

		}


		#region IIdentity Members

		public string AuthenticationType
		{
			get { return _authType; }
		}

		public bool IsAuthenticated
		{
			get { return !_isAnonymous; }
		}

		public string Name
		{
			get { return _userName; }
		}

		#endregion
	}
}
