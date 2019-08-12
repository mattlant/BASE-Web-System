using System;
using System.Collections.Generic;
using System.Text;

using System.Xml;
using BASE.Xml;

namespace BASE.Web.UI.Controls
{
	public class BASEUserControlDefinition : BASEControlDefinition //TODO: Change this to inherit from BASEControlDefintion. (It will check for settings widgets.)
	{
		string _ascxFile;
		private string _subFolder;

		public BASEUserControlDefinition(XmlNode defNode, string fromFile, string parentModuleName) : base(defNode, fromFile, parentModuleName)
		{
			if (_doNotLoad) return;

			_ascxFile = defNode.Attributes[BASEUserControlDefinitionXmlAttributes.AscxFile].Value;
			_subFolder = defNode.Attributes[BASEUserControlDefinitionXmlAttributes.SubFolder] == null ? "" : defNode.Attributes[BASEUserControlDefinitionXmlAttributes.SubFolder].Value;

		}

		protected override bool IsMissingAttributes(XmlNode node, List<string> attrToCheck, ref string missingAttr)
		{
			//Add in UserControl attributes to the required list
			attrToCheck.AddRange(BASEUserControlDefinitionXmlAttributes.RequiredAttributes);
			return base.IsMissingAttributes(node, attrToCheck, ref missingAttr);
		}

		/// <summary>
		/// Gets the AscxFile of the module control
		/// </summary>
		public string AscxFile
		{
			get
			{
				return _ascxFile;
			}
		}

		/// <summary>
		/// Gets the SubFolder of the module control
		/// </summary>
		public string SubFolder
		{
			get
			{
				return _subFolder;
			}
		}

		public override IBASEControl CreateControl(System.Web.UI.Page page, string tagName)
		{
			return (IBASEControl)page.LoadControl("~/Modules/" + this._parentDefName + "/" + this._ascxFile);

		}

		//protected override void ParseChildNodes(XmlNode node)
		//{
			
		//    base.ParseChildNodes(node);
		//}
	}
}
