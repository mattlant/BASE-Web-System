using System;
using System.Data;
using System.Configuration;
using System.Security;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using BASE.Security;
using BASE.Web.Security;


namespace BASE.Web.Security
{

	public class BASEAuthenticationModule : IBASEHttpModule
	{

		public void Dispose()
		{
			Logging.Logger.Log("BASEAuthenticationModule Dispose()", BASE.Logging.LogPriority.Debug, "AUTHENTICATION");
		}

		public void Init(System.Web.HttpApplication app)
		{
			Logging.Logger.Log("BASEAuthenticationModule Dispose()", BASE.Logging.LogPriority.Debug, "AUTHENTICATION");
			app.AuthenticateRequest += new EventHandler(OnEnter);
			app.PostAuthenticateRequest += new EventHandler(app_PostAuthenticateRequest);
		}

		void app_PostAuthenticateRequest(object sender, EventArgs e)
		{
			Logging.Logger.Log("BASEAuthenticationModule app_PostAuthenticateRequest()", BASE.Logging.LogPriority.Debug, "AUTHENTICATION");
		}

		void OnEnter(object sender, EventArgs e)
		{
			//Logging.Logger.Log("BASEAuthenticationModule app_AuthenticateRequest()", BASE.Logging.LogPriority.Debug, "AUTHENTICATION");

			//HttpApplication application = (HttpApplication)sender;
			//HttpContext context = application.Context;
			//BASEAuthenticationTicket ticket = null;

			//System.Diagnostics.Debug.WriteLine("app_AuthenticateRequest");
			////Check cookie

			//HttpCookie cookie = context.Request.Cookies[BASEAuthentication.authcookiename];
			//if (cookie == null)
			//{
			//    //The cookie has been compromised
			//    context.Response.Cookies.Remove(BASEAuthentication.authcookiename);
			//    context.User = BASEAuthentication.GetAnonymousPrinciple();
			//    return;
			//}

			////Is Valid?
			//if (BASEAuthentication.IsCookieCompromised(cookie))
			//{
			//    //The cookie has been compromised
			//    context.Response.Cookies.Remove(BASEAuthentication.authcookiename);
			//    context.User = BASEAuthentication.GetAnonymousPrinciple();
			//    return;
			//}

			////Get Ticket
			//try
			//{

			//    ticket = BASEAuthentication.DecryptFromBase64(cookie.Values["enc"]);
			//}
			//catch (Exception ex)
			//{
			//    context.Response.Cookies.Remove(BASEAuthentication.authcookiename);
			//    context.User = BASEAuthentication.GetAnonymousPrinciple();
			//    System.Diagnostics.Debug.WriteLine("Ticket had an exception: " + ex.ToString());
			//    return;
			//}


			////
			////TODO: Check ticket for tampering

			////Is Valid and not Expired
			//if (!ticket.IsValid())
			//{
			//    //The ticket is not valid
			//    context.Response.Cookies.Remove(BASEAuthentication.authcookiename);
			//    context.User = BASEAuthentication.GetAnonymousPrinciple();
			//    return;
			//}


			////TODO: Validate SiteUID's, etc
			
			////TODO: Do sliding expiry and Persistance

			////If valid, set IPrincipal

			//UserIdentityToken token = UserIdentityToken.CreateTokenNoSecCheck(ticket.UserGuid);
			//BASEPrinciple principle = new BASEPrinciple(token);
			//context.User = principle;

			////Set cookie again.
			//context.Response.SetCookie(cookie);


		}


	}
}
