<%@ Page Language="C#" AutoEventWireup="true" CodeFile="main.aspx.cs"
    Inherits="Account_main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="css/buttons.css" />
    <link rel="Stylesheet" href="css/begin.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:Button id="studentBtn" CssClass="button button-rounded button-flat-primary login-btn studentcss" text="学生登录" runat="server" OnClick="studentBtn_Click"/>
    <asp:Button id="teacherBtn" CssClass="button button-rounded button-flat-primary login-btn classcss" text="班级登录" runat="server" OnClick="teacherBtn_Click"/>
    <asp:Button ID="adminBtn" CssClass="button button-rounded button-flat-primary login-btn admincss" text="管理员登陆" runat="server" OnClick="adminBtn_Click" />
    </form>
</body>
</html>
