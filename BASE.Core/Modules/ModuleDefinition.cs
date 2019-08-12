using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

using System.Xml;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BASE.Entities;
using BASE.Xml;
using BASE.Web;
using BASE.Web.UI;
using BASE.Web.UI.Controls;

namespace BASE.Modules
{
	/// <summary>
	/// Defines a module in BASE
	/// </summary>
	public class ModuleDefinition : XmlDefinitionBase
	{
		private string _author = "";
		private string _location = "";

		private List<Guid> _installedEntitiesGuidList = new List<Guid>();
		private List<Guid> _entityDependenciesGuidList = new List<Guid>();
		private List<Guid> _moduleDependanciesGuidList = new List<Guid>();

		private Dictionary<string, string> _connectionStrings = new Dictionary<string, string>();

		internal Dictionary<string, BASEControlDefinition> _baseControls = new Dictionary<string, BASEControlDefinition>();

		/// <summary>
		/// Initializes a new ModuleDefinition instance
		/// </summary>
		/// <param name="moduleNode">The XmlNode of the module</param>
		/// <param name="fromFile">The def file that this module is defined in</param>
		public ModuleDefinition(XmlNode moduleNode, string fromFile)
			: base(moduleNode, fromFile)
		{
			if (_doNotLoad) return;

			//*** Initialization ***

			try
			{
				//Get the 'Module' root element and Parse it
				_author = moduleNode.Attributes[ModuleXmlAttributes.Author] == null ? "" : moduleNode.Attributes[ModuleXmlAttributes.Author].Value;
				_location = moduleNode.Attributes[ModuleXmlAttributes.Location] == null ? "" : moduleNode.Attributes[ModuleXmlAttributes.Location].Value;

			}
			catch (XmlDefinitionParsingException ex)
			{
#if DEBUG
				Logging.Logger.Log("************ BASEModuleDefinitionParsingException Caught ************");
				Logging.Logger.Log(ex.ToString());
				_doNotLoad = true;
				throw;
#endif
			}
			catch (Exception ex)
			{
#if DEBUG
				Logging.Logger.Log("************ Exception Caught ************");
				Logging.Logger.Log(ex.ToString());
				_doNotLoad = true;
				throw;
#endif
			}
#if DEBUG
			Debug.WriteLine("ModuleDef Loaded: " + fromFile);
#endif
			Logging.Logger.Log(string.Format("Module Loaded Name:{0} filename:{1}", this.Name, fromFile), BASE.Logging.LogPriority.Debug, "MODULEINIT");

		}

		/// <summary>
		/// Gtes the Author of the module
		/// </summary>
		public string Author
		{
			get
			{
				return _author;
			}
		}

		/// <summary>
		/// Gtes the Location of the module
		/// </summary>
		public string Location
		{
			get
			{
				return _location;
			}
		}

		/// <summary>
		/// Gets the set of connection strings as defined in the Module Definition
		/// </summary>
		public Dictionary<string, string> ConnectionStrings
		{
			get
			{
				return _connectionStrings;
			}
		}

		//Checks to make sure there are no attributes missing in the definition that are required
		protected override bool IsMissingAttributes(XmlNode node, List<string> attrToCheck, ref string missingAttr)
		{
			//Add in Module attributes to the required list
			attrToCheck.AddRange(ModuleXmlAttributes.RequiredAttributes);
			return base.IsMissingAttributes(node, attrToCheck, ref missingAttr);
		}
		
		#region Child Node Parsing
		protected override void ParseChildNodes(XmlNode node, string fromFile)
		{
			if (node == null)
				return;

			switch (node.Name)
			{
				case "installedEntities":
					ParseInstalledEntites(node);
					break;

				case "entityDependencies":
					ParseEntityDependancies(node);
					break;

				case "moduleDependancies":
					ParseModuleDependancies(node);
					break;

				case "connectionStrings":
					ParseConnectionStrings(node);
					break;

				case "appSettings":
					ParseAppSettings(node);
					break;

				case "pagePanels":
					ParsePagePanels(node, fromFile);
					break;

				case "adminPanels":
					ParseAdminPanels(node, fromFile);
					break;

				case "htmlSnippets":
					ParseHtmlSnipets(node, fromFile);
					break;

				case "widgets":
					ParseWidgets(node, fromFile);
					break;

				case "composites":
					ParseComposites(node, fromFile);
					break;

				case "customControls":
					ParseCustomControls(node, fromFile);
					break;

				case "endPoints":
					ParseEndPoints(node, fromFile);
					break;

				case "httpHandlers":
					ParseHttpHandlers(node, fromFile);
					break;

				case "httpModules":
					ParseHttpModules(node, fromFile);
					break;

				case "webServices":
					ParseWebServices(node, fromFile);
					break;

				case "moduleApi":
					ParseModuleApi(node, fromFile);
					break;

				default:
					//***Unrecognized***
					break;
			}
		}

		protected virtual void ParseInstalledEntites(XmlNode node)
		{
			foreach (XmlNode n in node.ChildNodes)
			{
				_installedEntitiesGuidList.Add(XmlConvert.ToGuid(n.Attributes[DependancyXmlAttributes.Guid].Value));
			}


		}

