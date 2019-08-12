using System;
using System.Collections.Generic;
using System.Text;

namespace BASE.Web.EndPoints
{
	public class ContentMergingException : EndPointException
	{
		public ContentMergingException()
			: base()
		{
		}

		public ContentMergingException(string message)
			: base(message)
		{
		}
	}
}
