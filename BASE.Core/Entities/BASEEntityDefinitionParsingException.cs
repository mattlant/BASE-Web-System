using System;
using System.Collections.Generic;
using System.Text;

namespace BASE.Entities
{
	public class BASEEntityDefinitionParsingException : BASE.Xml.XmlDefinitionParsingException
	{
		public BASEEntityDefinitionParsingException()
		{
		}

		public BASEEntityDefinitionParsingException(string message)
			: base(message)
		{
		}

		public BASEEntityDefinitionParsingException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		public BASEEntityDefinitionParsingException(string message, Exception innerException, int lineNumber, int linePosition)
			: base(message, innerException, lineNumber, linePosition)
		{
		}

	}
}
