using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.RegularExpressions; 

namespace BASE.Web.HtmlParsing
{

	public class HtmlLiteralChunk : HtmlChunk
	{
		public HtmlLiteralChunk(string chunk)
			: base(chunk, HtmlChunkType.Literal)
		{
		}
	}

}
