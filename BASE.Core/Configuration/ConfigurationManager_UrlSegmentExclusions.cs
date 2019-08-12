
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
		internal Dictionary<string, UrlSegmentExclusion> _exclusions = new Dictionary<string, UrlSegmentExclusion>();
		/// <summary>
		/// This method parses the 'urlParserPlugins' section of the BASE.config file.
		/// You can add/remove/modify plugins to change and/or expand BASE's UrlParsing system
		/// </summary>
		/// <param name="xmlnode"></param>
		public void ParseUrlSegmentExclusions(XmlNode xmlnode)
		{
			foreach (XmlNode ch in xmlnode.ChildNodes)
			{
				if (ch.Name == "add")
				{
					string name = ch.Attributes["name"].Value.ToLower();
					bool root = XmlConvert.ToBoolean(ch.Attributes["root"].Value);
					bool sub = XmlConvert.ToBoolean(ch.Attributes["sub"].Value);
					_exclusions.Add(name, new UrlSegmentExclusion(name, root, sub));
				}
				else if (ch.Name == "remove")
				{
					_exclusions.Remove(ch.Attributes["name"].Value.ToLower());
				}
				else if (ch.Name == "clear")
				{
					_exclusions.Clear();
				}
				else
				{
					Logging.Logger.Log(String.Format("Unkown node in BASE.config/basesettings: {0}", ch.Name), BASE.Logging.LogPriority.Warning, "CONFIGURATION");
				}

			}

		}

		public bool IsRootExclusion(string name)
		{
			UrlSegmentExclusion exc = GetExclusion(name);
			return exc == null ? false : exc.Root;
		}

		public bool IsSubExclusion(string name)
		{
			UrlSegmentExclusion exc = GetExclusion(name);
			return exc == null ? false : exc.Sub;
		}

		/// <summary>
		/// Reteives an exclusion declared in BASE.config
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public UrlSegmentExclusion GetExclusion(string name)
		{
			string namelow = name.ToLower();
			if(_exclusions.ContainsKey(namelow))
			{
				return _exclusions[namelow];
			}

			return null;
		}


		public Dictionary<string, UrlSegmentExclusion> UrlSegmentExclusions
		{
			get { return _exclusions; }
		}


	}
}
