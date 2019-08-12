using System;
using System.Collections.Generic;
using System.Text;

using System.Xml;
using BASE.Xml;

namespace BASE.Web.UI.Controls
{
    public class HtmlSnippetDefinition : BASEControlDefinition
    {
		public HtmlSnippetDefinition(XmlNode defNode, string fromFile, string parentModuleName)
			: base(defNode, fromFile, parentModuleName)
		{
			if (_doNotLoad) return;

		}

		public override IBASEControl CreateControl(System.Web.UI.Page page, string tagName)
		{
			throw new Exception("The method or operation is not implemented.");
		}


		//protected override bool IsMissingAttributes(XmlNode node, List<string> attrToCheck, ref string missingAttr)
		//{
		//    //Add in UserControl attributes to the required list
		//    //attrToCheck.AddRange(BASEUserControlDefinitionXmlAttributes.RequiredAttributes);
		//    return base.IsMissingAttributes(node, attrToCheck, ref missingAttr);
		//}
    }
}
