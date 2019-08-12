using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using BASE;
using BASE.Web;

namespace BASE.Web.UrlParsing.Plugins
{
	//stage 1.5
	public class ExclusionListResolver : IUrlParserPlugin
	{

		public void ProcessUrl(BASEApplication app)
		{
			HttpRequest req = app.Request;
			BASERequest baseReq = app.BASERequest;
			string[] segments = req.Url.Segments;

			//Check the exclusion list first.
			bool qsOverride = false;
			string urlrw = req.QueryString["URLRW"];
			if (!string.IsNullOrEmpty(urlrw))
				qsOverride = urlrw == "0" ? true : false;

			if (qsOverride || BASE.Configuration.ConfigurationManager.Current.IsRootExclusion(segments[1]))
				baseReq._isRootExclusion = true;

		}

		public void Init(System.Xml.XmlNode xmlNode)
		{
			Logging.Logger.Log("ExclusionListResolver.Init: " + xmlNode.Name);
		}

}
}
