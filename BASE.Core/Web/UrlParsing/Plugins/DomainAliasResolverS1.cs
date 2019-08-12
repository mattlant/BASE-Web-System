using System;
using System.Collections.Generic;
using System.Text;

using BASE.Web.UrlParsing;
using BASE.Data;
using BASE.Data.Helpers;

namespace BASE.Web.UrlParsing.Plugins
{
	//STAGE 1
	/// <summary>
	/// The DomainAliasResolver Url Parser Plugin performs resolution of the domain name into a site UID
	/// </summary>
	public class DomainAliasResolver : IUrlParserPlugin
	{
		public void ProcessUrl(BASEApplication app)
		{
			int tempsiteUID = WebUtils.QS.ToInt32ElseMin(app.Request.QueryString[BASEQS.SiteUID]);
			if (tempsiteUID != int.MinValue)
			{
				app.BASERequest._siteUID = tempsiteUID;
				return;
			}

			Logging.Logger.Log("DomainAliasResolver.ProcessUrl: " + app.Request.Url.OriginalString);
			app.BASERequest.SiteUID = SiteDataHelper.SelectSiteUIDByDomainName(app.Request.Url.Host);
			//if (app.BASERequest.SiteUID != 0)
			//    app.BASERequest.AddSiteToList(app.Request.Url.Host, app.BASERequest.SiteUID);
		}

		public void Init(System.Xml.XmlNode xmlNode)
		{
			Logging.Logger.Log("DomainAliasResolver.Init: " + xmlNode.Name);
		}

	}
}
