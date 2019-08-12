using System;
using System.Collections.Generic;
using System.Text;

using System.Web;


namespace BASE.Web
{
	public class BASERequest
	{
		internal int _siteUID = 0;
		internal int _sectionUID = 0;
		internal int _pageUID = 0;
		internal string _module = "";
		internal string _moduleControl = "";
		internal Uri _originalUrl;
		internal Uri _finalUrl;
		internal List<int> _sites = new List<int>();
		internal List<int> _sections = new List<int>();
		internal string _sitePath = "/"; //TODO: Use StringBuilders!
		internal string _sectionPath = "/";
		internal bool _isSubSite = false;
		internal bool _isRootExclusion = false;
		internal bool _isSubExclusion = false;

		internal bool _isRequestFinal = false;

		internal bool _isVirtualEndPoint = false;

		internal void Reset(Uri originalUrl)
		{
			_siteUID = 0;
			_sectionUID = 0;
			_pageUID = 0;
			_module = "";
			_moduleControl = "";
			_originalUrl = originalUrl;
			_isRequestFinal = false;
			_isVirtualEndPoint = false;
			_sites.Clear();
			_sections.Clear();
			_sitePath = "/";
			_sectionPath = "";
			_isSubSite = false;
			_isRootExclusion = false;
			_isSubExclusion = false;


		}

		public int SiteUID
		{
			get { return _siteUID; }
			set { _siteUID = value; }
		}

		public int SectionUID
		{
			get { return _sectionUID; }
			set { _sectionUID = value; }
		}

		public int PageUID
		{
			get { return _pageUID; }
			set { _pageUID = value; }
		}

		public string Module
		{
			get { return _module; }
			set { _module = value; }
		}

		public string ModuleControl
		{
			get { return _moduleControl; }
			set { _moduleControl = value; }
		}


		public Uri OriginalUrl
		{ 
			get { return _originalUrl; }
		}

		public Uri FinalUrl
		{
			get { return _finalUrl; }
		}

		public bool IsRequestFinal
		{
			get { return _isRequestFinal; }
		}

		public bool IsSubSite
		{
			get { return _isSubSite; }
		}

		public bool IsRootExclusion
		{
			get { return _isRootExclusion; }
		}

		public bool IsSubExclusion
		{
			get { return _isSubExclusion; }
		}

		public List<int> Sites
		{
			get { return _sites; }
		}

		public void AddSiteToList(string siteName, int siteID)
		{
			_sites.Add(siteID);
			_sitePath += siteName + "/";
		}

		public List<int> Sections
		{
			get { return _sections; }
		}

		public void AddSectionToList(string sectionName, int sectionUID)
		{
			_sections.Add(sectionUID);
			_sectionPath += (sectionName + "/");
		}

		public string VirtualSitePath
		{
			get { return _sitePath; }
		}

		public string RootVirtualSitePath
		{
			get { return "/"; }
		}

		public string VirtualSectionPath
		{
			get { return _sitePath + _sectionPath; }
		}

		public string PhysicalTopLevelSitePath
		{
			get { return HttpContext.Current.Request.PhysicalApplicationPath + "sites/" + _sites[0].ToString() + "/"; }
		}

		public string RealTopLevelSitePath
		{
			get { return "/sites/" + _sites[0].ToString() + "/"; }
		}

		public string PhysicalSitePath
		{
			get { return HttpContext.Current.Request.PhysicalApplicationPath + "sites/" + _sites[_sites.Count - 1].ToString() + "/"; }
		}

		public string RealSitePath
		{
			get { return "/sites/" + _sites[_sites.Count - 1].ToString() + "/"; }
		}

		public string PhysicalSectionPath
		{
			get { return HttpContext.Current.Request.PhysicalApplicationPath + "sites/" + _siteUID.ToString() + "/" + _sectionPath; }
		}

		public string RealSectionPath
		{
			get { return "/sites/" + _siteUID.ToString() + "/" + _sectionPath; }
		}




	}
}
