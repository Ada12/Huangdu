<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminManagement.aspx.cs"
    Inherits="Account_AdminManagement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="css/admin.css" />
</head>
<body>
    <div class="reg_position">
        <form id="form1" runat="server">
        <div id="tab" style="margin-left: 460px; margin-top: 20px">
            <div>
                <asp:Label Text="添加学生" ID="addStudent" runat="server" />
                <hr />
                学号：<asp:TextBox ID="studentID_TB" runat="server"></asp:TextBox>
                <br />
                姓名：<asp:TextBox ID="name_TB" runat="server"></asp:TextBox>
                <br />
                班级：
                <asp:DropDownList ID="class_DD" runat="server">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                </asp:DropDownList>
                <br />
                入学年份：
                <asp:DropDownList ID="entertime_DD" runat="server">
                    <asp:ListItem>2015</asp:ListItem>
                    <asp:ListItem>2016</asp:ListItem>
                    <asp:ListItem>2017</asp:ListItem>
                    <asp:ListItem>2018</asp:ListItem>
                    <asp:ListItem>2019</asp:ListItem>
                    <asp:ListItem>2020</asp:ListItem>
                    <asp:ListItem>2021</asp:ListItem>
                    <asp:ListItem>2022</asp:ListItem>
                    <asp:ListItem>2023</asp:ListItem>
                    <asp:ListItem>2024</asp:ListItem>
                    <asp:ListItem>2025</asp:ListItem>
                    <asp:ListItem>2026</asp:ListItem>
                    <asp:ListItem>2027</asp:ListItem>
                    <asp:ListItem>2028</asp:ListItem>
                    <asp:ListItem>2029</asp:ListItem>
                    <asp:ListItem>2030</asp:ListItem>
                </asp:DropDownList>
                <br />
                <asp:Button ID="Button1" runat="server" Text="提交" OnClick="addStudent_Click" />
            </div>
            <br />
            <br />
            <div>
               <asp:Label Text="修改密码" ID="changePassword" runat="server" />
                <hr />
                年级：
                <asp:DropDownList ID="changeGrade_DD" runat="server">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
                班级：
                <asp:DropDownList ID="changeClass_DD" runat="server">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                </asp:DropDownList>
                <br />
                <asp:Label ID="changeErrorMessage" runat="server"></asp:Label>
                <asp:Button ID="changePasswordBtn" runat="server" Text="修改" OnClick="changePasswordBtn_Click" />
            </div>
            <br />
            <br />
            <div>
               <asp:Label Text="修改条目" ID="changeCatalog" runat="server" />
               <hr />
            </div>
            <br />
            <br />
            <div>
               <asp:Label Text="修改年级" ID="Label1" runat="server" />
               <hr />
               <asp:Button ID="changeGrade" Text="修改" OnClick="changeGrade_Click" runat="server" />
            </div>
        </div>
        </form>
    </div>
</body>
</html>
