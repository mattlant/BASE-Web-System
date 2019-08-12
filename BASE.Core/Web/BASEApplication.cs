using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Security;
using System.Security.Principal;
using BASE.Security;
using BASE.Web.Security;
using BASE.Logging;
using BASE.Logging.LogTypes;
using System.Threading;

namespace BASE.Web
{
	/// <summary>
	/// BASEApplication inherits from HttpApplication so it can hook into its exposed events.
	/// This class also will hold Request specific data.
	/// </summary>
	public class BASEApplication : HttpApplication
	{

		public static readonly string LogCatSystem = "SYSTEM";
		protected BASERequest _baseRequest = new BASERequest();

		public override void Init()
		{
			//TESTING ONLY
			Logging.Logger.Log("before BASEApplication.Init()");
			base.Init();
			Logging.Logger.Log("after BASEApplication.Init()");
			//this.Request.
		}

        /// <summary>
        /// This method get called when the Whole application start.
        /// </summary>
        /// <param name="sender">The Object that did call this method.</param>
        /// <param name="e">Event Arguments passed to the method.</param>
		protected void Application_Start(object sender, EventArgs e)
		{


#if DEBUG
            // Logging the internal information about this request.
			Logger.Loggers.Add(new BASE.Logging.LogTypes.FlatFileLogType(HttpContext.Current.Request.PhysicalApplicationPath + @"Logs\BASELog_adid_" + AppDomain.CurrentDomain.Id +
				"_pid_" + Process.GetCurrentProcess().Id.ToString() + ".txt", LogPriority.Debug));
			//Logger.Loggers.Add(new BASE.Logging.LogTypes.FlatFileLogType(HttpContext.Current.Request.PhysicalApplicationPath + @"Logs\logilfe_" + DateTime.Now.ToShortDateString() + " - " + DateTime.Now.ToShortTimeString() + " BASELog_adid_" + AppDomain.CurrentDomain.Id +
			//    "_pid_" + Process.GetCurrentProcess().Id.ToString() + ".txt", LogPriority.Debug));
			Logger.Loggers.Add(new DebugLogger(LogPriority.Debug, true, false));
#else
			Logger.Loggers.Add(new BASE.Logging.LogTypes.FlatLogType(HttpContext.Current.Request.PhysicalApplicationPath + @"Logs\BASELog_adid_" + AppDomain.CurrentDomain.Id + 
				"_pid_" + Process.GetCurrentProcess().Id.ToString() + ".txt", LogPriority.Warning));
#endif

            // Logging the Start of Initialization of this SystemManager's call instance
			Logger.Log("System Starting (from BASEApplication)", LogCatSystem);
			
            // Calling the SystemManager Initialization to create a singleton class, and load it.
			SystemManager.Initialize();

			if(SystemManager.Current._enableRemoteLogger)
				Logger.Loggers.Add(new ASLType(LogPriority.Debug, SystemManager.Current._remoteLoggerServiceIP, SystemManager.Current._remoteLoggerServicePort));

			Logger.Assert(SystemManager.Current != null, "System Manager not initialized", LogCatSystem);
            // Logging the End of Initialization of this SystemManager's call instance
			Logger.Log("System started() (from BASEApplication)", LogCatSystem);

		}

        /// <summary>
        /// This method get called when the Whole application end.
        /// </summary>
        /// <param name="sender">The Object that did call this method.</param>
        /// <param name="e">Event Arguments passed to the method.</param>
		protected void Application_End(object sender, EventArgs e)
		{
            // Stopping the Logging Engine.
			Logger.EndLogging();
		}

		public void FormsAuthentication_OnAuthenticate(object sender, FormsAuthenticationEventArgs e)
		{
			Logger.Log("FormsAuthentication_OnAuthenticate TESTING TESTING TESTING in BASEApplication", LogPriority.Debug, "AUTHENTICATION");

			////Make sure cookies are supported
			//if (FormsAuthentication.CookiesSupported)
			//{
			//    HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
			//    //make sure we have a cookie
			//    if (authCookie != null)
			//    {
			//        try
			//        {
			//            //Get the ticket
			//            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);

			//            //Set the principle and Identity
			//            //args.User = new System.Security.Principal.GenericPrincipal(new Samples.AspNet.Security.MyFormsIdentity(ticket),  new string[0]);
			//            UserIdentityToken token = UserIdentityToken.CreateTokenNoSecCheck(new Guid(ticket.Name));
			//            BASEPrinciple principle = new BASEPrinciple(token);
			//            e.User = principle;

			//        }
			//        catch (Exception ex)
			//        {
			//            throw new HttpException("Forms Authentication Ticket could not be decrypted.");
			//        }
			//    }
			//    else
			//    {
			//        //SET ANON PRINCIPLE?
			//    }
			//}
			//else
			//{
			//    throw new HttpException("Cookieless Forms Authentication is not " +
			//                            "supported for this application.");
			//}
		}



		/// <summary>
		/// Gets the current BASERequest for the current context.
		/// </summary>
		public BASERequest BASERequest
		{
			get { return _baseRequest; }
		}

		/// <summary>
		/// This class represents information specific to base for the current request
		/// </summary>

	}



}
