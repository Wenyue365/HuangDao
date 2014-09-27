using System;
using System.Web;

/// Do not use any namespace 
/// and this *.cs file should put into App_Code folder

/* edit the web.config file as follow:
<system.webServer>
    <handlers>
    <!-- Http Handler for HTML request. add by Jenseng.-->
    <add name="MyHttpHandler" verb="*" path="*.html" type="MyHttpHandler"/>
    </handlers>
</system.webServer>
*/
public class MyHttpHandler : IHttpHandler
{
    public bool IsReusable
    {
        get { return true; }
    }

    public void ProcessRequest(HttpContext context)
    {

    }
}

/* 
 * edit the web.config file as follow:
<system.webServer>
    <modules>
     <add name="MyHttpModule" type="MyHttpModule"/>
    </modules>
<system.webServer>
*/

/// <summary>
/// Summary description for clsLifeCycle
/// </summary>
public class MyHttpModule : IHttpModule
{
    private HttpApplication httpApp;
    public MyHttpModule()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void Dispose()
    {
        //throw new Exception("The method or operation is not implemented.");
    }

    public void Init(HttpApplication context)
    {
        this.httpApp = context;

        httpApp.AuthenticateRequest += new EventHandler(OnAuthentication);
        httpApp.AuthorizeRequest += new EventHandler(OnAuthorization);
        httpApp.BeginRequest += new EventHandler(OnBeginrequest);
        httpApp.EndRequest += new EventHandler(OnEndRequest);
        httpApp.ResolveRequestCache += new EventHandler(OnResolveRequestCache);
        httpApp.AcquireRequestState += new EventHandler(OnAcquireRequestState);
        httpApp.PreRequestHandlerExecute += new EventHandler(OnPreRequestHandlerExecute);
        httpApp.PostRequestHandlerExecute += new EventHandler(OnPostRequestHandlerExecute);
        httpApp.ReleaseRequestState += new EventHandler(OnReleaseRequestState);
        httpApp.UpdateRequestCache += new EventHandler(OnUpdateRequestCache);
    }
    void OnUpdateRequestCache(object sender, EventArgs a)
    {

    }
    void OnReleaseRequestState(object sender, EventArgs a)
    {
    }
    void OnPostRequestHandlerExecute(object sender, EventArgs a)
    {
    }
    void OnPreRequestHandlerExecute(object sender, EventArgs a)
    {

    }
    void OnAcquireRequestState(object sender, EventArgs a)
    {
    }
    void OnResolveRequestCache(object sender, EventArgs a)
    {

    }
    void OnAuthorization(object sender, EventArgs a)
    {
    }
    void OnAuthentication(object sender, EventArgs a)
    {

    }
    void OnBeginrequest(object sender, EventArgs a)
    {

    }
    void OnEndRequest(object sender, EventArgs a)
    {

    }

}