using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.RegularExpressions;

namespace BASE.Web.HtmlParsing
{
	public static class HtmlParserHelper
	{
		/// <summary>
		/// Checks a markup tag tp see if it is self closing
		/// </summary>
		/// <param name="tagMatch">The TagRegEx Match that contains the tag to check</param>
		/// <returns>A boolean value indicating if the tag is self closing</returns>
		public static bool IsSelfClosingTag(Match tagMatch)
		{
			//make sure argument is not null
			if (tagMatch == null)
				throw new ArgumentNullException("tagMatch", "Match cannot be null");

			// check is the match ends with a close. if so return true.
			// otherwise return false;
			return tagMatch.Groups["empty"].Value == "/";
		}

		/// <summary>
		/// Checks a markup tag tp see if it is self closing
		/// </summary>
		/// <param name="tag">A string representation of a tag to check</param>
		/// <returns>A boolean value indicating if the tag is self closing</returns>
		public static bool IsSelfClosingTag(string tag)
		{
			if (string.IsNullOrEmpty(tag))
				throw new ArgumentNullException("tag", "Tag string cannot be null or empty");
			//finds the next close bracket
			int closeIndex = tag.IndexOf(">");
			if (closeIndex == -1)
				throw new ArgumentException("Tag does not have a closing '>'", "tag");

			//if the close bracket has a forward slash in front, its a self close, return true
			// if not, its an opening tag, return false
			return (tag[closeIndex - 1] == char.Parse("/"));
		}

		public static string GetOutterText(string html, Match startTagMatch)
		{
			StringBuilder sb = new StringBuilder(5000);

			//Start searching at the end of the start tag
			int index = startTagMatch.Index + startTagMatch.Length;

			//Get the string version of the tag
			string startTagName = GetTagName(startTagMatch);
			string endTag = "";

			//loop thru the bml text
			while (index < html.Length)
			{
				Match m = null;

				//search out the next ending type of tag
				EndTagRegex bmlEndTag = new EndTagRegex();
				m = bmlEndTag.Match(html, index);
				//check if we find a match
				if (m.Success)
				{
					//verify the tagnames match
					endTag = GetTagName(m);
					if (endTag == startTagName)
					{ //match
						//return the outertext of the match.
						int endindex = m.Index + m.Length;
						int stLength = endindex - startTagMatch.Index;
						return html.Substring(startTagMatch.Index, stLength);
					}
					{ //No Match, increment index
						index = m.Index + m.Length;
						continue;
					}
				}
				index++;
			}
			//TODO: Throw error?
			throw new ApplicationException(
				string.Format("No end tag match found for tag {0} at position {1}", startTagMatch.Value, startTagMatch.Index));
			//return "";

		}

		public static bool IsRegisteredPrefix(string tagName)
		{
			//make sure it is prefixed
			if (!IsTagPrefixed(tagName))
				return false; //if not return false
			//Split the tag to get prefix
			string prefix = tagName.Split(char.Parse(":"))[0];
			//Lookup prefix in the TagParser plugin list
			return TagParser.TagHandlerExists(prefix);
		}

		public static bool IsTagPrefixed(string tagName)
		{
			return tagName.Contains(":");
		}

		public static string GetTagName(string tag)
		{
			StringBuilder sb = new StringBuilder(tag.Length - 2);
			char sp = char.Parse(" ");
			char gt = char.Parse(">");
			char fs = char.Parse("/");

			for (int i = 1; i < tag.Length; i++)
			{
				if (tag[i] == fs && sb.Length == 0) continue;
				if (tag[i] == fs) break;
				if (tag[i] == gt) break;
				if (tag[i] == sp) break;
				sb.Append(tag[i]);
			}

			return sb.ToString();

			//int indexOfSpace = tag.IndexOf(" ");
			//string tagName = tag.Substring(0, indexOfSpace);
			//tagName = tagName.TrimStart(char.Parse(">"));
			//return tagName;
		}

		public static string GetTagName(Match tag)
		{
			return tag.Groups["tagname"].Value;
		}

		public static Dictionary<string, string> GetAttributesFromTag(Match tag)
		{
			//CReate dict for all attributes and values
			Dictionary<string, string> attrlist = new Dictionary<string, string>();

			//Get the captures of the attributes and values
			Group attrname = tag.Groups["attrname"];
			Group attrval = tag.Groups["attrval"];

			//Iterate thru the captures and store them in the list
			for (int i = 0; i < attrname.Captures.Count; i++)
				attrlist.Add(attrname.Captures[i].Value, attrval.Captures[i].Value);

			return attrlist;
		}


	}
}
