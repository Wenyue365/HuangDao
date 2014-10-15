using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace HuangDao.log
{
    public partial class HuangliMgr : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!isLoginUser())
            {
                Response.Redirect("UserLogin.aspx");
            }
        }

        // 判断用户是否为合法的（已登录）用户
        public static bool isLoginUser()
        {
            bool isLogined = false;

            string userName = (string)HttpContext.Current.Session["user_name"];
            object loginTime = HttpContext.Current.Session["login_time"];

            if (userName != null)
            {
                if (loginTime != null)
                {
                    TimeSpan tmSpan = DateTime.Now - (DateTime)loginTime;
                    if (tmSpan.Minutes <= 30)
                    {
                        isLogined = true;
                    }
                }
            }

            return isLogined;
        }

        protected void btnGenSitemap_Click(object sender, EventArgs e)
        {
            SiteMap sm = new SiteMap();
            string siteMapsFilePath = sm.BuildSitemap();
            if (siteMapsFilePath !=  null)
            {
                txbResult.Text = "创建网站地图成功: " +siteMapsFilePath +"\n";
            }
            else
            {
                txbResult.Text = "创建网站地图失败\n";
            }
        }
    }
}