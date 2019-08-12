using System;
using System.Collections.Generic;
using System.Text;

using BASE.Data.LLDAL.EntityClasses;
using BASE.Data.LLDAL.HelperClasses;
using BASE.Data.LLDAL.DatabaseSpecific;

using SD.LLBLGen.Pro.ORMSupportClasses;


//TODO: CreateUser, DeleteUser, UpdateUser

namespace BASE.Security
{
	public static class UserManager
	{
		public static UserEntity CreateUser(string username, string password, bool canExpire, DateTime expireDate, bool IsDisabled, bool isSystemAdmin, string email)
		{
			UserEntity l_user = new UserEntity();

			l_user.UserName = username;
			l_user.UserNameLower = username.ToLower();
			l_user.Password = password;
			l_user.CanExpire = canExpire;
			l_user.ExpiryDate = expireDate;
			l_user.IsDisabled = IsDisabled;
			l_user.IsSystemAdmin = isSystemAdmin;
			l_user.EmailAddress = email;
			l_user.LastLogin = DateTime.MinValue;

			DataAccessAdapter da = new DataAccessAdapter();


			return da.SaveEntity(l_user) ? l_user : null;
		}




		public static bool Exists(string username, int siteUID)
		{
			//TODO: Make this a QUICK and lightweight check
			if (GetUser(username.ToLower(), siteUID) != null)
				return true;
			return false;
		}

		public static UserEntity GetUser(string username, int siteUID)
		{
			UserEntity l_user = new UserEntity();
			l_user.UserNameLower = username.ToLower();
			l_user.SiteUID = siteUID;

			// Get the user
			DataAccessAdapterBase da = new DataAccessAdapter();
			if (!da.FetchEntityUsingUniqueConstraint(l_user, l_user.ConstructFilterForUCSiteUIDUserNameLower())) //TOLOWER
				return null; //We dont have a valid user with that username;
			else
				return l_user;
		}

		public static EntityCollection<UserEntity> GetUsers()
		{
			EntityCollection<UserEntity> l_users = new EntityCollection<UserEntity>();

			DataAccessAdapterBase da = new DataAccessAdapter();

			da.FetchEntityCollection(l_users, null);

			return l_users;
		}

		public static bool SetLastLogin(UserEntity user, DateTime loginDateTime)
		{
			//TODO: Change to use simple update, rather than loading entity, just update the date based on ID
			user.LastLogin = loginDateTime;
			//TODO, CALL A STORED PROC!
			DataAccessAdapterBase da = new DataAccessAdapter();
			return da.SaveEntity(user);
		}

		public static bool SetLastLogin(UserEntity user)
		{
			return SetLastLogin(user, DateTime.Now);
		}

	}
}
