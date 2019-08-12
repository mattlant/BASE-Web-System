using System;
using System.Collections.Generic;
using System.Text;

using System.Xml;
using BASE.Xml;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BASE.Web.UI.Controls
{
	/// <summary>
	/// Defines a BASE Control. All controls defined in BASE should have their definitions inherit from this class.
	/// </summary>
	public abstract class BASEControlDefinition : XmlDefinitionBase
	{
		internal string _parentDefName = "";

		public string ParentModuleDefinitionName
		{
			get { return _parentDefName; }
		}

		public BASEControlDefinition(XmlNode defNode, string fromFile, string parentModuleName)
			: base(defNode, fromFile)
		{
			if (_doNotLoad) return;

			_parentDefName = parentModuleName;
			Logging.Logger.Log(string.Format("ControlDefinition Loaded Loaded Name:{0} from Module:{1} ", this.Name, parentModuleName)
				, BASE.Logging.LogPriority.Debug, "MODULEINIT");

		}

		protected override bool IsMissingAttributes(XmlNode node, List<string> attrToCheck, ref string missingAttr)
		{
			//Add in UserControl attributes to the required list
			//attrToCheck.AddRange(BASEUserControlDefinitionXmlAttributes.RequiredAttributes);
			return base.IsMissingAttributes(node, attrToCheck, ref missingAttr);
		}

		protected override void ParseChildNodes(XmlNode node, string fromFile)
		{
			if (node == null)
				return;

			//TODO: Add in Settings Widget
			switch (node.Name)
			{
				case "settingsWidget":
					//Do Something
					break;

				default: break; //Just break and give the base class a chance to parse this node.
			}

			base.ParseChildNodes(node, fromFile);

		}

		public abstract IBASEControl CreateControl(Page page, string tagName);




	}
}
