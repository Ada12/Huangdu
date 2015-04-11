<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="Account_Test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Table ID="testTB1" runat="server">
        </asp:Table>
        <asp:Table ID="testTB2" runat="server">
        </asp:Table>
        
    </div>
    <div>
        <asp:TextBox ID="itemTextBox" runat="server"></asp:TextBox>
        <asp:TextBox ID="subitemTextBox" runat="server"></asp:TextBox>
        <asp:TextBox ID="fiveTextBox" runat="server"></asp:TextBox>
        <asp:TextBox ID="fourTextBox" runat="server"></asp:TextBox>
        <asp:TextBox ID="threeTextBox" runat="server"></asp:TextBox>
        <asp:TextBox ID="twoTextBox" runat="server"></asp:TextBox>
        <asp:TextBox ID="oneTextBox" runat="server"></asp:TextBox>
        <asp:Button ID="submitButton" runat="server"  Text="Add Level" OnClick="sss"/>
    </div>
    <div>
        <asp:Label ID="toshow" runat="server"></asp:Label>
    </div>
    <div>
    <asp:DropDownList ID="ddlSubject" runat="server" OnSelectedIndexChanged="onSubjectChanged" AutoPostBack="true">
            <asp:ListItem>请选择</asp:ListItem>
            <asp:ListItem>语文</asp:ListItem>
            <asp:ListItem>数学</asp:ListItem>
            <asp:ListItem>英语</asp:ListItem>
            
        </asp:DropDownList>
        <asp:Label runat="server" ID="ddlTextShow">ffff</asp:Label>
    </div>
    </form>
</body>
</html>
