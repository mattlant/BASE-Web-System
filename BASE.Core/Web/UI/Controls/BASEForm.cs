using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.ComponentModel;

namespace BASE.Web.UI.Controls
{
	public class BASEForm : HtmlForm
	{
		string _action = "";


		[Description("Gets or sets the target url of the form post.Leave blank to postback to the same page."),
		Category("Behavior"),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),]
		public string Action
		{
			get { return _action; }
			set { _action = value; }
		}

		protected override void RenderAttributes(HtmlTextWriter writer)
		{
			if (!string.IsNullOrEmpty(_action))
			{
				writer.WriteAttribute("action", _action, true);
				this.Attributes.Remove("action");
			}

			//TODO: Remove old action="*"
			StringWriter sw = new StringWriter();
			HtmlTextWriter temp = new HtmlTextWriter(sw);

			base.RenderAttributes(temp);

			writer.Write(sw.ToString());

		}
	}
}

