using System;
using System.Collections.Generic;
using System.Text;

using BASE.Xml;

namespace BASE.Modules
{
	public static class ModuleXmlAttributes
	{
		public static readonly string DoNotLoad = DefinitionBaseXmlAttributes.DoNotLoad;
		public static readonly string Name = DefinitionBaseXmlAttributes.Name;
		public static readonly string Description = DefinitionBaseXmlAttributes.Description;
		public static readonly string Author = "author";
		public static readonly string Location = "location";

		/// <summary>
		/// Gets a string[] array of the required attributes
		/// </summary>
		public static string[] RequiredAttributes
		{
			get
			{
				//ALWAYS REMEMBER TO ADJUST LENGTH!!!

				string[] reqAttributes = new string[0];

				//Add to the list required attributes

				return reqAttributes;
			}
		}

	}
}
