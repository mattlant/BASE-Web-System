using System;
using System.Collections.Generic;
using System.Text;

namespace BASE.Web.EndPoints
{
	public class PageSkinningException : EndPointException
	{
		public PageSkinningException()
			: base()
		{
		}

		public PageSkinningException(string message)
			: base(message)
		{
		}
	}
}
