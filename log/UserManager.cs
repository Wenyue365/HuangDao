using System;
using System.Web;

namespace HuangDao.log
{
    public class UserManager
    {
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
    }
}
