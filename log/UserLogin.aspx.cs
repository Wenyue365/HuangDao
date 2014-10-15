using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HuangDao.log
{
    public partial class UserLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string password = txbPassword.Text;

            if (userName.Trim() == "" || password.Trim() == "")
            {
                promptTextValue.Value = "用户名、密码不能为空";
            }
            else
            {
                bool validUserName = checkUserName(userName);
                if (validUserName)
                {
                    if (checkUserPassword(userName, password))
                    {
                        updateUserInfo(userName);
                        Response.Redirect("HuangliMgr.aspx?userid=" + userName);
                    }
                    else
                    {
                        promptTextValue.Value = "密码不正确，请重试。";
                    }
                }
                else
                {
                    promptTextValue.Value = "用户不存在。";
                }
            }
        }

        private void updateUserInfo(string userName)
        {
            this.Session.Add("user_name", userName);
            this.Session.Add("login_time", DateTime.Now);
        }

        private bool checkUserPassword(string userName, string password)
        {
            bool valid = false;
            if (password.ToLower() == "lzc365" || password.ToLower() == "hyj365")
            {
                valid = true;
            }

            return valid;
        }

        private bool checkUserName(string userName)
        {
            bool valid = false;

            if (userName.ToLower() == "lzc" || userName.ToLower() == "hyj")
            {
                valid = true;
            }

            return valid;
        }
    }
}