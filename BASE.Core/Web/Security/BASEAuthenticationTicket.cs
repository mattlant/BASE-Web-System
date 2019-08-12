using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace BASE.Web.Security
{
	[Serializable]
	public class BASEAuthenticationTicket
	{
		int _siteUID;
		Guid _userGuid;
		int _userUid;
		DateTime _issueDateTime;
		DateTime _expiryDateTime;
		bool _isPersistant;
		string _userData;

		public BASEAuthenticationTicket(int siteUID, Guid userGuid, int userUID, DateTime issued, DateTime expiry, bool isPersistant, string userData)
		{
			_siteUID = siteUID;
			_userGuid = userGuid;
			_issueDateTime = issued;
			_expiryDateTime = expiry;
			_isPersistant = isPersistant;
			_userData = userData;
		}

		public BASEAuthenticationTicket(string combined)
		{
			string[] parts = combined.Split(new char[] { '|' }, StringSplitOptions.None);
			if (parts.Length != 8)
				throw new ArgumentException("Invalid ticket stirng", "combined");

			try{

				_siteUID = int.Parse(parts[0]);
				_userGuid = new Guid(parts[1]);
				_userUid = int.Parse(parts[2]);
				_issueDateTime = DateTime.FromBinary(long.Parse(parts[3]));
				_expiryDateTime = DateTime.FromBinary(long.Parse(parts[4]));
				_isPersistant = bool.Parse(parts[5]);
				_userData = parts[6];
			}
			catch(Exception ex)
			{
				throw new ArgumentException("Invalid ticket string. See inner exception for more details.", "combined", ex);
			}
		}

		public override string ToString()
		{
			return String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}", _siteUID, _userGuid, _userUid, _issueDateTime.ToBinary(), _expiryDateTime.ToBinary(), _isPersistant, _userData);

		}

		public bool IsValid()
		{
			return
				(_siteUID > 0 &&
				_userUid > 0 &&
				_userGuid != Guid.Empty &&
				IssueDateTime < DateTime.Now &&
				ExpiryDateTime > DateTime.Now);
		}

		public int SiteUID
		{
			get { return _siteUID; }
		}

		public Guid UserGuid
		{
			get { return _userGuid; }
		}

		public int UserUid
		{
			get { return _userUid; }
		}

		public DateTime IssueDateTime
		{
			get { return _issueDateTime; }
		}

		public DateTime ExpiryDateTime
		{
			get { return _expiryDateTime; }
		}

		public bool IsPersistant
		{
			get { return _isPersistant; }
		}

		public string UserData
		{
			get { return _userData; }
		}

	}
}
