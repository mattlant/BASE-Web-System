using System;
using System.Collections.Generic;
using System.Text;

using System.Xml;
using System.Web.UI;

namespace BASE.Web.HtmlParsing
{
	public interface ITagParserPlugin : IInitFromXml
	{
		string Prefix { get; }
		System.Web.UI.Control HandleTag(Page page, HtmlTag tag);

	}
}
