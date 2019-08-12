using System;
using System.Collections.Generic;
using System.Text;

using System.Text.RegularExpressions;

namespace BASE.Web
{
	public static class WebUtils
	{
		public static class QS
		{
			public static int ToInt32ElseMin(string int32)
			{
				int toReturn = 0;
				if (!Int32.TryParse(int32, out toReturn))
					toReturn = int.MinValue;
				return toReturn;
			}

			public static byte ToByteElseMin(string byte8)
			{
				byte toReturn = 0;
				if (!byte.TryParse(byte8, out toReturn))
					toReturn = byte.MinValue;
				return toReturn;
			}

			public static char ToInt16ElseMin(string char16)
			{
				char toReturn;
				if (!char.TryParse(char16, out toReturn))
					toReturn = char.MinValue;
				return toReturn;
			}

			//Private RegEx used for ToGuidElseEmpty method
			private static Regex isGuid = new Regex(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", RegexOptions.Compiled);
			/// <summary>
			/// Converts the passed string to its Guid equivelant. If empty or invalid, will return an empty Guid.
			/// </summary>
			/// <param name="guid">The string version of the Guid to convert</param>
			/// <returns>Returns the Guid equivelant of the string, or an empty Guid if invalid, null, or empty.</returns>
			public static Guid ToGuidElseEmpty(string guid)
			{
				//Chekc for match, if so, return the Guid, otherwise, return empty
				return (!string.IsNullOrEmpty(guid) && isGuid.IsMatch(guid)) ? new Guid(guid) : Guid.Empty;
			}
		}

	}
}
