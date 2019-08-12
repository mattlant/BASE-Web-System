using System;
using System.Collections.Generic;
using System.Text;

using BASE.Configuration;

namespace BASE.Web.UrlParsing
{
	public class UrlParserHttpModule : IBASEHttpModule
	{
		BASEApplication _context;

		private static List<IUrlParserPlugin> _plugins = new List<IUrlParserPlugin>();

		public void Init(System.Web.HttpApplication context)
		{
			_context = (BASEApplication)context;
			_context.BeginRequest += new EventHandler(_context_BeginRequest);
			Logging.Logger.Log("UrlParserHttpModule Init()");
		}

		void _context_BeginRequest(object sender, EventArgs e)
		{
			Logging.Logger.Log(String.Format("UrlParserHttpModule BeginRequest URL={0}, Referrer={1}", _context.Request.Url.OriginalString, _context.Request.UrlReferrer), 
				BASE.Logging.LogPriority.Debug, "URLPARSING");
			//Get all IUrlParsers
			if (!SystemManager.IsInitialized) return;

			BASEApplication app = (BASEApplication)sender;

			ParseUrl(app);

		}

		public void Dispose()
		{
			Logging.Logger.Log("UrlParserHttpModule Disposed.");
		}

		public static void AddPlugin(IUrlParserPlugin plugin)
		{
			_plugins.Add(plugin);
		}

		public static void ParseUrl(BASEApplication app)
		{
			//TODO: Add in code. Move from the BeginRequest to here. Let that call this.


			////TODOH: Change UrlParsers to use and return Uri's
			Uri url = app.Request.Url;
			BASERequest req = app.BASERequest;

			foreach (IUrlParserPlugin plugin in _plugins)
			    plugin.ProcessUrl(app);

			//If SIteUID == 0, then we need to set it to the default site as per the BASE.config
			if(req._siteUID == 0)
				req._siteUID = SystemManager.Current.DefaultSiteUID;

			////TODOH: Write back url to the request to continue processing.
			//SOLVED. Each plugin writes the url back itself.

			req._isRequestFinal = true;
			req._finalUrl = app.Request.Url;

		}

	}
}