		protected virtual void ParseEntityDependancies(XmlNode node)
		{
			foreach (XmlNode n in node.ChildNodes)
			{
				_entityDependenciesGuidList.Add(XmlConvert.ToGuid(n.Attributes[DependancyXmlAttributes.Guid].Value));
			}
		}

		protected virtual void ParseModuleDependancies(XmlNode node)
		{
			foreach (XmlNode n in node.ChildNodes)
			{
				_moduleDependanciesGuidList.Add(XmlConvert.ToGuid(n.Attributes[DependancyXmlAttributes.Guid].Value));
			}
		}

		protected virtual void ParseConnectionStrings(XmlNode node)
		{
			foreach (XmlNode n in node.ChildNodes)
			{
				_connectionStrings.Add(n.Attributes["name"].Value, n.Attributes["connectionString"].Value);// <add name="myconnectionstring" connectionString="Database=mlcsrv1, blah blah blah" />    // myDef.ConnectionStrings["myconnectionstring"] //SystemManager.Current.ModuleManager.ModuleDefintionsByName["Users"] //dataAccessAdapter da = someClass.GetMyAdapter();
			}
		}

		protected virtual void ParseAppSettings(XmlNode node)
		{
			foreach (XmlNode n in node.ChildNodes)
			{
				//Do something with them
			}
		}

		protected virtual void ParsePagePanels(XmlNode node, string fromFile)
		{
			foreach (XmlNode n in node.ChildNodes)
				this.AddBaseControlDef(new PagePanelDefinition(n, fromFile, this.Name));
		}

		protected virtual void ParseAdminPanels(XmlNode node, string fromFile)
		{
			foreach (XmlNode n in node.ChildNodes)
				this.AddBaseControlDef(new AdminPanelDefinition(n, fromFile, this.Name));
		}

		protected virtual void ParseHtmlSnipets(XmlNode node, string fromFile)
		{
			foreach (XmlNode n in node.ChildNodes)
				this.AddBaseControlDef(new HtmlSnippetDefinition(n, fromFile, this.Name));
		}

		protected virtual void ParseWidgets(XmlNode node, string fromFile)
		{
			foreach (XmlNode n in node.ChildNodes)
				this.AddBaseControlDef(new WidgetDefinition(n, fromFile, this.Name));
		}

		protected virtual void ParseComposites(XmlNode node, string fromFile)
		{
			foreach (XmlNode n in node.ChildNodes)
			{
				//Composite Def still to be completed
				//TODO: Add in Composite Instancing and add to Dictionary
			}
		}

		protected virtual void ParseCustomControls(XmlNode node, string fromFile)
		{
			foreach (XmlNode n in node.ChildNodes)
			{
				//Composite Def still to be completed
				//TODO: Add in Composite Instancing and add to Dictionary
			}
		}

		protected virtual void ParseEndPoints(XmlNode node, string fromFile)
		{
			foreach (XmlNode n in node.ChildNodes)
			{
				//TODO: Add in Page Instancing and add to Dictionary
			}
		}

		protected virtual void ParseHttpHandlers(XmlNode node, string fromFile)
		{
			foreach (XmlNode n in node.ChildNodes)
			{
				//TODO: Add in Httphandler Instancing and add to Dictionary
			}
		}

		protected virtual void ParseHttpModules(XmlNode node, string fromFile)
		{
			foreach (XmlNode n in node.ChildNodes)
			{
				//TODO: Add in httpModule Instancing and add to Dictionary
			}
		}

		protected virtual void ParseWebServices(XmlNode node, string fromFile)
		{
			foreach (XmlNode n in node.ChildNodes)
			{
				//TODO: Add in WebService Instancing and add to Dictionary
			}
		}

		protected virtual void ParseModuleApi(XmlNode node, string fromFile)
		{
			foreach (XmlNode n in node.ChildNodes)
			{
				//TODO: Add in WebService Instancing and add to Dictionary
			}
		}
		//Adds a BASE ControlDefiniton into this modules COntrolDef list
		protected virtual void AddBaseControlDef(BASEControlDefinition def)
		{
			string name = def.Name;
			if (_baseControls.ContainsKey(name))
			{
				//TODO: LOG THIS
				Logging.Logger.Log(String.Format("The name '{0}' of type '{1}' already exists in the control collection", name, def.GetType().ToString()));
				throw new BASE.Xml.XmlDefinitionParsingException(String.Format("The name '{0}' of type '{1}' already exists in the control collection", name, def.GetType().ToString()));
				return;
			}

			_baseControls.Add(name, def);
		}


		/// <summary>
		/// Gets a BASEControlDefinition.
		/// </summary>
		/// <param name="name">The name of the Control Defintion to retreive</param>
		/// <returns>A BASEControlDefinition</returns>
		public virtual BASEControlDefinition GetControlDefByName(string name)
		{
			return _baseControls[name];
		}

		#endregion
	}
}
