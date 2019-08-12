using System;
using System.Collections.Generic;
using System.Text;

using System.Xml;

using System.Web.UI;

namespace BASE.Web.HtmlParsing
{
	public static class TagParser
	{
		static Dictionary<string, ITagParserPlugin> _plugins;

		static TagParser()
		{
			_plugins = new Dictionary<string, ITagParserPlugin>();
		}

		public static void AddPlugin(ITagParserPlugin plugin)
		{
			_plugins.Add(plugin.Prefix, plugin);
		}

		public static System.Web.UI.Control ParseTag(Page page, HtmlTag tag)
		{
			//Pass off control to the tag plugin
			return _plugins[tag.Prefix].HandleTag(page, tag);
		}

		public static bool TagHandlerExists(XmlElement tag)
		{
			string tagrootName = tag.Name.Split(":".ToCharArray())[0];
			return _plugins.ContainsKey(tagrootName);
		}

		public static bool TagHandlerExists(string tagName)
		{
			return _plugins.ContainsKey(tagName);
		}
	}
}
