
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

using BASE.Collections;
using BASE.Reflection;
using BASE.Web.UrlParsing;

namespace BASE.Configuration
{
	public partial class ConfigurationManager
    {
		internal KeyValueCollection _baseSettings = new KeyValueCollection();
		/// <summary>
		/// This method parses the 'urlParserPlugins' section of the BASE.config file.
		/// You can add/remove/modify plugins to change and/or expand BASE's UrlParsing system
		/// </summary>
		/// <param name="xmlnode"></param>
		internal void ParseBaseSettings(XmlNode xmlnode)
		{
			foreach (XmlNode ch in xmlnode.ChildNodes)
			{
				if(ch.Name == "add")
				{
					_baseSettings.Add(ch.Attributes["key"].Value, ch.Attributes["value"].Value);
				}
				else if(ch.Name == "remove")
				{
					_baseSettings.Remove(ch.Attributes["key"].Value);
				}
				else if (ch.Name == "clear")
				{
					_baseSettings.Clear();
				}
				else
				{
					Logging.Logger.Log(String.Format("Unkown node in BASE.config/basesettings: {0}", ch.Name), BASE.Logging.LogPriority.Warning, "CONFIGURATION");
				}

			}

		}

		public string this[string key]
		{
			get { return _baseSettings[key]; }
		}



    }
}
