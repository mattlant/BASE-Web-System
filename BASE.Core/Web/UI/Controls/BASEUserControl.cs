using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using BASE.Web;
using BASE.Web.SessionState;
using BASE.Data;
using BASE.Data.LLDAL.EntityClasses;
using BASE.Data.LLDAL.DatabaseSpecific;
using BASE.Data.LLDAL.HelperClasses;

namespace BASE.Web.UI.Controls
{
	public abstract class BASEUserControl : UserControl, IBASEControl
	{
		protected Dictionary<string, string> _attributes;
		protected override void  OnLoad(EventArgs e)
		{
			//TODO: Check Security
			//throw new ApplicationException("Need to implement a security check");
 			 base.OnLoad(e);
		}


		#region IBASEControl Members

		public virtual void InitializeParameters(Dictionary<string, string> parameters)
		{
			_attributes = parameters;
		}

		#endregion
	}
}
