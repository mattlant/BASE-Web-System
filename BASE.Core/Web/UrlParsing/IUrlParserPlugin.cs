using System;
using System.Collections.Generic;
using System.Text;

namespace BASE.Web.UrlParsing
{
	public interface IUrlParserPlugin : IInitFromXml
	{
		void ProcessUrl(BASEApplication context);

	}
}
