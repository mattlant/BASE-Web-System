using System;
using System.Collections.Generic;
using System.Text;

namespace BASE
{
	[Flags]
	public enum SystemCompilationType
	{
	
		Debug = 1,
		Core = 2,
		MultiSite = 4,



		Full = Core | MultiSite

	}
}
