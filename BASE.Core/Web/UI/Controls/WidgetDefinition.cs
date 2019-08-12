using System;
using System.Collections.Generic;
using System.Text;

using System.Xml;

namespace BASE.Web.UI.Controls
{
	public class WidgetDefinition : BASEUserControlDefinition
	{

		public WidgetDefinition(XmlNode defNode, string fromFile, string parentModuleName)
			: base(defNode, fromFile, parentModuleName)
		{
			if (_doNotLoad) return;

		}

		//protected override bool IsMissingAttributes(XmlNode node, List<string> attrToCheck, ref string missingAttr)
		//{
		//    //Add in UserControl attributes to the required list
		//    //attrToCheck.AddRange(BASEUserControlDefinitionXmlAttributes.RequiredAttributes);
		//    return base.IsMissingAttributes(node, attrToCheck, ref missingAttr);
		//}

	}
}
