using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.SessionState;

using BASE.Data;
using BASE.Data.Helpers;
using BASE.Web.UI.Controls;
using BASE.Web.EndPoints;
using BASE.Configuration;
using BASE.Modules;
using BASE.Entities;
using BASE.Web.Sites;

using BASE.Data.LLDAL.DatabaseSpecific;
using BASE.Data.LLDAL.HelperClasses;
using BASE.Data.LLDAL.EntityClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

using System.Xml;

namespace BASE
{
	public sealed partial class SystemManager
	{
			internal Guid _anonymousGuid = new Guid("2866F644-B516-4bd2-B421-1D1B122F5CC7"); //GUID MUST BE SPECIFIED IN BASE.CONFIG
			internal Guid _systemGuid = Guid.Empty; //GUID MUST BE SPECIFIED IN BASE.CONFIG
			internal Guid _ownerGuid = new Guid("3199E044-834E-48d9-9209-6DA80343368B");
			internal string _systemName = "BASE Web System";
			internal bool _isDevelopment = false;
			internal bool _isIntranetOnly = false;
			internal SystemCompilationType _compilationType = SystemCompilationType.Full;
			internal bool _isMultisite = true;
			internal int _defaultSiteUID = 0;
			internal string _physicalRootPath;
			internal bool _enableRemoteLogger = false;
			internal string _remoteLoggerServiceIP = "127.0.0.1";
			internal string _remoteLoggerServicePort = "5417";
			internal string _authCookieName = ".BASEAUTH";
			internal string _salt = "43ythgh87hgosriugho874TITg";
			internal string _pepper = "JHGCj66i676f54I7i67tiugytf";

		private static SystemManager _systemManager;
		private static ModuleManager _moduleManager;
		private static EntityManager _entityManager;
		private static ConfigurationManager _configManager;
		private static EndPointPluginManager _endPointManager;
		private static Dictionary<Guid, SiteManager> _siteManagers;

		private static string _moduleDefFolder;
		private static string _entityDefFolder;

		private static bool _isInitialized = false;
		private static bool _isInitializing = false;
		private static bool _isDefinitionLocationSet = false;

		private XmlDocument _configFile;


		/// <summary>
		/// ctor for System Manager. Private for singlton purposes
		/// </summary>
		private SystemManager()
		{
			//Initialization of system
			_isDefinitionLocationSet = true;
			_physicalRootPath = HttpContext.Current.Request.PhysicalApplicationPath;

			//TODOSOLVED: other application startup processes, caching, etc [THIS WILL BE IN INITIALIZE()]

			Logging.Logger.Log("SystemManager()");

		}

