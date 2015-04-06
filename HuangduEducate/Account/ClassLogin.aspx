﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClassLogin.aspx.cs" Inherits="Account_ClassLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="css/buttons.css" />
    <link rel="Stylesheet" href="css/main.css" />
</head>
<body>
    <form id="form1" class="login-form" runat="server">
        <asp:TextBox ID="classID_TB" placeholder="班级用户名" runat="server"></asp:TextBox> <br />
        <asp:TextBox ID="password_TB" placeholder="密码" runat="server" TextMode="Password"></asp:TextBox>
        <asp:Label ID="errorMessage" runat="server"></asp:Label>  <br />
        <asp:Button CssClass="button button-rounded button-flat-action login-btn-student" ID="loginBtn" runat="server" Text="登录" OnClick="loginBtn_Click"/>
    </form>
</body>
</html>