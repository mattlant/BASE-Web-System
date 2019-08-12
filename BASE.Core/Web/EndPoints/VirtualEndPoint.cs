using System;
using System.Collections.Generic;
using System.Text;

namespace BASE.Web.EndPoints
{
	public class VirtualSkinnedEndPoint : SkinnedEndPoint
	{
		public static event EndPointProcessingHandler PreMergeRegion;
		public static event EndPointProcessingHandler MergeRegion;
		public static event EndPointProcessingHandler MergeRegionComplete;

		protected override void OnInit(EventArgs e)
		{
			if (PreMergeRegion != null)
				PreMergeRegion(this, new EndPointEventArgs(this));
			if (MergeRegion != null)
				MergeRegion(this, new EndPointEventArgs(this));
			if (MergeRegionComplete != null)
				MergeRegionComplete(this, new EndPointEventArgs(this));

			
			base.OnInit(e);
		}
	}
}
