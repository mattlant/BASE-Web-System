using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

using BASE.Data.LLDAL.EntityClasses;

namespace BASE.Web.Sites
{
	public class SiteManager
	{
		private BASE.Data.LLDAL.EntityClasses.SiteEntity _siteEntity;
		private Dictionary<Guid, SiteManager> _subSiteManagers;

		internal SiteManager(SiteEntity siteEntity)
		{
			//CReate a new Dictionary of site managers and assign the siteentity internally. Thats all we need.... for now.
			_subSiteManagers = new Dictionary<Guid, SiteManager>();
			_siteEntity = siteEntity;

#if DEBUG
			Debug.WriteLine("SiteManager()");
#endif

		}
		//TODO: Add in alternate CTORs that will create a site manager based on guid, name, owner, etc.

		public BASE.Data.LLDAL.EntityClasses.SiteEntity SiteEntity
		{
			get
			{
				return _siteEntity;
			}
		}

		public Dictionary<Guid, SiteManager> SubSiteManagers
		{
			get
			{
				return SubSiteManagers;
			}
		}

		public SiteManager GetSubSiteManager(Guid subSiteGuid)
		{
			return _subSiteManagers[subSiteGuid];
		}
	}
}
