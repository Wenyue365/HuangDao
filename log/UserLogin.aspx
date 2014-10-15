<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userLogin.aspx.cs" Inherits="HuangDao.log.UserLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="../jslib/lzclib.js"></script>

    <title>问曰365 管理员登录</title>
</head>
<body>
    <script type="text/javascript">
        function initPage()
        {
            $E("promptText").innerHTML = $E("promptTextValue").value;
        }
    </script>
    <style type="text/css">
        .login_panel{
            display:inline-block;
        }
        .login_panel li{
            list-style:none;
            vertical-align:middle;
            margin:4px 7px 8px 4px;
        }
        .login_panel span{
            display:inline-block;
            width:4em;
            padding:4px 7px 2px 4px;
            font-weight:bold;
        }
        .login_panel input{
            padding:4px 7px 2px 4px;
            font-weight:bold;
        }

    </style>
    <form id="form1" runat="server">
        <input type="hidden" id="promptTextValue" runat="server" />
    <div class="prompt_info_panel">
        <span id="promptText">请输入用户名、密码登录管理后台。</span>
    </div>
    <div id="loginPanel" class="login_panel">
    <ul>
        <li><span>用户名</span><asp:TextBox ID="txbUserName" runat="server"></asp:TextBox></li>
        <li><span>密  码</span><asp:TextBox ID="txbPassword" runat="server"></asp:TextBox></li>
        <li style="text-align:center"><asp:Button ID="btnLogin" runat="server" Text="登录" OnClick="btnLogin_Click" /></li>

    </ul>
    </div>
    </form>
    <script type="text/javascript">
        initPage();
    </script>
</body>
</html>
