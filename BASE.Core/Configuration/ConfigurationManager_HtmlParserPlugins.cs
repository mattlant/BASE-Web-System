using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

using BASE.Reflection;
using BASE.Web.HtmlParsing;
using BASE.Web.HtmlParsing.Plugins;

namespace BASE.Configuration
{
	public partial class ConfigurationManager
	{
		/// <summary>
		/// This method parses the 'HtmlParserPlugins' section of the BASE.config file.
		/// You can add/remove/modify plugins to change and/or expand BASE's HtmlParsing system
		/// </summary>
		/// <param name="xmlnode"></param>
		internal void ParseHtmlParserPlugins(XmlNode xmlnode)
		{
			foreach (XmlNode ch in xmlnode.ChildNodes)
			{
				if (ch.Name != "htmlParserPlugin") continue;

				string tag = ch.Attributes["tag"].Value;
				string type = ch.Attributes["type"].Value;

				object plugin = TypeHelper.CreateTypeFromConfigString(type);
				if (plugin is IHtmlParserPlugin)
				{
					IHtmlParserPlugin iplug = (IHtmlParserPlugin)plugin;
					iplug.Init(ch);
					HtmlParser.AddPlugin(iplug);
				}
			}

		}

	}
}
