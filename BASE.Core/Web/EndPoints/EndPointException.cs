using System;
using System.Collections.Generic;
using System.Text;

using BASE;

namespace BASE.Web.EndPoints
{
	public class EndPointException : BASEGenericException
	{
		public EndPointException()
			: base()
		{
		}

		public EndPointException(string message)
			: base(message)
		{
		}
	}
}
