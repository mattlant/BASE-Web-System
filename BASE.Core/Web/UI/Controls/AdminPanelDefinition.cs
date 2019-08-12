using System;
using System.Collections.Generic;
using System.Text;

using System.Xml;

namespace BASE.Web.UI.Controls
{
	public class AdminPanelDefinition : PagePanelDefinition
	{
		string _catagoryId = "";
		string _displayName = "";

		public AdminPanelDefinition(XmlNode defNode, string fromFile, string parentModuleName)
			: base(defNode, fromFile, parentModuleName)
		{
			if (_doNotLoad) return;

			_catagoryId = defNode.Attributes[AdminPanelXmlAttributes.CatagoryId] == null ? "" : defNode.Attributes[AdminPanelXmlAttributes.CatagoryId].Value;
			_displayName = defNode.Attributes[AdminPanelXmlAttributes.DisplayName] == null ? "" : defNode.Attributes[AdminPanelXmlAttributes.DisplayName].Value;
		}

		/// <summary>
		/// Gets the CatagoryId of the module control
		/// </summary>
		public string CatagoryId
		{
			get
			{
				return _catagoryId;
			}
		}

		/// <summary>
		/// Gets the DisplayName of the module control
		/// </summary>
		public string DisplayName
		{
			get
			{
				return _displayName;
			}
		}



		//protected override bool IsMissingAttributes(XmlNode node, List<string> attrToCheck, ref string missingAttr)
		//{
		//    //Add in UserControl attributes to the required list
		//    //attrToCheck.AddRange(PagePanelXmlAttributes.RequiredAttributes);
		//    return base.IsMissingAttributes(node, attrToCheck, ref missingAttr);
		//}


	}
}
