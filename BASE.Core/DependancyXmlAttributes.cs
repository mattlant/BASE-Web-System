using System;
using System.Collections.Generic;
using System.Text;

namespace BASE.Modules
{
	/// <summary>
	/// DependancyXmlAttributes is a static class that holds string values for Dependancy Nodes in an xml file.
	/// </summary>
	public static class DependancyXmlAttributes
	{
		/// <summary>
		/// The string name of the Guid attribute
		/// </summary>
		public static readonly string Guid = "guid";

		/// <summary>
		/// Gets a string[] array of the required attributes
		/// </summary>
		public static string[] RequiredAttributes
		{
			get
			{
				//ALWAYS REMEMBER TO ADJUST LENGTH!!!
				string[] reqAttributes = new string[1];

				//Add to the list required attributes
				reqAttributes[0] = Guid;

				return reqAttributes;
			}
		}
	}
}
