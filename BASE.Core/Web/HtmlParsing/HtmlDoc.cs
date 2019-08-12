using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.RegularExpressions;

namespace BASE.Web.HtmlParsing
{
	public class HtmlDoc : HtmlChunk
	{
		protected string _docType;
		protected string _docTypeVersion;


		public HtmlDoc(string docHtml, string docType)
			: base(docHtml, HtmlChunkType.Doc)
		{
			_docType = docType;

		}

		public HtmlDoc(string docHtml)
			: base(docHtml, HtmlChunkType.Doc)
		{
			//Check for the parser type directive
			DirectiveRegex drx = new DirectiveRegex();
			Match type = drx.Match(docHtml);

			//If we found it, make sure its actually our parser directive
			if (type.Success)
			{
				Dictionary<string, string> attrs = HtmlParserHelper.GetAttributesFromTag(type);
				//If its a parser directive, assign it, otherwise assign it the default parser
				_docType = attrs.ContainsKey("parser") ? attrs["parser"] : HtmlParser.DefaultParser;
			}
			else
				_docType = HtmlParser.DefaultParser;


		}


		public virtual string DocumentType
		{
			get { return _docType; }
		}

	}
}
