	using System;
using System.Collections.Generic;
using System.Text;

using BASE.Data;
using BASE.Data.LLDAL.EntityClasses;
using BASE.Data.Helpers;
using BASE.Web.EndPoints;

namespace BASE.Web.UrlParsing.Plugins
{
	//STAGE 4
	public class EndPointResolver : IUrlParserPlugin
	{
		public void ProcessUrl(BASEApplication app)
		{
			int overridepageUID = WebUtils.QS.ToInt32ElseMin(app.Request.QueryString[BASEQS.PageUID]);
			if (overridepageUID != int.MinValue)
			{
				app.BASERequest._pageUID = overridepageUID;
				return;
			}

			Logging.Logger.Log("EndPointResolver.ProcessUrl: " + app.Request.Url.OriginalString, BASE.Logging.LogPriority.Info);

			string path = app.Request.Url.AbsolutePath;

			EndPointAliasEntity epa = EndPointAliasDataHalper.SelectSingle(path.Trim(new char[1] {'/'}), app.BASERequest.SectionUID);


			if (epa == null)
				return;

			//This code is temporary only.
			//TODO: USE StringBuilder
			string newurl = "/";

			switch (epa.EndPointType)
			{
				case (int)EndPointAliasType.Virtual: //Virtual
					newurl += "VirtualPage.aspx";
					app.BASERequest._pageUID = epa.PageUID.Value;
					app.Context.RewritePath(newurl + app.Request.Url.Query);
					break;
				default:
					app.Response.Write("EndPointAlias not resolved");
					app.Response.Flush();
					app.Response.End();
					break;
			}



			//TODO: Change the path.

			//All sucsite and sections should be already stripped at this point.
			//We can now take the final segment(s) and do a lookup in the alias table.
			//If there is not an alias, we assume it is a physical location being accesses. This will be handled by the BASE handler for physical file mapping
			//If it is an alias, we check which type, and setup the actual page, pageUID, and/or query string info.
		}

		public void Init(System.Xml.XmlNode xmlNode)
		{
			Logging.Logger.Log("EndPointResolver.Init: " + xmlNode.Name, BASE.Logging.LogPriority.Info);
		}

	}
}
