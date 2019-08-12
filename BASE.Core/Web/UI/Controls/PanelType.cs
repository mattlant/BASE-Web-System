using System;
using System.Collections.Generic;
using System.Text;

namespace BASE.Web.UI.Controls
{
    public enum PanelType
    {
        /// <summary>
        /// Specifies control as being usable as a main content control
        /// </summary>
        Content = 1,
        /// <summary>
        /// Specifies control as being the master content control and created by default when a module is enabled
        /// </summary>
        ContentMaster = 2,
    }
}
