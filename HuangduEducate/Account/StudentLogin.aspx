<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentLogin.aspx.cs"
    Inherits="Account_StudentLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title></title>
    <link rel="Stylesheet" href="css/buttons.css" />
    <link rel="Stylesheet" href="css/main.css" />
</head>
<body>
    <form id="form1" class="login-form" runat="server">  
                <asp:TextBox ID="studentID_TB" Text="" placeholder="学生学号" CssClass="tb1" runat="server"></asp:TextBox>
                <asp:TextBox ID="name_TB" Text="" placeholder="学生姓名" CssClass="tb2" runat="server"></asp:TextBox>
                <asp:Label ID="errorMessage" CssClass="l1" runat="server"></asp:Label>
                <asp:Button class="button button-rounded button-flat-action login-btn-student lgb" ID="loginBtn" runat="server" Text="登录" OnClick="loginBtn_Click"/>  
    </form> 

</body>
</html>
