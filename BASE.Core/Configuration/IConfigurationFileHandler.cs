using System;
using System.Collections.Generic;
using System.Text;

using System.Xml;


namespace BASE.Configuration
{
	/// <summary>
	/// Defines the interface BASE requires for classes that are meant to load configuration files.
	/// </summary>
    public interface IConfigurationFileHandler : IInitFromXml
    {
		/// <summary>
		/// The extension to handle
		/// </summary>
		string Extension { get; }
		/// <summary>
		/// The path where the files are located, relative from BASE Web Root folder.
		/// </summary>
		string RelativePath { get; }
		/// <summary>
		/// Handles the file.
		/// </summary>
		/// <param name="fileToHandle">The path to the file to handle</param>
		void HandleFile(string fileToHandle);


    }
}
