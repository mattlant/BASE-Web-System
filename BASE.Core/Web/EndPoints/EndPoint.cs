using System;
using System.Collections.Generic;
using System.Text;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BASE.Web.UI.Controls;

namespace BASE.Web.EndPoints
{
	public delegate void EndPointProcessingHandler(object sender, EndPointEventArgs e);

    /// <summary>
    /// This class is used to represent a Page as a EndPoint and it the last 
    /// 'object representing our page' in the BASE Chain of Procession that 
    /// get output to the client who made a request. It offer various
    /// events to subscribe to, just like a real html page would do.
    /// </summary>
	public class EndPoint : Page, IEndPoint
    {

		public static readonly string EndPointCat = "ENDPOINTS";
		
		#region Handlers declaration
        public static event EndPointProcessingHandler EndPointPreInit;
		public static event EndPointProcessingHandler EndPointInit;
		public static event EndPointProcessingHandler EndPointInitComplete;
		public static event EndPointProcessingHandler EndPointPreLoad;
		public static event EndPointProcessingHandler EndPointLoad;
		public static event EndPointProcessingHandler EndPointLoadComplete;
		public static event EndPointProcessingHandler EndPointPreRender;
		public static event EndPointProcessingHandler EndPointUnload;
        #endregion

        #region Overrides of Events
        /// <summary>
        /// Overrided method for the OnPreInit event.
        /// </summary>
        /// <param name="e">Arguments passed to the call.</param>
		protected override void OnPreInit(EventArgs e)
		{
			//Call into EndPointPlugins that handle OnInt
			if (EndPointPreInit != null)
				EndPointPreInit(this, new EndPointEventArgs(this));
			base.OnPreInit(e);
		}

        /// <summary>
        /// Overrided method for the OnInit event.
        /// </summary>
        /// <param name="e">Arguments passed to the call.</param>
		protected override void OnInit(EventArgs e)
		{
			//Call into EndPointPlugins that handle OnInt
			if (EndPointInit != null)
				EndPointInit(this, new EndPointEventArgs(this));
			base.OnInit(e);
		}

        /// <summary>
        /// Overrided method for the OnInitComplete event.
        /// </summary>
        /// <param name="e">Arguments passed to the call.</param>
		protected override void OnInitComplete(EventArgs e)
		{
			//Call into EndPointPlugins that handle OnInt
			if (EndPointInitComplete != null)
				EndPointInitComplete(this, new EndPointEventArgs(this));
			base.OnInitComplete(e);
		}

        /// <summary>
        /// Overrided method for the OnPreLoad event.
        /// </summary>
        /// <param name="e">Arguments passed to the call.</param>
		protected override void OnPreLoad(EventArgs e)
		{
			//Call into EndPointPlugins that handle OnInt
			if (EndPointPreLoad != null)
				EndPointPreLoad(this, new EndPointEventArgs(this));
			base.OnPreLoad(e);
		}

        /// <summary>
        /// Overrided method for the OnLoad event.
        /// </summary>
        /// <param name="e">Arguments passed to the call.</param>
		protected override void OnLoad(EventArgs e)
		{
			//Call into EndPointPlugins that handle OnInt
			if (EndPointLoad != null)
				EndPointLoad(this, new EndPointEventArgs(this));
			base.OnLoad(e);
		}

        /// <summary>
        /// Overrided method for the OnLoadComplete event.
        /// </summary>
        /// <param name="e">Arguments passed to the call.</param>
		protected override void OnLoadComplete(EventArgs e)
		{
			//Call into EndPointPlugins that handle OnInt
			if (EndPointLoadComplete != null)
				EndPointLoadComplete(this, new EndPointEventArgs(this));
			base.OnLoadComplete(e);
		}

        /// <summary>
        /// Overrided method for the OnPreRender event.
        /// </summary>
        /// <param name="e">Arguments passed to the call.</param>
		protected override void OnPreRender(EventArgs e)
		{
			//Call into EndPointPlugins that handle OnInt
			if (EndPointPreRender != null)
				EndPointPreRender(this, new EndPointEventArgs(this));
			base.OnPreRender(e);
		}
		protected override void OnPreRenderComplete(EventArgs e)
		{
			//TODO: Add in an overridable crosspage post back here!
			base.OnPreRenderComplete(e);

			//this.IsCrossPagePostBack
			if(this.Form is BASEForm)
			{	
				BASEForm frm = (BASEForm)this.Form;
				BASEApplication app = (BASEApplication)HttpContext.Current.ApplicationInstance;
				frm.Action = app.BASERequest._originalUrl.PathAndQuery;
			}
		}

        /// <summary>
        /// Overrided method for the OnUnload event.
        /// </summary>
        /// <param name="e">Arguments passed to the call.</param>
		protected override void OnUnload(EventArgs e)
		{
			//Call into EndPointPlugins that handle OnInt
			if (EndPointUnload != null)
				EndPointUnload(this, new EndPointEventArgs(this));
			base.OnUnload(e);
        }
        #endregion
    }
}
