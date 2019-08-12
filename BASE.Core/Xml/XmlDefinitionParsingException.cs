using System;
using System.Collections.Generic;
using System.Text;

using System.Xml;

namespace BASE.Xml
{
	/// <summary>
	/// Represents errors that occur during the parsing of Xml Definition files used in BASE
	/// </summary>
	public class XmlDefinitionParsingException : XmlException
	{
		protected string _fileName = "";

		public XmlDefinitionParsingException()
		{
		}

		public XmlDefinitionParsingException(string message)
			: base(message)
		{
		}

		public XmlDefinitionParsingException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		public XmlDefinitionParsingException(string message, Exception innerException, int lineNumber, int linePosition)
			: base(message, innerException, lineNumber, linePosition)
		{
		}

		public XmlDefinitionParsingException(string message, string fileName)
			: base(message)
		{
			_fileName = fileName;
		}

		public XmlDefinitionParsingException(string message, string fileName, Exception innerException)
			: base(message, innerException)
		{
			_fileName = fileName;
		}

		public XmlDefinitionParsingException(string message, string fileName, Exception innerException, int lineNumber, int linePosition)
			: base(message, innerException, lineNumber, linePosition)
		{
			_fileName = fileName;
		}
	}
}
