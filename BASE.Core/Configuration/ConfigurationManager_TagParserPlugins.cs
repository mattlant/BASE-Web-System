using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using BASE.Reflection;
using BASE.Web.HtmlParsing;

namespace BASE.Configuration
{
	public partial class ConfigurationManager
    {
		/// <summary>
		/// Parses TagHandlers defined in BASE.Config
		/// </summary>
		/// <param name="tagHandnode"></param>
		internal void ParseTagParserPlugins(XmlNode tagHandnode)
		{
			foreach (XmlNode ch in tagHandnode.ChildNodes)
			{
				if (ch.Name != "tagParserPlugin") continue;

				string prefix = ch.Attributes["prefix"].Value;
				string type = ch.Attributes["type"].Value;

				object plugin = TypeHelper.CreateTypeFromConfigString(type);
				if (plugin is ITagParserPlugin)
				{
					ITagParserPlugin iplug = (ITagParserPlugin)plugin;
					iplug.Init(ch);
					TagParser.AddPlugin(iplug);
				}
			}

		}

    }
}
