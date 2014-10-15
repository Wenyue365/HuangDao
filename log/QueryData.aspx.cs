using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HuangDao;

namespace HuangDao.log
{
    public partial class QueryData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UserManager.isLoginUser())
            {
                Response.Redirect("UserLogin.aspx");
            }
        }

        protected void btnQueryWords_Click(object sender, EventArgs e)
        {
            HdDBHelper db = new HdDBHelper();


        }
    }
}