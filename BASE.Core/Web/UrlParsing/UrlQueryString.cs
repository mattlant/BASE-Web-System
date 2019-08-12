using System;
using System.Collections.Generic;
using System.Text;

namespace BASE.Web.UrlParsing
{
	public class UrlQueryString
	{
		string _originalstring = "";
		Dictionary <string, string> _paramsKeysValues;
		public UrlQueryString(string queryString)
		{
			//Check for errors
			if(queryString == null || queryString.Length < 3)
				throw new ArgumentException("Argument passed is invalid", "queryString");

			//init the dict
			_paramsKeysValues = new Dictionary<string,string>();

			queryString = queryString.TrimStart("?".ToCharArray());

			string[] items = queryString.Split("&".ToCharArray(), StringSplitOptions.RemoveEmptyEntries); //Split on & to get params

			//loop thru the items and get key/value pairs
			for(int i = 0; i < items.Length; i++)
			{
				//split on = to get key=value
				string[] item = items[i].Split("=".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
				if(item.Length != 2) //continue if invalid key/value pair
					continue;
				//Its valid, so add the item
				_paramsKeysValues.Add(item[0], item[1]);
			}
		}

		public Dictionary<string, string> KeyValuePairs
		{
			get { return _paramsKeysValues; }
		}

		public string BuildFullQuerySTring()
		{
			string qs = "";
			if (_paramsKeysValues.Count == 0) return qs;

			foreach (KeyValuePair<string, string> kvp in _paramsKeysValues)
				qs += kvp.Key + "=" + kvp.Value + "&";

			return qs.TrimEnd("&".ToCharArray());
		}


	}
}
