using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml;

using BASE;
using BASE.Reflection;
using BASE.Xml;

namespace BASE.Configuration
{
	/// <summary>
	/// Handler for handling definition files of the type 'def'
	/// </summary>
	public class CoreDefHandler : IConfigurationFileHandler
	{
		string _extension = "def";
		string _relativePath;

		//HOLD SECTION HANDLERS. Section handlers can be added.
		Dictionary<string, ISectionHandler> _sectionHandlers;
		#region IConfigurationFileHandler Members

		/// <summary>
		/// Gets the file extension this handler handles
		/// </summary>
		public string Extension
		{
			get { return _extension; }
		}

		/// <summary>
		/// Gets the relative path under BASE Web Root of module definition files.
		/// </summary>
		public string RelativePath
		{
			get { return _relativePath; }
		}

		/// <summary>
		/// Handles the file.
		/// </summary>
		/// <param name="fileToHandle"></param>
		public void HandleFile(string fileToHandle)
		{
			//Check to make sure the files are correct and exist
			if (!fileToHandle.EndsWith(".def"))
				throw new XmlDefinitionParsingException("Invalid file format", fileToHandle);
			if (!File.Exists(fileToHandle))
				throw new FileNotFoundException("def file not found", fileToHandle);

			//Load the xml document
			XmlDocument doc = new XmlDocument();
			doc.Load(fileToHandle);

			//Go through each section and call the registered handler
			foreach (XmlNode node in doc.DocumentElement.ChildNodes)
			{
				string sectionName = node.Name;
				//Make sure this section has a handler installed, if not, log and ignore
				if (!_sectionHandlers.ContainsKey(sectionName))
				{
					Logging.Logger.Log("Unknown Node[" + sectionName + "] in file: " + fileToHandle, BASE.Logging.LogPriority.Debug);
					continue;
				}

				//Section has a registered handler, so Handle it
				ISectionHandler sectionHandler = _sectionHandlers[sectionName];
				sectionHandler.HandleSection(node, fileToHandle);
			}
		}

		/// <summary>
		/// Initializes this config file handler
		/// </summary>
		/// <param name="configHanlderDefNode">The BASE.Config file node that defines this handler</param>
		public void Init(XmlNode configHanlderDefNode)
		{
			//Setup section handlers
			_sectionHandlers = new Dictionary<string, ISectionHandler>();

			_extension = configHanlderDefNode.Attributes["extension"].Value;
			_relativePath = configHanlderDefNode.Attributes["relativePath"].Value;


			//Loop thru section handlers and load.
			foreach (XmlNode ch in configHanlderDefNode.ChildNodes)
			{
				if (ch.Name != "sectionHandler") continue;

				string section = ch.Attributes["section"].Value;
				string type = ch.Attributes["type"].Value;

				//CReate the SectionHandlers defined
				object handler = TypeHelper.CreateTypeFromConfigString(type);
				if (handler is ISectionHandler)
				{
					//Initia;lize them and add them to the list of section handlers
					ISectionHandler ihand = (ISectionHandler)handler;
					ihand.Init(ch);
					_sectionHandlers.Add(section, ihand);
				}
			}
		}

		#endregion
	}
}
