
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

using BASE.Web.UI.Controls;
using BASE.Collections;
using BASE.Reflection;
using BASE.Web.UrlParsing;

namespace BASE.Configuration
{
	public partial class ConfigurationManager
	{
		internal KeyValueCollection _admincatagories = new KeyValueCollection();


		/// <summary>
		/// This method parses the 'adminCatagories' section of the BASE.config file.
		/// You can add/remove/modify catagories to change and/or expand BASE's admin catagories for the backend site admin
		/// </summary>
		/// <param name="xmlnode"></param>
		internal void ParseAdminCatagories(XmlNode xmlnode)
		{
			foreach (XmlNode ch in xmlnode.ChildNodes)
			{
				if (ch.Name == "add")
				{
					_admincatagories.Add(ch.Attributes["id"].Value, ch.Attributes["displayName"].Value);
				}
				else if (ch.Name == "remove")
				{
					_admincatagories.Remove(ch.Attributes["id"].Value);
				}
				else if (ch.Name == "clear")
				{
					_admincatagories.Clear();
				}
				else
				{
					Logging.Logger.Log(String.Format("Unkown node in BASE.config/adminCatagories: {0}", ch.Name), BASE.Logging.LogPriority.Warning, "CONFIGURATION");
				}

			}

		}

		public string GetAdminCatagory(string id)
		{
			return _admincatagories[id];
		}

		public KeyValueCollection AdministrativeCatagories
		{
			get { return _admincatagories; }
		}



	}
}
