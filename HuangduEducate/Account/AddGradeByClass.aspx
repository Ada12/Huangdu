<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddGradeByClass.aspx.cs" Inherits="Account_AddGradeByClass" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" href="css/buttons.css" />
    <link rel="Stylesheet" href="css/input.min.css" />
    <link rel="Stylesheet" href="css/AddGrade.css" />

</head>
<body>
    <form id="form1" class="login-form" runat="server">
    <div class="teacher-info-container">
    工号： <asp:Label ID="teacherID_LB" runat="server" />
    <br />
    欢迎您，<asp:Label ID="teacherName_LB" runat="server" />老师！
    </div>
    <br />
    <br />
    <br />
    <asp:Button ID="Button1" CssClass="button button-rounded button-flat-primary login-btn btn-position" Text="登出" runat="server"
         onclick="logoffBtn_Click" />
    <div class="form-container">
        <asp:DropDownList ID="subject_DD" runat="server">
            <asp:ListItem>语文</asp:ListItem>
            <asp:ListItem>数学</asp:ListItem>
            <asp:ListItem>英语</asp:ListItem> 
        <asp:TextBox ID="weekNum_TB" CssClass="input-weeknum" placeholder="周" runat="server"></asp:TextBox><br />
        <div class="select_style">
        <asp:DropDownList ID="ClassGrade" runat="server">
            <asp:ListItem>一年级</asp:ListItem>
            <asp:ListItem>二年级</asp:ListItem>
            <asp:ListItem>三年级</asp:ListItem>
            <asp:ListItem>四年级</asp:ListItem>
            <asp:ListItem>五年级</asp:ListItem>
            <asp:ListItem>六年级</asp:ListItem>
         </asp:DropDownList>
        
         </asp:DropDownList>
         <asp:TextBox ID="grade_TB" placeholder="分数" CssClass="input-score" runat="server"></asp:TextBox>
         </div>
         <br />
         <asp:Button ID="submitBtn" CssClass="button button-rounded button-flat-primary input-submit" runat="server"  Text="提交" OnClick="submitBtn_Click"/>  <br />
        </div>
    </form>
    
    <div id="qys-add">
    </div>
</body>
</html>
