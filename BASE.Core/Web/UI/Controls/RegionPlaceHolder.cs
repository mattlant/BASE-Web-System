using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.ComponentModel;

namespace BASE.Web.UI.Controls
{
	public class RegionPlaceHolder: PlaceHolder
	{
		protected string _regionID;

		public virtual string RegionID
		{
			get { return _regionID; }
			set { _regionID = value; }
		}

		public virtual void AddRegionPanel(RegionPanel panel)
		{
			this.Controls.Add(panel);
		}
	}
}
