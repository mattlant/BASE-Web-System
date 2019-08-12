using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.RegularExpressions; 
using BASE.Data.LLDAL.EntityClasses;
using BASE.Data.LLDAL.HelperClasses;
using BASE.Data.Helpers;

namespace BASE.Web.HtmlParsing
{
	public class HtmlParser
	{
		static Dictionary<string, IHtmlParserPlugin> _plugins;

		public static string DefaultParser = "bml";

		static HtmlParser()
		{
			_plugins = new Dictionary<string, IHtmlParserPlugin>();
		}

		public static void AddPlugin(IHtmlParserPlugin plugin)
		{
			_plugins.Add(plugin.HtmlParserTag, plugin);
		}

		public System.Web.UI.Control[] ParseToControls(System.Web.UI.Page page, string html)
		{
			List<System.Web.UI.Control> controls = new List<System.Web.UI.Control>();
			//Read header tag, if any.
			HtmlDoc htmDoc = new HtmlDoc(html);

			//Get the plugin for this doctype
			IHtmlParserPlugin parser = _plugins[htmDoc.DocumentType];
			//Get Chunks
			return parser.CreateControls(page, htmDoc);

		}

		public System.Web.UI.Control[] ParseToControls(System.Web.UI.Page page, List<HtmlChunk> chunks, string parserType)
		{
			if (!_plugins.ContainsKey(parserType))
				throw new BASEGenericException("Parser type does not exist");

			//Get the plugin for this doctype
			IHtmlParserPlugin parser = _plugins[parserType];
			//Get Chunks
			return parser.CreateControls(page, chunks);

		}
		
		public List<HtmlChunk> ParseToChunks(string html)
		{
			//List<HtmlChunk> controls = new List<HtmlChunk>();
			//Read header tag, if any.
			HtmlDoc htmDoc = new HtmlDoc(html);

			//Get the plugin for this doctype
			IHtmlParserPlugin parser = _plugins[htmDoc.DocumentType];
			//Get Chunks
			return parser.CreateChunks(htmDoc);

		}

		public List<HtmlChunk> ParseToChunks(EntityCollection<TemplateChunksEntity> chunks, string parserType)
		{
			if (!_plugins.ContainsKey(parserType))
				throw new BASEGenericException("Parser type does not exist");

			//Get the plugin for this doctype
			IHtmlParserPlugin parser = _plugins[parserType];
			//Get Chunks
			return parser.CreateChunks(chunks);
		}


		public static bool PluginExists(string pluginName)
		{
			return _plugins.ContainsKey(pluginName);
		}

	}







}

