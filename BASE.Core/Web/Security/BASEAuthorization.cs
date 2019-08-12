using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace BASE.Web.Security
{
	public class BASEAuthorization
	{
		public static bool PageAllowsAnonymous(int pageUID)
		{
			return false;
		}

		public static bool SectionAllowsAnonymous(int pageUID)
		{
			return true;
		}

		public static bool SiteAllowsAnonymous(int pageUID)
		{
			return true;
		}

		public static bool UrlAllowsAnonymous(string url)
		{
			return true;
		}

		public static bool CurrentRequestAllowsAnonymous()
		{
			if (HttpContext.Current.Request.Url.AbsolutePath.Equals("/Logintest.aspx", StringComparison.OrdinalIgnoreCase))
				return true;
			return false; //TODO: THIS IS TEMP!!!!
		}
	}
}
