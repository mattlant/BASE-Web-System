using System;
using System.Collections.Generic;
using System.Text;

using System.Xml;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BASE.Web.UI;
using BASE.Web.UI.Controls;
using BASE.Modules;
using BASE.Logging;


namespace BASE.Web.HtmlParsing.Plugins
{
	public class BASETagParserPlugin : ITagParserPlugin
	{
		public static readonly string AttributesModuleName = "moduleName";
		public static readonly string AttributesName = "name";

		string _prefix = "base";

		public string Prefix
		{
			get { return _prefix; }
		}

		public System.Web.UI.Control HandleTag(Page page, HtmlTag tag)
		{
			Dictionary<string, string> attributes = tag.Attributes;
			string modName = attributes[AttributesModuleName];
			string name = attributes[AttributesName];

			Logger.Log(string.Format("BASETagParserPlugin.HandleTag - Prefix:{0} Name:{1} AttributesAsString:{2}", tag.Prefix, tag.TagName, tag.AttributesAsString)
				, LogPriority.Debug, "TAGPARSER");


			ModuleDefinition def = ModuleManager.Current.ModuleDefinitionsByName[modName];
			if (def == null)
				throw new BASEGenericException(string.Format("Module '{0}' does not exist", modName));

			BASEControlDefinition cdef = def.GetControlDefByName(name);


			//Now that we have a def we can use that to create a control.


			IBASEControl newControl = cdef.CreateControl(page, tag.TagName);

			if (newControl == null) return (System.Web.UI.Control)newControl;

			newControl.InitializeParameters(attributes);
			return (System.Web.UI.Control)newControl;

		}

		public void Init(XmlNode tagHanlderDefNode)
		{
			//TODO: Implemnent
			return;
		}

	}
}
