using System;
using System.Data;
using System.Configuration;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using BASE.Security;
using BASE.Web.SessionState;

namespace BASE.Web.Security
{
	public static class BASEAuthentication
	{

		public static readonly string authcookiename = ".baseauth";

		//public static string EncryptToBase64(BASEAuthenticationTicket ticket)
		//{
		//    //Hash ticket.
		//    string ticketString = ticket.ToString();
		//    //string hash = BASEEncryption.GetBase64Hash(ticketString, Salt);

		//    ////Combine Hash and ticket
		//    //string tickethash = ticketString + "*" + hash;

		//    //Encrypt combination
		//    string encB64 = BASEEncryption.EncryptToBase64(ticketString);


		//    //retun base64 result
		//    return encB64;
		//}

		//public static BASEAuthenticationTicket DecryptFromBase64(string encB64)
		//{
		//    string ticket = BASEEncryption.DecryptToString(encB64);
		//    return new BASEAuthenticationTicket(ticket);	
		//}

		//public static HttpCookie CreateCookie(string name, BASEAuthenticationTicket ticket)
		//{
		//    HttpCookie cookie = new HttpCookie(name);
		//    string enc = EncryptToBase64(ticket);
		//    string hash = BASEEncryption.GetBase64Hash(enc, SystemManager.Current._salt);
		//    cookie.Values["enc"] = enc;
		//    cookie.Values["hash"] = hash;

		//    return cookie;
		//}

		//public static bool IsCookieCompromised(HttpCookie authCookie)
		//{
		//    string enc = authCookie.Values["enc"];
		//    string hash = authCookie.Values["hash"];

		//    return BASEEncryption.VerifyHash(enc, SystemManager.Current._salt, hash);
		//}

		//public static IPrincipal GetAnonymousPrinciple()
		//{
		//    Guid anonGuid = SystemManager.Current.AnonymousGuid;

		//    UserIdentityToken token = UserIdentityToken.CreateAnonymousToken(anonGuid);

		//    BASEPrinciple principle = new BASEPrinciple(token);
		//    return principle;

		//}

		/// <summary>
		/// Returns a value indicationg if the Current Context's Principle is anonymous.
		/// </summary>
		/// <returns></returns>
		public static bool IsPrincipleAnonymous
		{
			get
			{
				return !HttpContext.Current.User.Identity.IsAuthenticated;
				//UserIdentityToken ident = (UserIdentityToken)HttpContext.Current.User.Identity;
				//return ident.IsAnonymous;
			}
		}

		public static void SetAuthCookie(int siteUID, Guid userGuid, bool isPersistant)
		{

			//BASEApplication app = (BASEApplication)HttpContext.Current.ApplicationInstance;
			////TODO: get GUID from Username
			//BASEAuthenticationTicket ticket = new BASEAuthenticationTicket(siteUID, userGuid, 1, DateTime.Now, DateTime.Now.AddHours(1), isPersistant, string.Empty);
			//HttpContext.Current.Response.Cookies.Add(CreateCookie(BASEAuthentication.authcookiename, ticket));

		}

		public static BASEAuthenticationResult AuthenticateUserAndSetToken(string username, string password, int? siteUID)
		{
			UserIdentityToken token = null;

			try
			{

				token = UserIdentityToken.CreateToken(username, password, siteUID);

				if (token == null)
				{
					return BASEAuthenticationResult.InvalidUsernameOrPassword;
				}
				else if (token.IsExpired)
				{
					return BASEAuthenticationResult.Expired;
				}
				else if (token.IsDisabled)
				{
					return BASEAuthenticationResult.Disabled;
				}
				else if (!token.IsValidToken)
				{
					return BASEAuthenticationResult.NotValid;
				}

				BASE.Web.SessionState.SessionManager.AddUserToken(token);

				return BASEAuthenticationResult.Success;


			}
			catch (Exception ex)
			{
#if DEBUG
				throw;
#else
				return BASEAuthenticationResult.ExceptionCaught;
#endif
			}

		}
		public static BASEAuthenticationResult AuthenticateUserAndSetTokenAndRedirectOnSuccess(string username, string password, int? siteUID)
		{
			BASEAuthenticationResult result = AuthenticateUserAndSetToken(username, password, siteUID);
			if (result == BASEAuthenticationResult.Success)
			{
				FormsAuthentication.SetAuthCookie(SessionManager.GetUserToken().GUID.ToString(), true);
				HttpContext.Current.Response.Redirect(HttpContext.Current.Request.QueryString["ReturnUrl"]);
				return result;
			}
			else
			{
				return result;
			}
		}

		
	}

	public enum BASEAuthenticationResult
	{
		Success = 1,
		InvalidUsernameOrPassword,
		Expired,
		Disabled,
		NotValid,
		ExceptionCaught
	}

}
