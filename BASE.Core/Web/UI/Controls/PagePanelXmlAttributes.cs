using System;
using System.Collections.Generic;
using System.Text;

namespace BASE.Web.UI.Controls
{
	public static class PagePanelXmlAttributes
	{
		public static readonly string PageMethod = "pageMethod";
		public static readonly string AutoCreate = "autoCreate";
		public static readonly string IsEntryPoint = "isEntryPoint";

		/// <summary>
		/// Gets a string[] array of the required attributes
		/// </summary>
		public static List<string> RequiredAttributes
		{
			get
			{
				List<string> reqAttributes = new List<string>();

				//Add to the list required attributes
				//reqAttributes.Add(PageMethod);
				reqAttributes.Add(AutoCreate);
				reqAttributes.Add(IsEntryPoint);

				return reqAttributes;
			}
		}

	}

}
