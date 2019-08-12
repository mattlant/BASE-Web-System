using System;
using System.Collections.Generic;
using System.Text;

using BASE.Configuration;

namespace BASE.Web
{
	public class InitializeRequestHttpModule : IBASEHttpModule
	{
		BASEApplication _context;


		public void Init(System.Web.HttpApplication context)
		{
			_context = (BASEApplication)context;
			_context.BeginRequest += new EventHandler(_context_BeginRequest);
			Logging.Logger.Log("InitializeRequestHttpModule Init()");
		}

		//Initilize ALL base request specific stuff prior to any request processing
		void _context_BeginRequest(object sender, EventArgs e)
		{
			Logging.Logger.Log(String.Format("InitializeRequestHttpModule BeginRequest URL={0}, Referrer={1}", _context.Request.Url.OriginalString, _context.Request.UrlReferrer), BASE.Logging.LogPriority.Debug);

			BASEApplication currentContext = (BASEApplication)sender;

			//if
			//Reset the BASERequest object every request.
			currentContext.BASERequest.Reset(currentContext.Request.Url);

		}

		public void Dispose()
		{
			Logging.Logger.Log("InitializeRequestHttpModule Disposed.");
		}



	}
}
