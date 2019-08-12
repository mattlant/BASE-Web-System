using System;
using System.Collections.Generic;
using System.Text;

namespace BASE.Web.EndPoints
{
	public interface IEndPointPlugin
	{
		/// <summary>
		/// This method allows a plugin to register to EndPoint events raised through the EndPointManager
		/// </summary>
		/// <param name="epMan"></param>
		void Init(EndPointPluginManager epMan);
	}
}
