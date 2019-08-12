using System;
using System.Collections.Generic;
using System.Text;

using BASE.Xml;

namespace BASE.Web.UI.Controls
{
	public static class BASEUserControlDefinitionXmlAttributes
	{
		public static readonly string AscxFile = "ascxFile";
		public static readonly string SubFolder = "subFolder";

		//TODO: If i create a property RequiredAttributes I could then recurse all attributes and check if required.

		/// <summary>
		/// Gets a string[] array of the required attributes
		/// </summary>
		public static List<string> RequiredAttributes
		{
			get
			{
				List<string> reqAttributes = new List<string>();

				//Add to the list required attributes
				reqAttributes.Add(AscxFile);

				return reqAttributes;
			}
		}

	}
}
