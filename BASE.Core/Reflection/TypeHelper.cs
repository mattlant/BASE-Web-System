using System;
using System.Collections.Generic;
using System.Text;

using System.Web;
namespace BASE.Reflection
{
	/// <summary>
	/// Static class to help in creating and managing external assemblies and the classes they define
	/// </summary>
	public static class TypeHelper
	{
		/// <summary>
		/// Creates an instance of the given type and returns a reference to it.
		/// </summary>
		/// <param name="typeString">A string of the type and assembly to load it from</param>
		/// <returns>An object reference of the type created.</returns>
		public static object CreateTypeFromConfigString(string typeString)
		{
			//Split the string to get the type and the assembly(dll) name
			string[] typeAssemb = typeString.Split(",".ToCharArray());

			string type = typeAssemb[0].Trim();
			string assembly = typeAssemb[1].Trim();

			//Create the object
			//TODO: Wrap in a try-catch
			object obj = AppDomain.CurrentDomain.CreateInstanceFromAndUnwrap(HttpContext.Current.Request.PhysicalApplicationPath + @"bin\" + assembly + ".dll", type);

			return obj;
		}
	}
}
