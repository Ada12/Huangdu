<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClassLogin.aspx.cs"
    Inherits="Account_ClassLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="css/buttons.css" />
    <link rel="Stylesheet" href="css/main.css" />
</head>
<body>
    <form id="form1" class="login-form" runat="server">
        <asp:TextBox ID="classID_TB" CssClass="tb1" placeholder="班级用户名" runat="server"></asp:TextBox>
        <asp:TextBox ID="password_TB" CssClass="tb2" placeholder="密码" runat="server" TextMode="Password"></asp:TextBox>
        <asp:Label ID="errorMessage" CssClass="l1" runat="server"></asp:Label>
        <asp:Button CssClass="button button-rounded button-flat-action login-btn-student lgb" ID="loginBtn" runat="server" Text="登录" OnClick="loginBtn_Click"/>
    </form>
</body>
</html>
