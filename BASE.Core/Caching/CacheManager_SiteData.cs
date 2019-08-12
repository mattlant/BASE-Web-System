using System;
using System.Collections.Generic;
using System.Text;

using BASE.Data;
using BASE.Data.Helpers;


namespace BASE.Caching
{
	public partial class CacheManager
	{
		private Dictionary<string, int> _siteAliasLookupTable = new Dictionary<string, int>();

		public int GetSubSiteUID(string Name, int parentSiteUID)
		{
			return SiteDataHelper.SelectSiteUIDBySubSiteNameANDParentUID(Name, parentSiteUID);

			int outSiteUID = 0;

			if (_siteAliasLookupTable.TryGetValue(parentSiteUID.ToString() + Name, out outSiteUID))
				return outSiteUID;
			else
				return 0;


		}

		public int GetSiteUID(string Name)
		{
			return GetSubSiteUID(Name, 0);

		}

		internal void RetrieveSiteAliasLookupTable()
		{
			//CODE HERE
		}
	}

}
