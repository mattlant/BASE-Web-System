using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

using BASE;
using BASE.Xml;
using BASE.Configuration;
using BASE.Modules;

namespace BASE.Configuration.Definitions
{
	/// <summary>
	/// A SectionHandler for parsing 'modules' sections in def files
	/// </summary>
	public class ModulesSectionHandler : ISectionHandler
	{

		/// <summary>
		/// Returns the Section name this Handler handles
		/// </summary>
		public string Section
		{
			get { return "modules"; }
		}

		/// <summary>
		/// Handles the section.
		/// </summary>
		/// <param name="sectionToHandle">XmlNode with the section</param>
		/// <param name="fileName">The file this node came from</param>
		public void HandleSection(XmlNode sectionToHandle, string fileName)
		{
			foreach (XmlNode node in sectionToHandle)
			{
				//make sure the subsections are only module sections
				//TODO: Make this only LOG at a later time
				if (node.Name != "module")
					throw new XmlDefinitionParsingException("invalid section in modules section", fileName);

				//CReate def and add.
				ModuleDefinition modDef = new ModuleDefinition(node, fileName);
				SystemManager.Current.ModuleManager.Add(modDef);
			}
		}

		/// <summary>
		/// Initializes this Section Handler
		/// </summary>
		/// <param name="sectionHanlderDefNode">The XmlNode of the section handler definition</param>
		public void Init(XmlNode sectionHanlderDefNode)
		{
			//Nothing to do here
			return;
		}

	}
}
