using System;
using System.Collections.Generic;
using System.Text;

namespace BASE
{
	public class AssertionFailureException : BASEGenericException
	{
		public AssertionFailureException()
			: base("Assertion Failure")
		{
		}

		public AssertionFailureException(string message)
			: base(message)
		{
		}
	}
}
