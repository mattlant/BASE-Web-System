using System;
using System.Collections.Generic;
using System.Text;

using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web;
using BASE.Web;
using BASE.Web.EndPoints;
using BASE.Web.HtmlParsing;
using BASE.Web.UI;
using BASE.Web.UI.Controls;
using BASE.Data.LLDAL.EntityClasses;
using BASE.Data.LLDAL.HelperClasses;
using BASE.Data.Helpers;

namespace BASE.Web.EndPoints.Plugins
{
	public class SkinningPlugin : IEndPointPlugin
	{
		#region IEndPointPlugin Members

		public void Init(EndPointPluginManager epMan)
		{
			SkinnedEndPoint.SkinPage += new EndPointProcessingHandler(SkinnedEndPoint_SkinPage);
			Logging.Logger.Log("SkinningPlugin - Added Event Handler for Preinit-Skinning-SkinPage", BASE.Logging.LogPriority.Debug, EndPoint.EndPointCat);
		}

		void SkinnedEndPoint_SkinPage(object sender, EndPointEventArgs e)
		{
			//Setup needed objects
			SkinnedEndPoint ep = (SkinnedEndPoint)sender;
			BASEApplication app = (BASEApplication)HttpContext.Current.ApplicationInstance;
			//Used to indicate if the default region for a page has been merged yet.
			bool defaultAdded = false;
			//Get template chunks for sites template.

			//Find the Region panel.


			//TODO: Add in more comprehensive checking for valid sites, default system site, etc.
			SiteVirtualInfoEntity site = BASE.Data.Helpers.SiteVirtualInfoDataHelper.SelectSingle(app.BASERequest.SiteUID);
			if (site == null)
				throw new PageSkinningException("A Default site is required to skin a page with a template");

			//TODO: Add in checks for a valid TemplateGUid
			EntityCollection<TemplateChunksEntity> chunks = TemplateChunkDataHelper.Select(site.TemplateGUID.Value, true);

			List<HtmlChunk> htmlchunks = new HtmlParser().ParseToChunks(chunks, "bml");

			Control[] controls = new HtmlParser().ParseToControls(ep, htmlchunks, "bml");

			foreach (RegionPanel reg in ep.RegionPanels.Values)
			{
				ep.Form.Controls.Remove(reg);
			}

			foreach (Control c in controls)
			{
				if (c is RegionPlaceHolder)
				{
					RegionPlaceHolder plc = (RegionPlaceHolder)c;
					foreach (RegionPanel reg in ep.RegionPanels.Values)
					{
						//Make sure that we have a matching ID for proper merging of regions.
						if (reg.RegionID == plc.RegionID)
							plc.AddRegionPanel(reg);
					}
					//TODO We need to figure a way to Log any regions that are orphaned and never merge.
				}
				ep.Form.Controls.Add(c);
			}

		}
		#endregion
	}
}
