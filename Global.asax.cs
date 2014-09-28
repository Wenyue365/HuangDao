using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;


    public class Global : System.Web.HttpApplication
    {
        public override void Init()
        {
        }

        protected void Application_Start(object sender, EventArgs e)
        {
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpApplication httpApp = (HttpApplication)sender;
            string trgUrl = HuangDao.Modules.UrlRouter.getUrl(httpApp.Context.Request.RawUrl);
            if (trgUrl != null)
            {
                httpApp.Context.RewritePath(trgUrl);
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
