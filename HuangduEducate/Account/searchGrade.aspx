<%@ Page Language="C#" AutoEventWireup="true" CodeFile="searchGrade.aspx.cs" Inherits="search_search" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="css/purecss/pure-min.css" />
    <link rel="stylesheet" href="css/purecss/tables-min.css" />
    <link rel="stylesheet" href="css/searchGrade.css" />
    <link rel="Stylesheet" href="css/buttons.css" />
</head>
<body>
    <form id="resultform" runat="server">
        <div class="state-container">
        <asp:Table CssClass="pure-table pure-table-bordered" ID="titleTable" runat="server">
            <asp:TableRow CssClass="">
                <asp:TableHeaderCell>学号</asp:TableHeaderCell>
                <asp:TableCell></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow CssClass="">
                <asp:TableHeaderCell>姓名</asp:TableHeaderCell>
                <asp:TableCell></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Button CssClass="button button-rounded button-flat-primary login-btn btn-position" Text="登出" runat="server"
         onclick="logoffBtn_Click" />
        </div>
    <div class="whole-layout ">
     <div class="grade-table-container">
            <asp:Table CssClass="pure-table pure-table-bordered grade-table" ID="resulttable" runat="server">
                <asp:TableHeaderRow CssClass="table-grade-head-row">
                    <asp:TableHeaderCell CssClass="table-grade-col">学号</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="table-grade-col">星期</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="table-grade-col">语文</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="table-grade-col">数学</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="table-grade-col">英语</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>
    
    <div class="chart-container">
        <asp:Chart ID="ChartChinese" CssClass="grade-chart" runat="server" Width="570px" >
            <Titles>
                <asp:Title Font="微软雅黑, 24pt"></asp:Title>
            </Titles>          
            <series>
                <asp:Series ChartType="Line" Name="Series1">
                </asp:Series>
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </chartareas>
        </asp:Chart>
        <br />
        <asp:Chart ID="ChartMath" CssClass="grade-chart" runat="server" Width="570px" > 
            <Titles>
                <asp:Title Font="微软雅黑, 24pt"></asp:Title>
            </Titles>                   
            <series>
                <asp:Series ChartType="Line" Name="Series1">
                </asp:Series>
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </chartareas>
        </asp:Chart>
        <br />
        <asp:Chart ID="ChartEnglish" CssClass="grade-chart" runat="server" Width="570px" > 
            <Titles>
                <asp:Title Font="微软雅黑, 24pt"></asp:Title>
            </Titles>                   
            <series>
                <asp:Series ChartType="Line" Name="Series1">
                </asp:Series>
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </chartareas>
        </asp:Chart>
    </div>
    </div>
        
    
    </form>
</body>
</html>
