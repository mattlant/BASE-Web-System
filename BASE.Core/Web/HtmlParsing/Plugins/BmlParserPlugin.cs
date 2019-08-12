using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Web.RegularExpressions;
using System.Web.UI;

using BASE.Web.UI.Controls;
using BASE.Web.HtmlParsing;
using BASE.Data.LLDAL.EntityClasses;
using BASE.Data.LLDAL.HelperClasses;
using BASE.Data.Helpers;

namespace BASE.Web.HtmlParsing.Plugins
{
	public class BmlParserPlugin : IHtmlParserPlugin
	{
		string _tagHandled = "";

		public string HtmlParserTag
		{
			get { return _tagHandled; }
		}

		public void Init(System.Xml.XmlNode xmlNode)
		{
			_tagHandled = xmlNode.Attributes["tag"].Value;
		}

		public Control[] CreateControls(Page page, HtmlDoc html)
		{
			List<HtmlChunk> chunks = CreateChunks(html);
			return CreateControls(page, chunks);
		}

		public Control[] CreateControls(Page page, string html)
		{
			List<HtmlChunk> chunks = CreateChunks(html);
			return CreateControls(page, chunks);
		}

		public List<HtmlChunk> CreateChunks(HtmlDoc html)
		{
			return CreateChunks(html.Value);
		}

		public List<HtmlChunk> CreateChunks(string html)
		{
			return ParseBml(html);
		}

		public Control[] CreateControls(Page page, List<HtmlChunk> chunks)
		{
			List<System.Web.UI.Control> controls = new List<System.Web.UI.Control>();

			foreach (HtmlChunk chunk in chunks)
			{
				switch (chunk.ChunkType)
				{
					case HtmlChunkType.Tag:
						//This is a tag for a custom control
						controls.Add(TagParser.ParseTag(page, (HtmlTag)chunk));
						//TODO: Change Tag System!!!
						break;
					case HtmlChunkType.Region:
						//make sure its a base:Region!
						//TODO: Make sure we pass the attributes somehow so that we can merge properly
						BmlRegion region = (BmlRegion)chunk;
						RegionPlaceHolder plc = new RegionPlaceHolder();
						//Set the Region ID for any merging that may take place at a later stage
						plc.RegionID = region.Id;
						//optionally add innertext if any
						if (region.IsSelfClosing)
						{
							//TODO: Add content if any
						}
						//This is a tag for a custom control
						controls.Add(plc);
						break;
					case HtmlChunkType.Literal:
						System.Web.UI.WebControls.Literal lit = new System.Web.UI.WebControls.Literal();
						lit.Text = chunk.Value;
						controls.Add(lit);
						break;
					default:
						throw new BASEGenericException("Invalid Chunk");
						break;
				}
			}

			return controls.ToArray();
		}

		public List<HtmlChunk> CreateChunks(BASE.Data.LLDAL.HelperClasses.EntityCollection<BASE.Data.LLDAL.EntityClasses.TemplateChunksEntity> chunks)
		{
			List<HtmlChunk> htmlchunks = new List<HtmlChunk>();
			foreach(TemplateChunksEntity chunk in chunks)
			{
				switch(chunk.ChunkType)
				{
					case (int)HtmlChunkType.Literal:
						htmlchunks.Add(new HtmlLiteralChunk(chunk.HTMLText));
						break;
					case (int)HtmlChunkType.Tag:
						htmlchunks.Add(new HtmlTag(chunk.HTMLText, chunk.TagName, chunk.Prefix, chunk.Attributes));
						break;
					case (int)HtmlChunkType.Region:
						htmlchunks.Add(new BmlRegion(chunk.HTMLText, chunk.TagName, chunk.Prefix, chunk.Attributes));
						break;
					default:
						throw new BASEGenericException("Invalid Chunk type stored in TemplateChunks for the bml parser");
				}
			}
			return htmlchunks;
		}



		private List<HtmlChunk> ParseBml(string bml)
		{
			//loop thru bml

			////find tag
			/////if reg'd tag save position found. Take all above bml and move to a string. Find end tag

			int currentIndex = 0;
			//int lastChunkStartIndex = 0;
			int lastChunkEndIndex = 0;

			List<HtmlChunk> _chunks = new List<HtmlChunk>();
			Match lastmatch = null;

			while (currentIndex < bml.Length)
			{
				Match m = null;

				// Find next opening tags
				TagRegex bmlTag = new TagRegex();
				m = bmlTag.Match(bml, currentIndex);

				//Check to see if we have a match
				if (m.Success)
				{
					string tagName = HtmlParserHelper.GetTagName(m);
					if (HtmlParserHelper.IsRegisteredPrefix(tagName))
					{
						lastmatch = m;
						if (HtmlParserHelper.IsSelfClosingTag(m))
						{
							//Self closing
							//Add the in between bml as a chunk
							//Add chunks to list
							_chunks.Add(new HtmlLiteralChunk(bml.Substring(lastChunkEndIndex, m.Index - lastChunkEndIndex)));
							//Check to see if its a Region
							if (HtmlParserHelper.GetTagName(m) == "base:Region")
								_chunks.Add(new BmlRegion(m));
							else
								_chunks.Add(new HtmlTag(m));

							//SET last chunk index

							//increment the index by the length of the tag
							currentIndex = m.Index + m.Length;
							lastChunkEndIndex = currentIndex;
							continue;
						}
						else
						{
							//Not self closing, find end tag
							string outter = HtmlParserHelper.GetOutterText(bml, m);

							//add the chunks to the list
							_chunks.Add(new HtmlLiteralChunk(bml.Substring(lastChunkEndIndex, m.Index - lastChunkEndIndex)));
							//Check to see if its a Region
							if (HtmlParserHelper.GetTagName(m) == "base:Region")
								_chunks.Add(new BmlRegion(m, outter));
							else
								_chunks.Add(new HtmlTag(m, outter));

							//SET last chunk index
							//increment index the amount of outtertext.
							currentIndex = m.Index + outter.Length;
							lastChunkEndIndex = currentIndex;
							continue;
						}
					}
				}
				currentIndex++;
			}

			//add final chunk
			_chunks.Add(new HtmlLiteralChunk(bml.Substring(lastChunkEndIndex, bml.Length - lastChunkEndIndex)));

			return _chunks;
		}

		#region IHtmlParserPlugin Members


		#endregion
	}
}
