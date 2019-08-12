using System;
using System.Collections.Generic;
using System.Text;

using BASE.Data.Helpers;

namespace BASE.Web.UrlParsing.Plugins
{
	//Stage 3
	public class SectionNameResolver : IUrlParserPlugin
	{
		public void ProcessUrl(BASEApplication app)
		{
			int tempsectionUID = WebUtils.QS.ToInt32ElseMin(app.Request.QueryString[BASEQS.SectionUID]);
			if (tempsectionUID != int.MinValue)
			{
				app.BASERequest._sectionUID = tempsectionUID;
				return;
			}

			Logging.Logger.Log("SectionNameResolver.ProcessUrl: " + app.Request.Url.OriginalString);
			//TODO: This will not properly resolve if no page is given and the last segment is not setup with a default page (in IIS) which it wont be. Need a detector for default pages possibly.
			//^FIXED^ Just parse the final segment and dont assume its always a page. A section should not be named same as page anyways. So it will properly resolve sites/sections. 
			string[] segments = app.Request.Url.Segments;
			int length = segments.Length;

			//loop thru segments and search for subsites.
			int sectionUID = 0;
			int segmentcount = 2;

			//make sure there is a subfolder in url, if so process (The segment[0] will always be '/'
			if (length > 1 && !app.BASERequest.IsRootExclusion)
			{
				//firsct segment is first subfolder in url
				sectionUID = SectionDataHelper.SelectUIDByNameSiteUID(segments[1].TrimEnd("/".ToCharArray()), app.BASERequest._siteUID);
				//if that subfolder was actually a site, and there are more of them, loop
				if (sectionUID != 0 && length > 2)
				{
					app.BASERequest.AddSectionToList(segments[1].TrimEnd("/".ToCharArray()), sectionUID);
					//TODO: Add stripping of subsite HERE ALSO
					for (segmentcount = 2; segmentcount < segments.Length; segmentcount++)
					{
						//Check if there is a subsite with the previous site as a parent
						int subsectionUID = SectionDataHelper.SelectUIDByNameParentSectionUID(segments[segmentcount].TrimEnd("/".ToCharArray()), sectionUID);
						//if not found, break without assigning a new site uid
						if (subsectionUID == 0)
							break;
						//if found, assign new siteuid, and check next.
						//TODO: Add stripping of subsite HERE ALSO
						sectionUID = subsectionUID;
						app.BASERequest.AddSectionToList(segments[segmentcount].TrimEnd("/".ToCharArray()), sectionUID);
					}
				}
			}

			//if subsite found, assign it, and strip the subsites out of the URL.
			if (sectionUID != 0)
			{
				app.BASERequest._sectionUID = sectionUID;
				StringBuilder sb = new StringBuilder("/", 30);
				for (int i = segmentcount; i < segments.Length; i++)
				{
					sb.Append(segments[i]);
				}
				sb.Append(app.Request.Url.Query);
				app.Context.RewritePath(sb.ToString());
			}
		}

		public void Init(System.Xml.XmlNode xmlNode)
		{
			Logging.Logger.Log("SectionNameResolver.Init: " + xmlNode.Name);
		}

	}
}
