using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.RegularExpressions; 

namespace BASE.Web.HtmlParsing
{
	public class HtmlChunk
	{
		protected StringBuilder _chunk;
		protected HtmlChunkType _type;

		public HtmlChunk(string chunk, HtmlChunkType type)
		{
			_chunk = new StringBuilder(chunk);
			_type = type;
		}

		protected HtmlChunk(HtmlChunkType type)
		{
			_type = type;
		}

		public HtmlChunk(string chunk)
			: this(chunk, HtmlChunkType.Raw)
		{ }

		public virtual string Value
		{
			get { return _chunk.ToString(); }
		}

		public virtual HtmlChunkType ChunkType
		{
			get { return _type; }
		}

	}
}
