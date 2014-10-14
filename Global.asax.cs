using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

// DO NOT USE NAME SPACE HERE ! SO default System.Web namespace will be used
public class Global : System.Web.HttpApplication
{
    public override void Init()
    {

    }
    void httpApp_MapRequestHandler(object sender, EventArgs e)
    {
        
    }

    protected void Session_Start(object sender, EventArgs e)
    {

    }

    protected void Application_BeginRequest(object sender, EventArgs e)
    {
        HttpApplication httpApp = (HttpApplication)sender;
        HttpContext context = httpApp.Context;

        string filePath = context.Request.FilePath;
        string fileExtension = VirtualPathUtility.GetExtension(filePath);
        if (fileExtension.Equals("")) // Handle request without file-extension
        {
            string trgUrl = HuangDao.Modules.UrlRouter.getUrl(httpApp.Context.Request.RawUrl);
            if (trgUrl != null)
            {
                httpApp.Context.RewritePath(trgUrl);
            }
        }
        else if (fileExtension.Equals(".aspx"))
        {
            if (filePath.IndexOf("default.aspx") >= 0) // 对于 default.aspx 的页面请求，重写到 huangli.aspx 页面 
            {
                httpApp.Context.RewritePath("huangli.aspx");
            }
            else
            {
                string trgUrl = HuangDao.Modules.UrlRouter.getUrl(httpApp.Context.Request.RawUrl);
                if (trgUrl != null)
                {
                    httpApp.Context.RewritePath(trgUrl);
                }
            }
        }
    }

    protected void Application_AuthenticateRequest(object sender, EventArgs e)
    {

    }

    protected void Application_Error(object sender, EventArgs e)
    {

    }

    protected void Session_End(object sender, EventArgs e)
    {

    }

    protected void Application_End(object sender, EventArgs e)
    {

    }
}
