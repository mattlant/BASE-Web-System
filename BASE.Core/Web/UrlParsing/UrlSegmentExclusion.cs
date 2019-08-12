using System;
using System.Collections.Generic;
using System.Text;

namespace BASE.Web.UrlParsing
{
	public class UrlSegmentExclusion
	{
		string _name;

		public UrlSegmentExclusion(string name, bool root, bool sub)
		{
			_name = name;
			_root = root;
			_sub = sub;
		}

		public string Name
		{
			get { return _name; }
		}

		bool _root;

		public bool Root
		{
			get { return _root; }
		}

		bool _sub;

		public bool Sub
		{
			get { return _sub; }
		}

	}
}
