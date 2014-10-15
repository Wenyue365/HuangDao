<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HuangliMgr.aspx.cs" Inherits="HuangDao.log.HuangliMgr" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>问曰365 管理后台</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnGenSitemap" runat="server" Text="创建网站地图" OnClick="btnGenSitemap_Click" />
    </div>
        <div>
            <asp:TextBox ID="txbResult" runat="server" Height="172px" Width="382px"></asp:TextBox>
        </div>
    </form>
</body>
</html>
