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
        <asp:Table ID="classListTable" runat="server">
            <asp:TableHeaderRow ID="classHeaderRow1" runat="server">
                <asp:TableHeaderCell RowSpan="2">学号</asp:TableHeaderCell>
                <asp:TableHeaderCell RowSpan="2">姓名</asp:TableHeaderCell>
                
            </asp:TableHeaderRow>
            <asp:TableRow ID="classHeaderRow2" runat="server">
                 
            </asp:TableRow>
        </asp:Table>
    </form>
</body>
</html>
