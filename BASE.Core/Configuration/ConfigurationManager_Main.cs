using System;
using System.Collections.Generic;
using System.Text;

using System.Xml;

namespace BASE.Configuration
{
	/// <summary>
	/// A class that manages BASE's COnfiguration.
	/// </summary>
	public partial class ConfigurationManager
    {
        string _baseConfig;
		internal static ConfigurationManager _current;

		public static ConfigurationManager Current
		{
			get { return ConfigurationManager._current; }
		}
		
		/// <summary>
		/// Internal method for construction of the class for singleton purposes
		/// </summary>
		/// <param name="pathToBASEConfig">The path to the BASE.Config file.</param>
        internal ConfigurationManager(string pathToBASEConfig)
        {
            _baseConfig = pathToBASEConfig;

            XmlDocument doc = new XmlDocument();
            doc.Load(pathToBASEConfig);

			//Loop thru sections in the confg file and pass to a method to handle
			foreach (XmlNode node in doc.DocumentElement.ChildNodes)
			{
				switch (node.Name)
				{
					case "basesettings":
						ParseBaseSettings(node);
						break;

					case "configurationFileHandlers":
						ParseConfigFileHandlers(node);
						break;

					case "urlParserPlugins":
						ParseUrlParserPlugins(node);
						break;

					case "urlSegmentExclusions":
						ParseUrlSegmentExclusions(node);
						break;

					case "endPointPlugins":
						ParseEndPointPlugins(node);
						break;

					case "htmlParserPlugins":
						ParseHtmlParserPlugins(node);
						break;

					case "tagParserPlugins":
						ParseTagParserPlugins(node);
						break;

					case "adminCatagories":
						ParseAdminCatagories(node);
						break;

					default:
						break;
				}
			}



        }
    }
}
