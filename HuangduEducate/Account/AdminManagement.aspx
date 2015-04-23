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
        <asp:Button ID="logoffBtn" CssClass="button button-rounded button-flat-primary login-btn btn-position" style = "margin-left: 400px;" Text="登出" runat="server"
         onclick="logoffBtn_Click" />
            <div>
                <asp:Label Text="添加学生" ID="addStudent" runat="server" />
                <hr />
                &nbsp; &nbsp;&nbsp; &nbsp;学号：<asp:TextBox ID="studentID_TB" runat="server"></asp:TextBox>
                <br />
                <br />
                &nbsp; &nbsp;&nbsp; &nbsp;姓名：<asp:TextBox ID="name_TB" runat="server"></asp:TextBox>
                <br />
                <br />
                &nbsp; &nbsp;&nbsp; &nbsp;班级：
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
                <br />
                <asp:Button ID="addStudentBtn" runat="server" Text="提交" OnClientClick="return confirm('确认添加?');"  OnClick="addStudent_Click" />
            </div>
            <br />
            <br />
            <div>
            <asp:Label Text="修改学生" ID="changeStudent" runat="server" />
            <hr />
            &nbsp; &nbsp;&nbsp; &nbsp;学号：<asp:TextBox ID="changeStudentID_TB" runat="server"></asp:TextBox>
            <br />
            <br />
            当前年级：
            <asp:DropDownList ID="changeCurrentGrade_DD" runat="server">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            当前班级：
            <asp:DropDownList ID="changeCurrentClass_DD" runat="server">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
             </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="changeStudentBtn" runat="server" Text="提交" OnClientClick="return confirm('确认修改?');"  OnClick="changeStudent_Click" />
            </div>
            <br />
            <br />
            <div>
                <asp:Label Text="添加班级" ID="addClass" runat="server"/>
                <hr />
                &nbsp; &nbsp;&nbsp; &nbsp;班级：
                <asp:DropDownList ID="addClassClass_DD" runat="server">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
                入学年份：
                <asp:DropDownList ID="addClassEnterTime_DD" runat="server">
                    <asp:ListItem>2009</asp:ListItem>
                    <asp:ListItem>2010</asp:ListItem>
                    <asp:ListItem>2011</asp:ListItem>
                    <asp:ListItem>2012</asp:ListItem>
                    <asp:ListItem>2013</asp:ListItem>
                    <asp:ListItem>2014</asp:ListItem>
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
                </asp:DropDownList>
                <br />
                <br />
                <asp:Button ID="addClassBtn" Text="提交" OnClick="addClassBtn_Click" OnClientClick="return confirm('确认添加?');" runat="server" />
                <asp:Label ID="addClassResultMsg" runat="server" />
            </div>
            <br />
            <br />
            <div>
               <asp:Label Text="修改班级密码" ID="changePassword" runat="server" />
                <hr />
                班级账号：
                <asp:TextBox ID="changePasswordAccountNum_TB" runat="server"/>
                <br />
                <br />
                &nbsp;&nbsp; 原密码：
                <asp:TextBox ID="oldPassword_TB" runat="server" TextMode="Password"/>
                <br />
                <br />
                &nbsp;&nbsp; 新密码：
                <asp:TextBox ID="newPassword_TB" runat="server" TextMode="Password"/>
                <br />
                <br />
                确认密码：
                <asp:TextBox ID="newPasswordConfirm_TB" runat="server" TextMode="Password"/>
                <br />
                <br />
                <asp:Label ID="changeClassErrorMsg" runat="server"></asp:Label>
                <asp:Button ID="changeClassPasswordBtn" runat="server" Text="修改" OnClientClick="return confirm('确认修改?');" OnClick="changeCLassPasswordBtn_Click" />
            </div>
            <br />
            <br />
            <div>
               <asp:Label Text="修改管理员密码" ID="Label2" runat="server" />
                <hr />
               &nbsp; &nbsp;原密码：
                <asp:TextBox ID="oldAdminPassword_TB" runat="server" TextMode="Password" />
                <br />
                <br />
               &nbsp; &nbsp;新密码：
                <asp:TextBox ID="newAdminPassword_TB" runat="server" TextMode="Password"/>
                <br />
                <br />
                确认密码：
                <asp:TextBox ID="newAdminPasswordConfirm_TB" runat="server" TextMode="Password"/>
                <br />
                <br />
                <asp:Label ID="changeAdminErrorMsg" runat="server"></asp:Label>
                <asp:Button ID="changeAdminPasswordBtn" runat="server" Text="修改" OnClick="changeAdminPasswordBtn_Click" />
            </div>
            <br />
            <br />
            <div>
               <asp:Label Text="修改条目" ID="changeCatalog" runat="server" />
               <hr />
               <asp:Button ID="changeLevelStructureBtn" runat="server" Text="修改" OnClick="changeLevelStructureBtn_Click" />
            </div>
            <br />
            <br />
            <div>
               <asp:Label Text="修改年级" ID="Label1" runat="server" />
               <hr />
               <asp:Button ID="changeGrade" Text="修改" OnClientClick="return confirm('点击修改年级之后，所有年级将上升一级，而所有过期信息将被清空，确认修改?');"  OnClick="changeGrade_Click" runat="server" />
            </div>
            <br />
            <br />
            <div>
               <asp:Label Text="修改学期" ID="Label3" runat="server" />
               <hr />
               <asp:Button ID="changeTerm" Text="修改" OnClientClick="return confirm('点击修改学期之后，本学期所有学生成绩情况将会被清空，确认修改学期?');"  OnClick="changeTerm_Click" runat="server" />
            </div>
        </div>
        </form>
    </div>
</body>
</html>
