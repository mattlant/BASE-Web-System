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
	[ToolboxData("<{0}:RegionPanel IsDefault='True' runat='server'></{0}:RegionPanel>")]
	/// <summary>
	/// This class is used to define Regions in base for content areas and user defined and editable areas on pages.
	/// </summary>
	public class RegionPanel : Panel
	{
		bool _isDefault = false;
		bool _isEditable = true;
		RegionPanelType _regionType = RegionPanelType.Content;
		string _regionID;

		//Default ctor
		/// <summary>
		/// Default constructor to initialize a BASE Region Panel
		/// </summary>
		public RegionPanel()
			: base()
		{
		}

		/// <summary>
		/// Constrcutor to initialize a RegionPanel.
		/// </summary>
		/// <param name="regionType">A RegionPanelType flag to specify the type of panel this is.</param>
		public RegionPanel(RegionPanelType regionType)
			: this("", regionType)
		{
		}

		/// <summary>
		/// Constrcutor to initialize a RegionPanel.
		/// </summary>
		/// <param name="regionID">The Region's ID used to match regions from panels, placeholders, templates, content, etc.</param>
		public RegionPanel(string regionID)
			: this(regionID, RegionPanelType.Content)
		{
		}

		/// <summary>
		/// Constrcutor to initialize a RegionPanel.
		/// </summary>
		/// <param name="regionID">The Region's ID used to match regions from panels, placeholders, templates, content, etc.</param>
		/// <param name="regionType">A RegionPanelType flag to specify the type of panel this is.</param>
		public RegionPanel(string regionID, RegionPanelType regionType)
			: base()
		{
			_regionID = regionID;
			_regionType = regionType;
		}

		//TODO: What happens when there is more than one that is set to default?
		//Perhaps we need to have a setting per page that defines which ID region is default.
		/// <summary>
		/// Flag to indicate if this Region is the default Region for a page.
		/// </summary>
		/// 
		[
		Bindable(true),
		Category("BASE Settings"),
		DefaultValue(false),
		Description("Flag to indicate if this Region is the default Region for a page."),
		Localizable(false)
		]
		public bool IsDefault
		{ 
			get { return _isDefault; } 
			set { _isDefault = value; } 
		}

		/// <summary>
		/// Flag to indicate if this Region is editable for content by a web user.
		/// </summary>
		/// 
		[
		Bindable(true),
		Category("BASE Settings"),
		DefaultValue(true),
		Description("Flag to indicate if this Region is editable for content by a web user."),
		Localizable(false)
		]
		public bool IsEditable
		{
			get { return _isEditable; }
			set { _isEditable = value; }
		}

		/// <summary>
		/// Gets and sets the Region's ID used to match regions from panels, placeholders, templates, content, etc.
		/// </summary>
		/// 
		[
		Bindable(true),
		Category("BASE Settings"),
		DefaultValue(""),
		Description("The Region's ID used to match regions from panels, placeholders, templates, content, etc."),
		Localizable(false)
		]
		public string RegionID
		{
			get { return _regionID; }
			set { _regionID = value; }
		}

		/// <summary>
		/// Specifies which type of Region this is.
		/// </summary>
		[
		Bindable(true),
		Category("BASE Settings"),
		DefaultValue(RegionPanelType.Content),
		Description("Flag to indicate if this Region is the default Region for a page."),
		Localizable(false)
		]
		public RegionPanelType RegionPanelType
		{ 
			get { return _regionType; } 
			set { _regionType = value; }  
		}
	}

	/// <summary>
	/// Specifies a type for RegionPanels. This enumeration is specified as flags so you can define multiple flags for a region.
	/// </summary>
	public enum RegionPanelType
	{
		/// <summary>
		/// This denotes the region as being for content
		/// </summary>
		Content = 1,

		/// <summary>
		/// This denotes the RegionPanel is a temporary placeholder
		/// </summary>
		PlaceHolder = 2

	}
}
