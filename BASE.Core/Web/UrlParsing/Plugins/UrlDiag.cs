using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

using BASE.Logging;

namespace BASE.Web.UrlParsing.Plugins
{
	public class UrlDiagStart : IUrlParserPlugin
	{
		public void ProcessUrl(BASEApplication app)
		{
			//LOG Paths, Urls etc
			HttpRequest req = app.Request;
			Logger.Log(string.Format("UrlDiagStart - Request.ApplicationPath: {0}", req.ApplicationPath));
			Logger.Log(string.Format("UrlDiagStart - Request.FilePath: {0}", req.FilePath));
			Logger.Log(string.Format("UrlDiagStart - Request.HttpMethod: {0}", req.HttpMethod));
			Logger.Log(string.Format("UrlDiagStart - Request.PathInfo: {0}", req.PathInfo));
			Logger.Log(string.Format("UrlDiagStart - Request.PhysicalApplicationPath: {0}", req.PhysicalApplicationPath));
			Logger.Log(string.Format("UrlDiagStart - Request.PhysicalPath: {0}", req.PhysicalPath));
			Logger.Log(string.Format("UrlDiagStart - Request.Path: {0}", req.Path));
			Logger.Log(string.Format("UrlDiagStart - Request.RawUrl: {0}", req.RawUrl));
			StringBuilder sb = new StringBuilder(40);
			string[] segs = req.Url.Segments;
			for (int i = 0; i < req.Url.Segments.Length; i++ )
			{
				sb.Append(i.ToString());
				sb.Append(")  ");
				sb.Append(segs[i]);
				sb.Append("   ");
			}

			Logger.Log(string.Format("UrlDiagStart - Request.Url.Segments: {0}", sb));
			Logger.Log(string.Format("UrlDiagStart - Request.RequestType: {0}", req.RequestType));
			Logger.Log(string.Format("UrlDiagStart - Request.Url.OriginalString: {0}", req.Url.OriginalString));
			Logger.Log(string.Format("UrlDiagStart - Request.Url.AbsolutePath: {0}", req.Url.AbsolutePath));
			Logger.Log(string.Format("UrlDiagStart - Request.Url.AbsoluteUri: {0}", req.Url.AbsoluteUri));
			if(req.UrlReferrer == null)
				Logger.Log("UrlDiagStart - Request.UrlReferrer.OriginalString: NO REFERRER");
			else
				Logger.Log(string.Format("UrlDiagStart - Request.UrlReferrer.OriginalString: {0}", req.UrlReferrer.OriginalString));
		}

		public void Init(System.Xml.XmlNode xmlNode)
		{
		}

	}

	public class UrlDiagEnd : IUrlParserPlugin
	{
		public void ProcessUrl(BASEApplication app)
		{
			//LOG Paths, Urls etc
			HttpRequest req = app.Request;
			Logger.Log(string.Format("UrlDiagEnd - Request.ApplicationPath: {0}", req.ApplicationPath));
			Logger.Log(string.Format("UrlDiagEnd - Request.FilePath: {0}", req.FilePath));
			Logger.Log(string.Format("UrlDiagEnd - Request.HttpMethod: {0}", req.HttpMethod));
			Logger.Log(string.Format("UrlDiagEnd - Request.PathInfo: {0}", req.PathInfo));
			Logger.Log(string.Format("UrlDiagEnd - Request.PhysicalApplicationPath: {0}", req.PhysicalApplicationPath));
			Logger.Log(string.Format("UrlDiagEnd - Request.PhysicalPath: {0}", req.PhysicalPath));
			Logger.Log(string.Format("UrlDiagEnd - Request.Path: {0}", req.Path));
			Logger.Log(string.Format("UrlDiagEnd - Request.RawUrl: {0}", req.RawUrl));
			StringBuilder sb = new StringBuilder(40);
			string[] segs = req.Url.Segments;
			for (int i = 0; i < req.Url.Segments.Length; i++)
			{
				sb.Append(i.ToString());
				sb.Append(")  ");
				sb.Append(segs[i]);
				if (i < segs.Length - 1)
					sb.Append(" --- ");
			}

			Logger.Log(string.Format("UrlDiagEnd - Request.Url.Segments: {0}", sb));
			Logger.Log(string.Format("UrlDiagEnd - Request.RequestType: {0}", req.RequestType));
			Logger.Log(string.Format("UrlDiagEnd - Request.Url.OriginalString: {0}", req.Url.OriginalString));
			Logger.Log(string.Format("UrlDiagEnd - Request.Url.AbsolutePath: {0}", req.Url.AbsolutePath));
			Logger.Log(string.Format("UrlDiagEnd - Request.Url.AbsoluteUri: {0}", req.Url.AbsoluteUri));
			if (req.UrlReferrer == null)
				Logger.Log("UrlDiagEnd - Request.UrlReferrer.OriginalString: NO REFERRER");
			else
				Logger.Log(string.Format("UrlDiagEnd - Request.UrlReferrer.OriginalString: {0}", req.UrlReferrer.OriginalString));
		}

		public void Init(System.Xml.XmlNode xmlNode)
		{
		}

	}
}
