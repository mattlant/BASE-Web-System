using System;
using System.Collections.Generic;
using System.Text;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BASE.Web;
using BASE.Web;

namespace BASE.Web.EndPoints
{
    /// <summary>
    /// This class is used to represent the event arguments class passed to overrided method. 
    /// </summary>
	public class EndPointEventArgs : EventArgs
	{
		private EndPoint _endPoint;

		private bool _cancelRequest = false;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="endPoint">The EndPoint object instance</param>
		public EndPointEventArgs(EndPoint endPoint)
			: base()
		{
			_endPoint = endPoint;
		}

        /// <summary>
        /// Public property to get the EndPoint Instance tied to 
        /// this EndPointEventArgs class instance
        /// </summary>
		public EndPoint EndPoint
		{
			get { return _endPoint; }
		}

        /// <summary>
        /// Public property to get/set the CancelRequest flag tied to 
        /// this EndPointEventArgs class instance
        /// </summary>
        public bool CancelRequest
		{
			get { return _cancelRequest; }
			set
			{
				if(!_cancelRequest)
					_cancelRequest = value;
			}
		}

	}
}
