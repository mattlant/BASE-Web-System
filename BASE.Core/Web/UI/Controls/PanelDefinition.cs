using System;
using System.Collections.Generic;
using System.Text;


using System.Xml;

namespace BASE.Web.UI.Controls
{
	public class PanelDefinition : BASEUserControlDefinition
	{

		public PanelDefinition(XmlNode defNode, string fromFile, string parentModuleName)
			: base(defNode, fromFile, parentModuleName)
		{
			if (_doNotLoad) return;


		}


	}
}
