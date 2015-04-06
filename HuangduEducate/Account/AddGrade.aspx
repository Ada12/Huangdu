<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddGrade.aspx.cs" Inherits="Account_AddGrade" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="css/buttons.css" />
    <link rel="Stylesheet" href="css/input.min.css" />
    <link rel="Stylesheet" href="css/AddGrade.css" />

</head>
<body>
    <form id="form1" class="login-form" runat="server">
    <div class="teacher-info-container">
    班级： <asp:Label ID="class_LB" runat="server" />
    <br />
    年级：<asp:Label ID="grade_LB" runat="server" />
    </div>
    <br />
    <br />
    <br />
    <asp:Button ID="Button1" CssClass="button button-rounded button-flat-primary login-btn btn-position" Text="登出" runat="server"
         onclick="logoffBtn_Click" />
    <div class="form-container">
         <asp:TextBox ID="studentID_TB" CssClass="input-studentid" placeholder="学号" runat="server"></asp:TextBox>
         <asp:TextBox ID="weekNum_TB" CssClass="input-weeknum" placeholder="周" runat="server"></asp:TextBox><br />
         </div>
        <div class="select_style">
        <asp:DropDownList ID="subject_DD" runat="server">
            <asp:ListItem>语文</asp:ListItem>
            <asp:ListItem>数学</asp:ListItem>
            <asp:ListItem>英语</asp:ListItem>
         </asp:DropDownList>
         <asp:TextBox ID="grade_TB" placeholder="分数" CssClass="input-score" runat="server"></asp:TextBox>
         </div>
         <br />
         <asp:Button ID="submitBtn" CssClass="button button-rounded button-flat-primary input-submit" runat="server"  Text="提交" OnClick="submitBtn_Click"/>  <br />
    </form>
    </div>
</body>
</html>
