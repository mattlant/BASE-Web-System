using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Principal;

namespace BASE.Security
{
	public class BASEPrinciple : IPrincipal
	{
		UserIdentityToken _identity;

		public BASEPrinciple(UserIdentityToken token)
		{
			_identity = token;
		}

		#region IPrincipal Members

		public IIdentity Identity
		{
			get { return _identity; }
		}

		public bool IsInRole(string role)
		{
			//TODO: Have this parse thru the roles in the Identity at some point
			return false;
		}

		#endregion
	}
}
