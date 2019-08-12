using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

using BASE.Reflection;
using BASE.Web.EndPoints;

namespace BASE.Configuration
{
	public partial class ConfigurationManager
    {
		List<IEndPointPlugin> _endPointPlugins;

		/// <summary>
		/// This method parses the 'EndPointsPlugins' section of the BASE.config file.
		/// You can add/remove/modify plugins to change and/or expand BASE's EndPoint system
		/// </summary>
		/// <param name="xmlnode"></param>
		internal void ParseEndPointPlugins(XmlNode xmlnode)
		{
			_endPointPlugins = new List<IEndPointPlugin>();

			foreach (XmlNode ch in xmlnode.ChildNodes)
			{
				if (ch.Name != "endPointPlugin") continue;

				string name = ch.Attributes["name"].Value;
				string type = ch.Attributes["type"].Value;

				object plugin = TypeHelper.CreateTypeFromConfigString(type);
				if (plugin is IEndPointPlugin)
				{
					IEndPointPlugin iplug = (IEndPointPlugin)plugin;
					iplug.Init(EndPointPluginManager.Current);
					_endPointPlugins.Add(iplug);
				}
			}

		}

		internal List<IEndPointPlugin> EndPointPlugins
		{
			get { return _endPointPlugins; }
		}


    }
}