		/// <summary>
		/// Initializes the BASE system. CReates a singleton instance. Will throw exception if already initalized
		/// </summary>
		static public void Initialize()
		{
			//throw an exception if already initialized
			if (_systemManager != null)
				throw new InvalidOperationException("System Manager already initialized");

			_isInitializing = true;
			//Application is starting so create our system manager instance.
			//Initialize System manager
			_systemManager = new SystemManager();
			

			//Create our Entity and Module managers, and EndPoint Managers
			//TODOL: Change Managers to be plugins.
			_entityManager = BASE.Entities.EntityManager.Initialize();
			_moduleManager = BASE.Modules.ModuleManager.Initialize();
			_endPointManager = BASE.Web.EndPoints.EndPointPluginManager.Initialize();

			//Initialize Configuration Manager.
			_configManager = new ConfigurationManager(HttpContext.Current.Server.MapPath(@"~/BASE.config"));
			ConfigurationManager._current = _configManager;

			//TEMPORARY
			//Initialize the List of admin Panel catagories Dictionaries which hold the AdminPanales grouped by Catagory.
			foreach (KeyValuePair<string, string> kvp in Configuration.ConfigurationManager._current._admincatagories)
			{
				_moduleManager._adminPanels.Add(kvp.Key, new Dictionary<string, AdminPanelDefinition>());
			}


			//NEW HANDLE CONFIG FILE
			// Changed by Matt on 08/16/2007 6:26 AM
			// This will loop thru all handlers in a non specific way.
			// Loop thru all config handlers
			foreach (KeyValuePair<string, IConfigurationFileHandler> kvp in _configManager._configFileHandlers)
			{
				//Get the location and extension
				string ext = kvp.Key;
				IConfigurationFileHandler handler = kvp.Value;
				string location = _systemManager._physicalRootPath + kvp.Value.RelativePath;

				//Get all FileS of that extention in that location
				string[] configFiles = Directory.GetFiles(location, "*." + ext, SearchOption.AllDirectories);

				if (configFiles.Length == 0)
				{
					Logging.Logger.Log(string.Format("No config files found in {0} with the extension {1}", location, ext), BASE.Logging.LogPriority.Warning, "SYSTEM");
				}
				else
				{
					//Handle the files
					foreach (string file in configFiles)
					{
						Logging.Logger.Log(string.Format("Loading config file {0}", file), BASE.Logging.LogPriority.Info, "SYSTEM");
						handler.HandleFile(file);
					}
				}


			}

			setBaseConfig();
			//Cache(load) all root sites.
			_siteManagers = new Dictionary<Guid, SiteManager>();
			//DO NOT CACHE ROOT SITES, DO LAZY LOADING
			//LoadRootSites();

			//Set flags that may be used by Managers as they are initialized
			_isInitializing = false;
			_isInitialized = true;
		}

		static void setBaseConfig()
		{

			//private Guid _systemGuid = Guid.Empty; //GUID MUST BE SPECIFIED IN BASE.CONFIG
			//private Guid _ownerGuid = new Guid("3199E044-834E-48d9-9209-6DA80343368B");
			//private string _systemName = "BASE Web System";
			//private bool IsDevelopment = false;
			//private bool _isIntranetOnly = false;
			//private SystemCompilationType _compilationType = SystemCompilationType.Full;
			//private bool _multisite = true;

			if (_configManager._baseSettings.ContainsKey("AnonymousGuid"))
				_systemManager._anonymousGuid = new Guid(_configManager._baseSettings["AnonymousGuid"]);
			else
				Logging.Logger.Log("AnonymousGuid not present!", BASE.Logging.LogPriority.CriticalError, "SYSTEM STARTUP", true);

			if (_configManager._baseSettings.ContainsKey("SystemGuid"))
				_systemManager._systemGuid = new Guid(_configManager._baseSettings["SystemGuid"]);
			else
				Logging.Logger.Log("System GUID not present!", BASE.Logging.LogPriority.CriticalError, "SYSTEM STARTUP", true);

			if (_configManager._baseSettings.ContainsKey("OwnerGuid"))
				_systemManager._ownerGuid = new Guid(_configManager._baseSettings["OwnerGuid"]);

			if (_configManager._baseSettings.ContainsKey("SystemName"))
				_systemManager._systemName = _configManager._baseSettings["SystemName"];

			if (_configManager._baseSettings.ContainsKey("IsDevelopment"))
				_systemManager._isDevelopment = bool.Parse(_configManager._baseSettings["IsDevelopment"]);

			if (_configManager._baseSettings.ContainsKey("IsIntranetOnly"))
				_systemManager._isIntranetOnly = bool.Parse(_configManager._baseSettings["IsIntranetOnly"]);

			if (_configManager._baseSettings.ContainsKey("IsMultiSite"))
				_systemManager._isMultisite = bool.Parse(_configManager._baseSettings["IsMultiSite"]);

			if (_configManager._baseSettings.ContainsKey("DefaultSiteUID"))
				_systemManager._defaultSiteUID = int.Parse(_configManager._baseSettings["DefaultSiteUID"]);

			if (_configManager._baseSettings.ContainsKey("EnableRemoteLogger"))
				_systemManager._enableRemoteLogger = bool.Parse(_configManager._baseSettings["EnableRemoteLogger"]);

			if (_configManager._baseSettings.ContainsKey("RemoteLoggerServiceIP"))
				_systemManager._remoteLoggerServiceIP = _configManager._baseSettings["RemoteLoggerServiceIP"];

			if (_configManager._baseSettings.ContainsKey("RemoteLoggerServicePort"))
				_systemManager._remoteLoggerServicePort = _configManager._baseSettings["RemoteLoggerServicePort"];

			if (_configManager._baseSettings.ContainsKey("AuthCookieName"))
				_systemManager._authCookieName = _configManager._baseSettings["AuthCookieName"];

			if (_configManager._baseSettings.ContainsKey("Salt"))
				_systemManager._salt = _configManager._baseSettings["Salt"];

			if (_configManager._baseSettings.ContainsKey("Pepper"))
				_systemManager._pepper = _configManager._baseSettings["Pepper"];

			//if (_configManager._baseSettings["SystemCompilationType"] != null)
			//    _systemManager._ownerGuid = new Guid(_configManager._baseSettings["SystemCompilationType"]);
		}

