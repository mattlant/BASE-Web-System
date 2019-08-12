using System;
using System.Collections.Generic;
using System.Text;

using System.Xml;

namespace BASE.Web.UI.Controls
{

	public class PagePanelDefinition : PanelDefinition
	{
		protected bool _autoCreate = false;
		protected PageMethodType _pageMethod = PageMethodType.QueryString;
		protected bool _isEntryPoint = false;
		//protected PageMethodType _pageMthod; //TODO: Page method is how query string type info is passed.

		public PagePanelDefinition(XmlNode defNode, string fromFile, string parentModuleName)
			: base(defNode, fromFile, parentModuleName)
		{
			if (_doNotLoad) return;

			//Get attributes
			//_pageMethod = (PageMethodType)Enum.Parse(typeof(PageMethodType), defNode.Attributes[PagePanelXmlAttributes.PageMethod].Value);

			_autoCreate = XmlConvert.ToBoolean(defNode.Attributes[PagePanelXmlAttributes.AutoCreate].Value);

			_isEntryPoint = XmlConvert.ToBoolean(defNode.Attributes[PagePanelXmlAttributes.IsEntryPoint].Value);

		}

		[global::System.Obsolete("Page method will now be up to the Module at runtime")]
		/// <summary>
		/// Gets the PageMethodType of this panel. (Obsolete)
		/// </summary>
		public PageMethodType PageMethod
		{
			get
			{
				return _pageMethod;
			}
		}

		/// <summary>
		/// Gets true or false to indicate if this panel is autocreated when the module is newly added.
		/// </summary>
		public bool AutoCreate
		{
			get
			{
				return _autoCreate;
			}
		}

		/// <summary>
		/// Gets true or false to indicate if this panel is the MaiUI Entry point into the modules functionality
		/// </summary>
		public bool IsEntryPoint
		{
			get
			{
				return _isEntryPoint;
			}
		}

		protected override bool IsMissingAttributes(XmlNode node, List<string> attrToCheck, ref string missingAttr)
		{
			//Add in UserControl attributes to the required list
			attrToCheck.AddRange(PagePanelXmlAttributes.RequiredAttributes);
			return base.IsMissingAttributes(node, attrToCheck, ref missingAttr);
		}


	}

}
