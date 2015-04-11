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
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="updtpnl" runat="server">
            <ContentTemplate>
                <fieldset>
                    <asp:DropDownList ID="ddlWeek" runat="server" OnSelectedIndexChanged="onWeekChanged" AutoPostBack="true">
                        <asp:ListItem Value="none">请选择</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlSubject" runat="server" OnSelectedIndexChanged="onSubjectChanged" AutoPostBack="true">
                        <asp:ListItem Value="none">请选择</asp:ListItem>
                        <asp:ListItem Value="chinese">语文</asp:ListItem>
                        <asp:ListItem Value="math">数学</asp:ListItem>
                        <asp:ListItem Value="english">英语</asp:ListItem>
                    </asp:DropDownList>
        
                    <asp:Table ID="classListTable" runat="server" >
                        <asp:TableHeaderRow ID="classHeaderRow1" runat="server"></asp:TableHeaderRow>
                        <asp:TableRow ID="classHeaderRow2" runat="server"></asp:TableRow>
                    </asp:Table>
                    <br />
                    <br />
                    
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Button ID="saveButton" runat="server" Text="保存" OnClick="onSaveButtonClick" />
    </form>
</body>
</html>
