using System;
using System.IO;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace BASE.Web.EndPoints
{
	public class DefaultFileHandler : IHttpHandler
	{

		public bool IsReusable
		{
			get { return false; }
		}

		public void ProcessRequest(HttpContext context)
		{
			FileInfo file = null;
			BASEApplication app = (BASEApplication)context.ApplicationInstance;
			Uri url = app.Request.Url;

			// get the filename from the querystring
			string filename = url.AbsolutePath;


            // Obviously, if we had to check for filename exclusion, it would be done in here
            // before the physical or dynamic check get processed.
			// We need to check only the first level of subnames in a URL. 
            // Segments are like this: mattlant.com/dev/hello/world.htm: [0] = '/' [1] = 'dev/' [2] = 'hello/' [3] = 'world.htm'
			if (url.Segments.Length > 1 && !app.BASERequest.IsRootExclusion && !BASE.Configuration.ConfigurationManager.Current.IsSubExclusion(url.Segments[1]))
            {
                // The filename is NOT excluded. SO WE NEED TO TRANSLATE IT to use the current PHYSICAL SITES SECTION path
                file = new FileInfo(app.BASERequest.PhysicalSectionPath + filename);

                // Log this request.
                Logging.Logger.Log(string.Format("DefaultFileHandler: URL REMAPPED: {0}, {1}", url.ToString(), file.FullName));


            }
			else			// If its still an exclusion we still resolve to the physical location in the root folder.
            {
                // The file is a exclusion. Let process this exclusion as needed.
                //TODO: We only return the file this points to if not excluded.
				//Exclusions are just indicators if we are to remap the URL to the Sites directory, or leave as the original.
				//This helps oin cases like CuteEditor, which will always be in the systems root folder, rather than in each sites home directory.
                file = new FileInfo(app.Request.PhysicalApplicationPath + filename);

                 // Log this request.
                Logging.Logger.Log(string.Format("DefaultFileHandler: URL NOT REMAPPED: {0}, {1}", url.ToString(), file.FullName));
           }
            if (!file.Exists)
            {
                context.Response.Write(string.Format("DefaultFileHandler: NOT FOUND(url)(phys): {0}, {1}", url.ToString(), file.FullName));
                Logging.Logger.Log(string.Format("DefaultFileHandler: NOT FOUND(url)(phys): {0}, {1}", url.ToString(), file.FullName));
                context.Response.StatusCode = 200;
                return;
            }
            // write it to the browser
            context.Response.Clear();
            context.Response.WriteFile(file.FullName);
            context.Response.End();
		}

	}
}
