using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using BASE.Web.UI.Controls;

namespace BASE.Web.EndPoints
{
    /// <summary>
    /// This class represent a skinned EndPoint instance that inherit from EndPoint.
    /// </summary>
	public class SkinnedEndPoint : EndPoint
    {
        #region Events Handlers
        public static event EndPointProcessingHandler PreSkinPage;
		public static event EndPointProcessingHandler SkinPage;
		public static event EndPointProcessingHandler SkinPageComplete;
        #endregion

		protected Dictionary<string, RegionPanel> _regions = new Dictionary<string, RegionPanel>();

        /// <summary>
        /// Override of the OnInit method of the EndPoint class
        /// </summary>
        /// <param name="e">The arguments passed to this call.</param>
		protected override void OnInit(EventArgs e)
		{
			if (PreSkinPage != null)
				PreSkinPage(this, new EndPointEventArgs(this));
			if (SkinPage != null)
				SkinPage(this, new EndPointEventArgs(this));
			if (SkinPageComplete != null)
				SkinPageComplete(this, new EndPointEventArgs(this));

			base.OnInit(e);
		}

		public virtual Dictionary<string, RegionPanel> RegionPanels
		{ get { return _regions; } }

		public virtual RegionPanel this[string id]
		{ get { return _regions[id]; } }

	}
}
