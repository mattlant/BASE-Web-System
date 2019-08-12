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
using BASE.Data.LLDAL.DatabaseSpecific;
using BASE.Data.LLDAL.EntityClasses;
using BASE.Data.LLDAL.HelperClasses;
using BASE.Data.Helpers;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace BASE.Web.EndPoints.Plugins
{
    /// <summary>
    /// This class is used to define a 'virtual generated or 
    /// staticly referenced' EndPointPlugin, which turn into 
    /// a VirtualEndPointPlugin and provide the necessary 
    /// events for the pluggin as pre-merge, merging and after merging.
    /// </summary>
	public class VirtualEndPointPlugin : IEndPointPlugin
	{
        /// <summary>
        /// This method is overrided from EndPointPlugin class
        /// </summary>
        /// <param name="epMan">The reference to the Unique Singleton EndPoint Plugin Manager</param>
		public void Init(EndPointPluginManager epMan)
		{
			VirtualSkinnedEndPoint.MergeRegion += new EndPointProcessingHandler(VirtualSkinnedEndPoint_MergeRegion);
			Logging.Logger.Log("VirtualEndPointPlugin - Added Event Handler for Preinit", BASE.Logging.LogPriority.Debug, EndPoint.EndPointCat);
		}

		void VirtualSkinnedEndPoint_MergeRegion(object sender, EndPointEventArgs e)
		{
			//Get ref to BASEApp
			BASEApplication app = (BASEApplication)HttpContext.Current.ApplicationInstance;
			VirtualSkinnedEndPoint ep = (VirtualSkinnedEndPoint)sender;

			//Get the Page info
			int pageID = app.BASERequest._pageUID;
			PageEntity page = PageDataHelper.SelectSingle(pageID);
			if (page == null)
				throw new ContentMergingException("Page not found. TODO: This needs to change!"); //TODO: Need to change for better handling, as well as default management

			//TODO: Page entity/table needs to be modified to be preparsed just like templates.
			//page.HTMLContent
			//Grab PageRegions
			EntityCollection<PageRegionEntity> regions = new EntityCollection<PageRegionEntity>();
			RelationPredicateBucket filter = new RelationPredicateBucket();
			filter.PredicateExpression.Add(PageRegionFields.PageUID == pageID);
			DataAccessAdapter da = new DataAccessAdapter();
			da.FetchEntityCollection(regions, filter);

			foreach (PageRegionEntity region in regions)
			{
				Control[] controls = new HtmlParser().ParseToControls(ep, region.RegionContent);
				RegionPanel regPanel = new RegionPanel(RegionPanelType.PlaceHolder);
				regPanel.RegionID = region.RegionId;
				foreach(Control c in controls)
					regPanel.Controls.Add(c);
				ep.RegionPanels.Add(regPanel.RegionID, regPanel);
			}
				
			//Add content to RegionPanel

			//Add region panels to RegionList
			
		}

        /// <summary>
        /// This is an example of the pre-merge init event, 
        /// being overloaded to handle the specific events.
        /// </summary>
        /// <param name="sender">The object who made the call.</param>
        /// <param name="e">The arguments passed to the call.</param>
		void epMan_EndPointInit(object sender, EndPointEventArgs e)
		{
			Label lbl = new Label();
			lbl.Text = "sdajfgakjshgdfkagsdfkjhgadskjfg";

            // Add this new label to the controls list of the 
            // form of our endpoint passed in the arguments of this call

			e.EndPoint.Form.Controls.Add(lbl);
			Logging.Logger.Log("VirtualEndPointPlugin - Page PreInit!");
		}



	}
}
