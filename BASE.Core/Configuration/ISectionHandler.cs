using System;
using System.Collections.Generic;
using System.Text;

using System.Xml;

namespace BASE.Configuration
{
	/// <summary>
	/// Defines interface for classes that are meant to be Section Handlers for the CoreDefHandler config file handler
	/// </summary>
    public interface ISectionHandler : IInitFromXml
    {
		/// <summary>
		/// Gets the section that the handler handles
		/// </summary>
		string Section { get; }
		/// <summary>
		/// Handles the section of the config file.
		/// </summary>
		/// <param name="sectionToHandle">The section to handle</param>
		/// <param name="file">The file this section came from</param>
		void HandleSection(XmlNode sectionToHandle, string file);

	}
}
