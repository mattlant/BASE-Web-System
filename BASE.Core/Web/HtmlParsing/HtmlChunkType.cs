using System;

namespace BASE.Web.HtmlParsing
{

	public enum HtmlChunkType
	{
		Raw,
		Literal,
		Tag,
		Doc,
		Region
	}
}
