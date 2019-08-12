using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

using BASE;
using BASE.Xml;
using BASE.Configuration;
using BASE.Entities;

namespace BASE.Configuration.Definitions
{
	/// <summary>
	/// A SectionHandler for parsing 'Entities' sections in def files
	/// </summary>
	public class EntitiesSectionHandler : ISectionHandler
	{
		/// <summary>
		/// Returns the Section name this Handler handles
		/// </summary>
		public string Section
		{
			get { return "entities"; }
		}

		/// <summary>
		/// Handles the section.
		/// </summary>
		/// <param name="sectionToHandle">XmlNode with the section</param>
		/// <param name="fileName">The file thisnode came from</param>
		public void HandleSection(XmlNode sectionToHandle, string fileName)
		{
			//Loop thru all nodes under entities. Should be entity nodes
			foreach (XmlNode node in sectionToHandle)
			{
				//make sure the subsections are only entity sections
				//TODO: Make this only LOG at a later time
				if (node.Name != "entity")
					throw new XmlDefinitionParsingException("invalid section in entity section", fileName);

				//Create an entity def.
				EntityDefinition entDef = new EntityDefinition(node, fileName);
				//Add to collection
				if(!entDef.DoNotLoad)
					SystemManager.Current.EntityManager.Add(entDef);

			}
		}

		/// <summary>
		/// Initializes this Section Handler
		/// </summary>
		/// <param name="sectionHanlderDefNode"></param>
		public void Init(XmlNode sectionHanlderDefNode)
		{
			//Nothing to do here
			return;
		}

	}
}
