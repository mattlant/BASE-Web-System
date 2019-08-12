using System;
using System.Collections.Generic;
using System.Text;

namespace BASE.Web.UI
{
    class CuteEditorHelper
    {
        public static String BMLToHTML(String input)
        {
            //Get the control type
            int start = input.IndexOf(":") + 1;
            int length = input.IndexOf(" ") - start;
            String controlType = input.Substring(start, length);

            //Get the rest of the tag and make double quotes single
            start = input.IndexOf("<") + 1;
            length = input.Length - start - 2;
            String altTag = input.Substring(start, length);
            altTag = altTag.Replace("\"", "\'");

            return "<img src=\"ControlPlaceholder.jpg?CType=" + controlType + "\" alt=\"" + altTag + "\" />";
        }

        public static String HTMLToBML(String input)
        {
            int start = input.IndexOf("base:");
            int length = input.IndexOf("\"", start) - start;
            String altTag = input.Substring(start, length);
            altTag = altTag.Replace("\'", "\"");

            return "<" + altTag + "/>";
        }
    }
}
