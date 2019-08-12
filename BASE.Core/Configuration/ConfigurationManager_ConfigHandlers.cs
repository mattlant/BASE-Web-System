using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

using BASE.Reflection;

namespace BASE.Configuration
{
    public partial class ConfigurationManager
    {
		internal Dictionary<string, IConfigurationFileHandler> _configFileHandlers;

		//Parses and loads any Config File Handlers defined in BASE.config
		internal void ParseConfigFileHandlers(XmlNode confHandnode)
		{
			_configFileHandlers = new Dictionary<string,IConfigurationFileHandler>();

			foreach (XmlNode ch in confHandnode.ChildNodes)
			{
				if (ch.Name != "configurationFileHandler") continue;

				string ext = ch.Attributes["extension"].Value;
				string type = ch.Attributes["type"].Value;

				object handler = TypeHelper.CreateTypeFromConfigString(type);
				if (handler is IConfigurationFileHandler)
				{
					IConfigurationFileHandler ihand = (IConfigurationFileHandler)handler;
					ihand.Init(ch);
					_configFileHandlers.Add(ext, ihand);
				}
			}

		}

		//retreives the config file handler for the given extension
		internal IConfigurationFileHandler GetConfigurationFileHandler(string extension)
		{
			return _configFileHandlers[extension];
		}
    }
}
