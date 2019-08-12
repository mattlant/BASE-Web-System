using System;
using System.Collections.Generic;
using System.Text;

using System.Web;

namespace BASE.Web.Security
{
	public class BASEAuthorizationModule : IBASEHttpModule
	{

		public void Dispose()
		{
			Logging.Logger.Log("BASEAuthorizationModule Dispose()", BASE.Logging.LogPriority.Debug, "AUTHORIZATION");
		}

		public void Init(HttpApplication app)
		{
			Logging.Logger.Log("BASEAuthorizationModule Init()", BASE.Logging.LogPriority.Debug, "AUTHORIZATION");
			app.AuthorizeRequest += new EventHandler(OnEnter);
			app.PostAuthorizeRequest += new EventHandler(app_PostAuthorizeRequest);
		}

		void app_PostAuthorizeRequest(object sender, EventArgs e)
		{
			Logging.Logger.Log("BASEAuthorizationModule app_PostAuthorizeRequest()", BASE.Logging.LogPriority.Debug, "AUTHORIZATION");
		}

		void OnEnter(object sender, EventArgs e)
		{
			HttpApplication application = (HttpApplication)sender;
			HttpContext context = application.Context;

			Logging.Logger.Log("BASEAuthorizationModule OnEnter()", BASE.Logging.LogPriority.Debug, "AUTHORIZATION");

			if (BASEAuthorization.CurrentRequestAllowsAnonymous())
			{
				//return
			}
			else
			{
				//Is Principle Set and valid?
				if (!context.User.Identity.IsAuthenticated)
				{
					//Set 401 Http Code
					context.Response.StatusCode = 401;
				}

				//otherwise check security
				return;
			}
		}


	}
}
