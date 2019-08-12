using System;
using System.Collections.Generic;
using System.Text;

namespace BASE.Xml
{
	/// <summary>
	/// DefinitionBaseXmlAttributes is a static class that holds string values for all definition type Nodes in an xml file.
	/// </summary>
	public static class DefinitionBaseXmlAttributes
	{
		/// <summary>
		/// String value for DoNotLoad. Causes the item to not load.
		/// </summary>
		public static readonly string DoNotLoad = "doNotLoad";
		/// <summary>
		/// String value for Name. Represents the name of the item
		/// </summary>
		public static readonly string Name = "name";
		/// <summary>
		/// String value for Description. Describes the item.
		/// </summary>
		public static readonly string Description = "description";

		/// <summary>
		/// Gets a string[] array of the required attributes
		/// </summary>
		public static List<string> RequiredAttributes
		{
			get
			{
				List<string> reqAttributes = new List<string>();

				//Add to the list required attributes
				reqAttributes.Add(Name);

				return reqAttributes;
			}
		}

	}
}
