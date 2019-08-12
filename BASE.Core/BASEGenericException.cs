using System;
using System.Collections.Generic;
using System.Text;

namespace BASE
{
	/// <summary>
	/// Represents errors that occur during the execution of BASE.
	/// </summary>
	public class BASEGenericException : System.Exception
	{
		/// <summary>
		/// Initializes a new instance of the BASEGenericException class.
		/// </summary>
		public BASEGenericException()
			: base("Unknown Exception")
		{
		}

		/// <summary>
		/// Initializes a new instance of the BASEGenericException class.
		/// </summary>
		/// <param name="message">A message that describes the exception.</param>
		public BASEGenericException(string message)
			: base(message)
		{
		}

		/// <summary>
		/// Initializes a new instance of the BASEGenericException class.
		/// </summary>
		/// <param name="message">A message that describes the exception.</param>
		/// <param name="innerException">The exception that is thecause of the current exception</param>
		public BASEGenericException(string message, Exception innerException) 
			: base(message, innerException)
		{
		}



	}
}
