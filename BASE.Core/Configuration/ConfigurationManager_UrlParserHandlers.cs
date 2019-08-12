using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

using BASE.Reflection;
using BASE.Web.UrlParsing;

namespace BASE.Configuration
{
	public partial class ConfigurationManager
    {

		/// <summary>
		/// This method parses the 'urlParserPlugins' section of the BASE.config file.
		/// You can add/remove/modify plugins to change and/or expand BASE's UrlParsing system
		/// </summary>
		/// <param name="xmlnode"></param>
		internal void ParseUrlParserPlugins(XmlNode xmlnode)
		{
			foreach (XmlNode ch in xmlnode.ChildNodes)
			{
				if (ch.Name != "urlParserPlugin") continue;

				string name = ch.Attributes["name"].Value;
				string type = ch.Attributes["type"].Value;

				object plugin = TypeHelper.CreateTypeFromConfigString(type);
				if (plugin is IUrlParserPlugin)
				{
					IUrlParserPlugin iplug = (IUrlParserPlugin)plugin;
					iplug.Init(ch);
					UrlParserHttpModule.AddPlugin(iplug);
				}
			}

		}


    }
}
