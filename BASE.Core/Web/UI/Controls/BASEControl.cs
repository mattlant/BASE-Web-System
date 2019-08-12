using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BASE.Web.UI.Controls
{
	/// <summary>
	/// Inherit from this class to create a Non-UserControl based control to be used in BASE
	/// </summary>
	public abstract class BASEControl : Control, IBASEControl
	{
		/// <summary>
		/// Must implement this method. This method receives all attributes from a bml tag for the controls initialization
		/// </summary>
		/// <param name="parameters"></param>
		public abstract void InitializeParameters(Dictionary<string, string> parameters);

	}
}
