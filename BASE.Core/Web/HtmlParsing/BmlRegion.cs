using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.RegularExpressions;
using BASE.Web.UI.Controls;

namespace BASE.Web.HtmlParsing
{
	public class BmlRegion : HtmlTag
	{
		bool _isEditable = true;
		bool _isDefualt = false;
		RegionPanelType _regionType = RegionPanelType.Content;

		public BmlRegion(string tag)
			: base(tag)
		{
			this._type = HtmlChunkType.Region;
			setRegionFlags();
		}

		public BmlRegion(Match tag)
			: base(tag)
		{
			this._type = HtmlChunkType.Region;
			setRegionFlags();
		}

		public BmlRegion(Match tag, string outterText)
			: base(tag, outterText)
		{
			this._type = HtmlChunkType.Region;
			setRegionFlags();
		}
		public BmlRegion(string outterText, string tag, string prefix, string attributes)
			: base(outterText, tag, prefix, attributes)
		{
			this._type = HtmlChunkType.Region;
			setRegionFlags();
		}

		protected virtual void setRegionFlags()
		{
			if (this._attributes.ContainsKey("isEditable"))
				this._isEditable = bool.Parse(this._attributes["isEditable"]);

			if (this._attributes.ContainsKey("isDefault"))
				this._isDefualt = bool.Parse(this._attributes["isDefault"]);

			if (this._attributes.ContainsKey("regionType"))
				this._regionType = (RegionPanelType)Enum.Parse(typeof(RegionPanelType), this._attributes["regionType"]);

		}


	}
}
