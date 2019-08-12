using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

using BASE.Data;
using BASE.Data.Helpers;

namespace BASE.Web.UrlParsing.Plugins
{
	//Stage 2
	public class SubSiteAliasResolver : IUrlParserPlugin
	{
		public void ProcessUrl(BASEApplication app)
		{
			HttpRequest req = app.Request;
			BASERequest baseReq = app.BASERequest;

			int tempsiteUID = WebUtils.QS.ToInt32ElseMin(req.QueryString[BASEQS.SiteUID]);
			if (tempsiteUID != int.MinValue)
			{
				baseReq._siteUID = tempsiteUID;
				return;
			}


			Logging.Logger.Log("SubSiteAliasResolver.ProcessUrl: " + app.Request.Url.OriginalString);
			//TODO: This will not properly resolve if no page is given and the last segment is not setup with a default page (in IIS) which it wont be. Need a detector for default pages possibly.
			//^FIXED^ Just parse the final segment and dont assume its always a page. A section should not be named same as page anyways. So it will properly resolve sites/sections. 
			string[] segments = req.Url.Segments;
			int length = segments.Length;
			
			//loop thru segments and search for subsites.
			int subsiteUID = 0;
			int segmentcount = 2;

			//make sure there is a subfolder in url, if so process (The segment[0] will always be '/'. Also, make sure there is npo URLRW override nor is it on the exclusion list.
			if (length > 1 && !baseReq.IsRootExclusion)
			{
				//Check the exclusion list first.
				//firsct segment is first subfolder in url
				subsiteUID = SiteDataHelper.SelectSiteUIDBySubSiteNameANDParentUID(segments[1].TrimEnd("/".ToCharArray()), baseReq.SiteUID);
				//if that subfolder was actually a site, and there are more of them, loop
				if (subsiteUID != 0 && length > 3)
				{
					baseReq.AddSiteToList(segments[1].TrimEnd("/".ToCharArray()), subsiteUID);
					//TODO: Add stripping of subsite HERE ALSO
					for (segmentcount = 2; segmentcount < segments.Length; segmentcount++)
					{
						//Check if there is a subsite with the previous site as a parent
						int subsubsiteUID = SiteDataHelper.SelectSiteUIDBySubSiteNameANDParentUID(segments[segmentcount].TrimEnd("/".ToCharArray()), subsiteUID);
						//if not found, break without assigning a new site uid
						if (subsubsiteUID == 0)
							break;
						//if found, assign new siteuid, and check next.
						//TODO: Add stripping of subsite HERE ALSO
						subsiteUID = subsubsiteUID;
						baseReq.AddSiteToList(segments[segmentcount].TrimEnd("/".ToCharArray()), subsiteUID);
					}
				}
			}

			//if subsite found, assign it, and strip the subsites out of the URL.
			if (subsiteUID != 0)
			{

				baseReq._siteUID = subsiteUID;
				//Flag that it is a subsite.
				baseReq._isSubSite = true;
				StringBuilder sb = new StringBuilder("/", 30);
				for (int i = segmentcount; i < segments.Length; i++)
				{
					sb.Append(segments[i]);
				}
				sb.Append(req.Url.Query);
				app.Context.RewritePath(sb.ToString());
			}

		}



		public void Init(System.Xml.XmlNode xmlNode)
		{
			Logging.Logger.Log("SubSiteAliasResolver.Init: " + xmlNode.Name);
		}

	}
}
