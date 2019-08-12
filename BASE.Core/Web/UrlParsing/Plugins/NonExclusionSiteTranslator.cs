using System;
using System.Collections.Generic;
using System.Text;

namespace BASE.Web.UrlParsing.Plugins
{
	/// <summary>
	/// This class will translate a request into a site folder if the request is not on the exclusion list.<br/>
	/// This should be one of the last URL Parser plugins to be executed.
	/// </summary>
	public class NonExclusionSiteTranslator : IUrlParserPlugin
	{
		#region IUrlParserPlugin Members

		public void ProcessUrl(BASEApplication context)
		{
			//FileInfo file = null;
			BASEApplication app = (BASEApplication)context;
			Uri url = app.Request.Url;

			// get the filename from the querystring
			string path = url.AbsolutePath;


			// Obviously, if we had to check for filename exclusion, it would be done in here
			// before the physical or dynamic check get processed.
			// We need to check only the first level of subnames in a URL. 
			// Segments are like this: mattlant.com/dev/hello/world.htm: [0] = '/' [1] = 'dev/' [2] = 'hello/' [3] = 'world.htm'
			if (url.Segments.Length > 1 && !BASE.Configuration.ConfigurationManager.Current.IsSubExclusion(url.Segments[1]))
			{
				path = app.BASERequest.RealSectionPath.TrimEnd(new char[]{ '/' }) + path;
				app.Context.RewritePath(path + url.Query);
				Logging.Logger.Log(string.Format("NonExclusionSiteTranslator: URL REMAPPED: {0}, {1}", url.ToString(), path));
			}
		}

		#endregion

		#region IInitFromXml Members

		public void Init(System.Xml.XmlNode xmlNode)
		{
			Logging.Logger.Log("NonExclusionSiteTranslator.Init: " + xmlNode.Name);
		}

		#endregion
	}
}