		public Guid AnonymousGuid
		{ get { return _anonymousGuid; } }

		public Guid SystemGuid
		{ get { return _systemGuid; } }

		public Guid OwnerGuid
		{ get { return _ownerGuid; } }

		public string SystemName
		{ get { return _systemName; } }

		public bool IsDevelopment
		{ get { return _isDevelopment; } }

		public bool IsIntranetOnly
		{ get { return _isIntranetOnly; } }

		public bool IsMultiSite
		{ get { return _isMultisite; } }

		public int DefaultSiteUID
		{ get { return _defaultSiteUID; } }

		public string AuthCookieName
		{ get { return _authCookieName; } }

		/// <summary>
		/// Gets the current System Wide instance of the System Manager
		/// </summary>
		public static BASE.SystemManager Current
		{
			get
			{
				//Check to see if the mgr has been created already. if not throw an exception as the system manager should be created already by the system itself.
				//TODOSOLVED: test to see if this can just be extended upon the HttpApplication object. [CANNOT BE DONE AS THEY ARE PER REQUEST]
				if (_systemManager == null)
					throw new BASEGenericException("System Manager not Initialized: SystemManager.Current");

				return _systemManager;
			}
		}

		/// <summary>
		/// Gets the Folder that stores module definitions
		/// </summary>
		public static string ModuleDefinitionFolder
		{
			get { return _moduleDefFolder; }
		}

		/// <summary>
		/// Gets the list of SIteManagers loaded
		/// </summary>
		public Dictionary<Guid, SiteManager> SiteManagers
		{
			get { return _siteManagers; }
		}


		//Not used right now
		internal void LoadRootSites()
		{
			//TODO: Look to see if this needs to be optimized. This will be done with lightweight cache objects.
			DataAccessAdapter da = new DataAccessAdapter();

			EntityCollection<SiteEntity> sites = new EntityCollection<SiteEntity>();

			da.FetchEntityCollection(sites, SiteDataHelper.Filters.GetRootSitesPredicate());

			foreach(SiteEntity site in sites)
				_siteManagers.Add(site.SiteGUID, new SiteManager(site));



		}

		/// <summary>
		/// Returns the instance of the system's Module Manager
		/// </summary>
		public ModuleManager ModuleManager
		{
			get { return _moduleManager; }
		}

		/// <summary>
		/// Returns the instance of the system's Entity Manager
		/// </summary>
		public EntityManager EntityManager
		{
			get { return _entityManager; }
		}

		/// <summary>
		/// Returns the instance of the system's Entity Manager
		/// </summary>
		public ConfigurationManager ConfigurationManager
		{
			get { return _configManager; }
		}

		/// <summary>
		/// Returns the instance of the system's Entity Manager
		/// </summary>
		public EndPointPluginManager EndPointManager
		{
			get { return _endPointManager; }
		}

		/// <summary>
		/// Gets a value inidicating if the system has been initialized
		/// </summary>
		public static bool IsInitialized
		{ 
			get { return _isInitialized; } 
		}
	}
}
