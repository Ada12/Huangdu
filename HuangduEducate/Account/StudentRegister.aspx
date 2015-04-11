<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentRegister.aspx.cs" Inherits="Account_StudentRegister" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="css/buttons.css" />
    <link rel="Stylesheet" href="css/input.min.css" />
    <link rel="Stylesheet" href="css/studentRegister.css" />
</head>
<body>
<div class="reg_position">
    <form id="form1" runat="server">  
                <asp:TextBox ID="studentID_TB" placeholder="学号" runat="server"></asp:TextBox>
                <br />
                <asp:TextBox ID="name_TB" placeholder="姓名" runat="server"></asp:TextBox>
                <br />
                <asp:TextBox ID="class_TB" placeholder="班级" runat="server"></asp:TextBox>
                <br />
                <asp:TextBox ID="grade_TB" placeholder="年级" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="registerBtn" runat="server" Text="提交" OnClick="registerBtn_Click"/>  
    </form> 
</div>
</body>
</html>
