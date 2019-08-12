using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.SessionState;

using BASE.Security;

namespace BASE.Web.SessionState
{
	public static class SessionManager
	{
		/// <summary>
		/// Adds an Item to the current SessionState
		/// </summary>
		/// <param name="objName">The string key name of the object</param>
		/// <param name="objToAdd">The object to add</param>
		public static void Add(string objName, object objToAdd)
		{
			HttpContext.Current.Session.Add(objName, objToAdd);
		}

		/// <summary>
		/// Gets the object in the SessionState 
		/// </summary>
		/// <param name="objName">The string key name of the object to retreive</param>
		/// <returns>Returns the object defined by the string key passed in. If the key does not exist, this will return null.</returns>
		public static object Get(string objName)
		{
			return HttpContext.Current.Session[objName];
		}

		/// <summary>
		/// Gets a reference to the current session
		/// </summary>
		public static HttpSessionState CurrentSession
		{
			get { return HttpContext.Current.Session; }
		}


		internal static void AddUserToken(UserIdentityToken usertoken)
		{
			Add(SessionKeys.UserToken, usertoken);
		}

		public static UserIdentityToken GetUserToken()
		{
			//Get context ready
			HttpContext context = HttpContext.Current;

			//Try first gettoing token from session state. May not exist if user logged in in a previous session.
			UserIdentityToken token = (UserIdentityToken)Get(SessionKeys.UserToken);
			if (token == null)
			{
				//get again from DB
				BASE.Logging.Logger.Log("Getting UserToken from DB at SessionManager.GetUserToken()", BASE.Logging.LogPriority.Debug, "SESSIONSTATE");
				if (context.User == null || !context.User.Identity.IsAuthenticated)
				{
					//Anonymous user, so load anonymous usertoken.
					token = UserIdentityToken.CreateAnonymousToken(SystemManager.Current.AnonymousGuid);
				}
				else
				{
					//Authenticated user, load the token.
					token = UserIdentityToken.CreateTokenNoSecCheck(new Guid(context.User.Identity.Name));
				}

				if(token.IsValidToken)
					AddUserToken(token);
				else
					throw new BASEGenericException("Invalid Token");

			}

			//TODO: Add extra checking/security
			return token;

		}

		internal static void RemoveUserToken()
		{
			CurrentSession.Remove(SessionKeys.UserToken);
		}


	}
}
