using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

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
	/// The ModuleManager class manages all BASE Modules. It is a singleton class.
	/// </summary>
	public class ModuleManager
	{
		//holds the current manager for the system
		private static ModuleManager _currentManager;
		//holds module def's, key is name.
		private Dictionary<string, ModuleDefinition> _moduleDefinitionsByName;

		internal Dictionary<string, Dictionary<string, AdminPanelDefinition>> _adminPanels;

		//Keeps us a singleton
		private ModuleManager()
		{
			_moduleDefinitionsByName = new Dictionary<string, ModuleDefinition>();
			_adminPanels = new Dictionary<string, Dictionary<string, AdminPanelDefinition>>();


			//LoadAllModules();
			Debug.WriteLine("ModuleManager()");

		}

		//Internal because we only initialize once and that is from the system manager
		static internal ModuleManager Initialize()
		{
			//TODO: Possibly add in checking code to make sure no other calss is instantiating this.
			//Check to see if the ModuleManager has been instantiated already. If so, throw exception.
			if (_currentManager != null)
				throw new BASE.BASEGenericException("Module Manager instance already created");

			//Create new instance. This instance is only exposed through the SystemManager.ModuleManager
			_currentManager = new ModuleManager();
			return _currentManager;
		}

		/// <summary>
		/// Adds a module definition.
		/// </summary>
		/// <param name="module">The module Definition to add</param>
		public void Add(ModuleDefinition module)
		{
			//TODO: Add in error checking everywhere
			if (module == null)
				throw new ArgumentNullException("module");

			_moduleDefinitionsByName.Add(module.Name, module);

			//Parse Admin Panels? Just from this newly aded module.
			//loop thru all controls.

			foreach (KeyValuePair<string, BASEControlDefinition> kvp in module._baseControls)
			{
				BASEControlDefinition def = kvp.Value;
				if (def is AdminPanelDefinition)
				{
					AdminPanelDefinition admin = (AdminPanelDefinition)def;
					if (!string.IsNullOrEmpty(admin.CatagoryId))
					{
						_adminPanels[admin.CatagoryId].Add(admin.Name, admin);
					}
				}
			}

			//Check if admin type.
			//if so, add to the admin catagory that it defines.


		}

		/// <summary>
		/// Gets the Dictionary holding the ModuleDefinitions. Keyed by module name.
		/// </summary>
		public Dictionary<string, ModuleDefinition> ModuleDefinitionsByName
		{
			get
			{
				return _moduleDefinitionsByName;
			}
		}

		/// <summary>
		/// Gets the Dictionary holding the ModuleDefinitions. Keyed by module name.
		/// </summary>
		public Dictionary<string, Dictionary<string, AdminPanelDefinition>> AdministrativePanelsByCatagory
		{
			get
			{
				return _adminPanels;
			}
		}

		/// <summary>
		/// Gets the system-wide singleton instance of the ModuleManager
		/// </summary>
		public static ModuleManager Current
		{
			get { return _currentManager; }
		}

		/// <summary>
		/// Loads or Reloads all modules from the default ModuleDefintions Folder
		/// </summary>
		//public void LoadAllModules()
		//{
		//    //internal def list should be created already we only need to clear it.
		//    _moduleDefinitionsByName.Clear();
		//    //Load All Modules
		//    //Get all .def files in folder
		//    string[] files = Directory.GetFiles(SystemManager.ModuleDefinitionFolder, "*.def");
		//    foreach(string file in files)
		//    {
		//        ModuleDefinition def = ModuleDefinition.CreateFromXmlFile(file);
		//        if (def != null)
		//        {
		//            _moduleDefinitionsByName.Add(def.Name, def);
		//        }
		//    }
		//}

		//public void LoadModule()
		//{
		//    throw new System.NotImplementedException();
		//}

		//public void LoadModuleFromLocation(string definitionLocation)
		//{
		//    throw new System.NotImplementedException();
		//}

		//public void UnloadModule(Guid moduleGuid)
		//{
		//    throw new System.NotImplementedException();
		//}

		//public void DisableModule(Guid moduleGuid)
		//{
		//    throw new System.NotImplementedException();
		//}

		//public void EnableModule()
		//{
		//    throw new System.NotImplementedException();
		//}

		//public void GetModuleDefinition(Guid moduleGuid)
		//{
		//    throw new System.NotImplementedException();
		//}

		//public Guid moduleGuid()
		//{
		//    throw new System.NotImplementedException();
		//}

		//public void LoadAllModulesFromLocation(string definitionLocation)
		//{
		//    throw new System.NotImplementedException();
		//}

	}
}
