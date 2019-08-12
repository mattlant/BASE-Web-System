using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace BASE.Web.UI.Controls
{
	public interface IBASEControl
	{
		void InitializeParameters(Dictionary<string, string> parameters);

	}
}
