using System;
using System.Collections.Generic;
using System.Text;

using System.Xml;

namespace BASE
{
	/// <summary>
	/// This interface defines any class that initialized based on an XmlNode.
	/// </summary>
	public interface IInitFromXml
	{
		/// <summary>
		/// When implemented, initializes the class, optionally using the XmlNode
		/// </summary>
		/// <param name="xmlNode">An XmlNode that holds initialization info</param>
		void Init(XmlNode xmlNode);
	}
}
