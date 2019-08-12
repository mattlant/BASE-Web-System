using System;
using System.Collections.Generic;
using System.Text;

using System.Xml;

namespace BASE.Xml
{
	/// <summary>
	/// Static class for helping in processing Xml information
	/// </summary>
	public static class XmlHelper
	{
		/// <summary>
		/// This method will check the Xml Node for missing attributes as defined in the supplied list.
		/// </summary>
		/// <param name="node">The Xml Node to check.</param>
		/// <param name="attributeList">The string List of attributes to check.</param>
		/// <returns>A comma delimited string of missing attributes if any are missing, otherwise null.</returns>
		public static string CheckRequiredAttributes(XmlNode node, List<string> attributeList)
		{
			string missingAttr = "";

            // added by steve to make sure the attribute list isnt null..
            if (attributeList != null && node.Attributes != null)
            {
                //Cycle through all attributes provided and see if they exist
                for (int i = 0; i < attributeList.Count; i++)
                {
                    if (node.Attributes[attributeList[i]] == null)
                        missingAttr += attributeList[i] + ",";
                }

                //We made it this far, so return true indicating we have all required attributes
                if (missingAttr == "")
                    return null;

                //return the missing attribute string minus the trailing ','
                return missingAttr.Substring(0, missingAttr.Length - 1);
            }
            else
            {
                throw new Exception("The attribute List in the XmlHelper:CheckRequiredAttributes is null!");
            }
		}

		/// <summary>
		/// Internal method to get a Dictionary of Custom Settings in XMl Definition files in base
		/// </summary>
		/// <param name="node">The CustomSettings Node to parse</param>
		/// <returns>A string,string Dictionary with the key and values of cusrtom settings</returns>
		internal static Dictionary<string, string> GetCustomSettings(XmlNode node)
		{
			// if node is null, pass back the empty dict
			Dictionary<string, string> temp = new Dictionary<string, string>();
			if (node == null) return temp;

			//Add in all child nodes
			foreach (XmlNode cnode in node.ChildNodes)
			{
				//TODO: Add in checks AND !!!LOGGING!!! for this key/value atrtibute name is correct, else it bombs.

				//Check for any remove directives
				if (cnode.Name == "remove")
				{
					temp.Remove(cnode.Attributes["Key"].Value);
					continue;
				}

				//make sure that we only parse add directives from this point
				if (cnode.Name != "add")
					continue;

				//Get the key and value pair
				string key = cnode.Attributes["Key"].Value;
				string value = cnode.Attributes["Value"].Value;

				//If either ar enull its an invalid directive
				//TODO: Add in some sort of logging
				if (key == null || value == null)
					continue;

				//Add them to the custom settings Dictionary
				temp.Add(cnode.Attributes["Key"].Value, cnode.Attributes["Value"].Value);
			}
			return temp;
		}

	}
}
