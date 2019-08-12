using System;
using System.Collections.Generic;
using System.Text;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BASE.Data.LLDAL.EntityClasses;
using BASE.Data.LLDAL.HelperClasses;
using BASE.Data.Helpers;

namespace BASE.Web.HtmlParsing
{
	public interface IHtmlParserPlugin : IInitFromXml
	{
		string HtmlParserTag { get; }
		List<HtmlChunk> CreateChunks(EntityCollection<TemplateChunksEntity> chunks);
		List<HtmlChunk> CreateChunks(HtmlDoc htmlDoc);
		List<HtmlChunk> CreateChunks(string html);
		Control[] CreateControls(Page page, HtmlDoc htmlDoc);
		Control[] CreateControls(Page page, string html);
		Control[] CreateControls(Page page, List<HtmlChunk> chunks);

	}
}
