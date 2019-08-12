using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

using BASE;
using BASE.Modules;
using BASE.Xml;
using BASE.Logging;

namespace BASE.Entities
{
	/// <summary>
	/// A singleton system wide class to manage entites defined for BASE
	/// </summary>
	public class EntityManager
	{

		private static EntityManager _currentManager;

		private Dictionary<Guid, EntityDefinition> _entityDefinitionsByGuid;
		private Dictionary<string, EntityDefinition> _entityDefinitionsByName;
		private Dictionary<string, EntityDefinition> _entityDefinitionsByTableName;

		private EntityManager()
		{
			_entityDefinitionsByGuid = new Dictionary<Guid, EntityDefinition>();
			_entityDefinitionsByName = new Dictionary<string, EntityDefinition>();
			_entityDefinitionsByTableName = new Dictionary<string, EntityDefinition>();

#if DEBUG
			Debug.WriteLine("EtityManager()");
#endif

		}

		/// <summary>
		/// Initilaizes the singleton instance of EntityManager
		/// </summary>
		/// <returns>The system wide singleton entity manager</returns>
		internal static EntityManager Initialize()
		{
			//TODO: Possibly add in checking code to make sure no other calss is instantiating this.
			//Check to see if the ModuleManager has been instantiated already. If so, throw exception.
			if (_currentManager != null)
				throw new BASE.BASEGenericException("Entity Manager instance already created");

			//Create new instance. This instance is only exposed through the SystemManager.ModuleManager
			_currentManager = new EntityManager();
			return _currentManager;

		}

		/// <summary>
		/// Adds an EntityDefinition to the list of definitions.
		/// </summary>
		/// <param name="entityDef"></param>
		public void Add(EntityDefinition entityDef)
		{
            //TODO: Remove this log debug
            Logger.Log("Adding element in the collections: (from EntityManager)", LogPriority.Debug);
            Logger.Log(String.Format("Definition by GUID: {0}", entityDef.Guid.ToString()), LogPriority.Debug);
            Logger.Log(String.Format("Definition by Name: {0}", entityDef.Name.ToString()), LogPriority.Debug);
            Logger.Log(String.Format("Definition by Table Name: {0}", entityDef.TableName.ToString()), LogPriority.Debug);
			_entityDefinitionsByGuid.Add(entityDef.Guid, entityDef);
			_entityDefinitionsByName.Add(entityDef.Name, entityDef);
			_entityDefinitionsByTableName.Add(entityDef.TableName, entityDef);
		}

		/// <summary>
		/// Gets the Guid keyed dictionary list of entity definitions
		/// </summary>
		public Dictionary<Guid, EntityDefinition> EntityDefinitionsByGuid
		{
			get { return _entityDefinitionsByGuid; }
		}

		/// <summary>
		/// Gets the Name keyed dictionary list of entity definitions
		/// </summary>
		public Dictionary<string, EntityDefinition> EntityDefinitionsByName
		{
			get { return _entityDefinitionsByName; }
		}

		/// <summary>
		/// Gets the TableName keyed dictionary list of entity definitions
		/// </summary>
		public Dictionary<string, EntityDefinition> EntityDefinitionsByTableName
		{
			get { return _entityDefinitionsByTableName; }
		}

		/// <summary>
		/// Loads or Reloads all entities from the default EntityDefintions Folder
		/// </summary>
		//internal void LoadAllEntityDefitions()
		//{
		//    //internal def list should be created already we only need to clear it.
		//    _entityDefinitionsByGuid.Clear();
		//    _entityDefinitionsByName.Clear();
		//    _entityDefinitionsByTableName.Clear();
		//    //Load All Modules
		//    //Get all .def files in folder
		//    string[] files = Directory.GetFiles(SystemManager.EntityDefinitionFolder, "*.def");
		//    foreach (string file in files)
		//    {
		//        EntityDefinition def = EntityDefinition.CreateFromXmlFile(file);
		//        if (def != null)
		//        {
		//            _entityDefinitionsByGuid.Add(def.Guid, def);
		//            _entityDefinitionsByName.Add(def.Name, def);
		//            _entityDefinitionsByTableName.Add(def.TableName, def);
		//        }
		//    }
		//}

	}
}
