using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Security;

namespace BASE.Security
{
	public class AuthHelper
	{
		public static bool ResourceRequiresAuthentication()
		{
			return true;
		}

		public static bool IsCookieHashValid(HttpCookie cookie)
		{
			return true;
		}

		public static HttpCookie CreateCookie(int SiteUID, Guid userGuid, DateTime expiry)
		{
			return new HttpCookie("");
		}


			


	}
}



/*
 * 
 * Cookie structure
 * - SiteUID
 * - Username
 * - UserGUID
 * - Expiry Date
 * - Hash
 * - Encrypted Hash
 * 
 * 
 * Unencrypted non hash = SiteUID|username|GUID|Expiry
 * That gets hashed and hash added: |Hashcode
 * All that gets encrypted
 * cookie then containes:
 * Enc:encryptedcontent
 * Hash:Hash of encrypted content
 * 
 * 
 * 
*/