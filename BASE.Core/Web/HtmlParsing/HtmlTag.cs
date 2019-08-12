using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.RegularExpressions;

namespace BASE.Web.HtmlParsing
{
	public class HtmlTag : HtmlChunk
	{
		protected string _prefix;
		protected string _tagName;
		protected bool _isSelfClosing;
		protected string _id;

		protected Dictionary<string, string> _attributes;

		/// <summary>
		/// Constructor for making an HtmlTag chunk with strings
		/// </summary>
		/// <param name="tag"></param>
		/// <param name="fullTagName"></param>
		/// <param name="isSelfClosing"></param>
		public HtmlTag(string tag)
			: base(tag, HtmlChunkType.Tag)
		{

			TagRegex tagReg = new TagRegex();
			Match m = tagReg.Match(tag);
			if (m.Success)
			{
				_attributes = HtmlParserHelper.GetAttributesFromTag(m);
				_isSelfClosing = HtmlParserHelper.IsSelfClosingTag(m);
				setTagInfoInternal(HtmlParserHelper.GetTagName(m));
				_id = _attributes.ContainsKey("id") ? _attributes["id"] : "";
			}
			else
				throw new ArgumentException("A valid tag is required", "tag");

		}

		/// <summary>
		/// Constructor for making an HtmlTag chunk with a Match. This ctor is for self closing tags.
		/// </summary>
		/// <param name="tag">A Match with a self closing tag</param>
		public HtmlTag(Match tag)
			: base(tag.Value, HtmlChunkType.Tag)
		{
			_isSelfClosing = HtmlParserHelper.IsSelfClosingTag(tag);
			setTagInfoInternal(HtmlParserHelper.GetTagName(tag));
			_attributes = HtmlParserHelper.GetAttributesFromTag(tag);
			_id = _attributes.ContainsKey("id") ? _attributes["id"] : "";

		}

		/// <summary>
		/// Constructor for making an HtmlTag chunk with a Match. This ctor is for open and close tags with inner text.
		/// </summary>
		/// <param name="tag">The Match with the opening tag</param>
		/// <param name="outterText">The full text</param>
		public HtmlTag(Match tag, string outterText)
			: base(outterText, HtmlChunkType.Tag)
		{
			_isSelfClosing = false;
			setTagInfoInternal(HtmlParserHelper.GetTagName(tag));
			_attributes = HtmlParserHelper.GetAttributesFromTag(tag);
			_id = _attributes.ContainsKey("id") ? _attributes["id"] : "";

		}

		public HtmlTag(string outtertext, string tag, string prefix, string attributes)
			: base(outtertext, HtmlChunkType.Tag)
		{
			_isSelfClosing = true;
			_attributes = getAttributesFromString(attributes);
			_prefix = prefix;
			_tagName = tag;
			_id = _attributes.ContainsKey("id") ? _attributes["id"] : "";
		}

		protected void setTagInfoInternal(string fullTagName)
		{
			string[] parts = fullTagName.Split(char.Parse(":"));

			_prefix = parts.Length > 1 ? parts[0] : "";
			_tagName = parts.Length > 1 ? parts[1] : parts[0];
		}

		/// <summary>
		/// Gets the tag prefix.
		/// </summary>
		/// <example>&lt;base:Region id='MyRegion' isDefault='true' /&gt;<br/>
		/// This would return 'base' as the Prefix, 'Region as the TagName, 'base:Region' for the FulltagName,'MyRegion' for the Id.</example>
		public virtual string Prefix
		{
			get { return _prefix;}
		}

		/// <summary>
		/// Gets the id of this tag if it was provided in the attributes. Matches only lowercase 'id'
		/// </summary>
		/// <example>&lt;base:Region id='MyRegion' isDefault='true' /&gt;<br/>
		/// This would return 'base' as the Prefix, 'Region as the TagName, 'base:Region' for the FulltagName,'MyRegion' for the Id.</example>
		public virtual string Id
		{
			get { return _id; }
		}

		/// <summary>
		/// Gets he tag name. This will return a name regardless if there was a prefix or not. This does not include the prefix.
		/// </summary>
		/// <example>&lt;base:Region id='MyRegion' isDefault='true' /&gt;<br/>
		/// This would return 'base' as the Prefix, 'Region as the TagName, 'base:Region' for the FulltagName,'MyRegion' for the Id.</example>
		public virtual string TagName
		{
			get { return _tagName; }
		}

		/// <summary>
		/// Gets the full tagname, including any prefix if created with one.
		/// </summary>
		/// <example>&lt;base:Region id='MyRegion' isDefault='true' /&gt;<br/>
		/// This would return 'base' as the Prefix, 'Region as the TagName, 'base:Region' for the FulltagName,'MyRegion' for the Id.</example>
		public virtual string FullTagName
		{
			get { return _prefix + ":" + _tagName; }
		}

		/// <summary>
		/// Gets a value indicating if this tag was a self closing tag (<b>true</b>), or contains both an open and a close tag (<b>false</b>)
		/// </summary>
		/// <example>&lt;base:Region id='MyRegion' isDefault='true' /&gt;<br/>
		/// This would return <b>true</b> because it is a self closing tag.</example>
		public virtual bool IsSelfClosing
		{
			get { return _isSelfClosing; }
		}

		public virtual Dictionary<string, string> Attributes
		{
			get { return _attributes; }
		}

		public virtual string AttributesAsString
		{
			get 
			{
				StringBuilder sb = new StringBuilder(this._attributes.Count * 8);

				foreach(KeyValuePair<string, string> kvp in this._attributes)
				{
					sb.Append(kvp.Key);
					sb.Append((char)31); //Unit Seperator
					sb.Append(kvp.Value);
					sb.Append((char)30); //Record Seperator
				}
				return sb.ToString();
			}
		}

		internal Dictionary<string, string> getAttributesFromString(string attr)
		{
			Dictionary<string, string> attributeDict = new Dictionary<string,string>();
			string[] major = attr.Split(new char[] {(char)30}, StringSplitOptions.RemoveEmptyEntries);
			foreach(string inter in major)
			{
				string[] minor = inter.Split(new char[] { (char)31 }, StringSplitOptions.RemoveEmptyEntries);
				attributeDict.Add(minor[0], minor[1]);
			}
				
			return attributeDict;
		}


	}
}
