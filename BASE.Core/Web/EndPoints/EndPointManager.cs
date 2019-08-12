using System;
using System.Collections.Generic;
using System.Text;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BASE.Web;
using BASE.Web;

namespace BASE.Web.EndPoints
{
    /// <summary>
    /// This class is used to manage EndPoint with it respective PluginManager using a Dictionnary Type list.
    /// </summary>
	public class EndPointPluginManager
	{

		public Dictionary<string, IEndPointPlugin> _endPointPlugins = new Dictionary<string, IEndPointPlugin>();

		private static EndPointPluginManager _currentEndPointManager;

        /// <summary>
        /// Default Constructor of EndPointPluginManager
        /// </summary>
        private EndPointPluginManager()
		{

		}

        /// <summary>
        /// This method is used to create a unique singleton instance of the EndPoint Plugin Manager.
        /// </summary>
        /// <returns>The unique singleton EndPointPluginManager class reference.</returns>
		internal static EndPointPluginManager Initialize()
		{
			//TODO: Possibly add in checking code to make sure no other calss is instantiating this.
			//Check to see if the ModuleManager has been instantiated already. If so, throw exception.
			if (_currentEndPointManager != null)
				throw new BASE.BASEGenericException("EndPoint Manager instance already created");

			//Create new instance. This instance is only exposed through the SystemManager.ModuleManager
			_currentEndPointManager = new EndPointPluginManager();
			return _currentEndPointManager;

		}

        /// <summary>
        /// This method is used to get the concurrent version of the EndPoint Plugin Manager
        /// </summary>
		internal static EndPointPluginManager Current
		{
			get { return _currentEndPointManager; }
		}





	}
}
