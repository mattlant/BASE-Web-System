using System;
using System.Collections.Generic;
using System.Text;

namespace BASE.Web.UI.Controls
{
	public class AdminPanelXmlAttributes
	{
		public static readonly string CatagoryId = "catagoryId";
		public static readonly string DisplayName = "displayName";

		/// <summary>
		/// Gets a string[] array of the required attributes
		/// </summary>
		public static List<string> RequiredAttributes
		{
			get
			{
				List<string> reqAttributes = new List<string>();

				//Add to the list required attributes
				//NONE 

				return reqAttributes;
			}
		}
	}
}
