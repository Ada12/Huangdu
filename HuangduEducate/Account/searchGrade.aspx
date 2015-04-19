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
                <asp:TableHeaderCell>周</asp:TableHeaderCell>
                <asp:TableCell></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Button CssClass="button button-rounded button-flat-primary login-btn btn-position" Text="登出" runat="server"
         onclick="logoffBtn_Click" />
        </div>
    <div class="whole-layout ">
     <div class="grade-table-container">
            <h3>语文成绩表</h3>
            <asp:Table CssClass="pure-table pure-table-bordered grade-table" ID="chineseGradeTable" runat="server">
                <asp:TableHeaderRow CssClass="table-grade-head-row" ID="gradeHeaderRow0" runat="server">
                    <asp:TableHeaderCell CssClass="table-grade-col"></asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="table-grade-col"></asp:TableHeaderCell>
                </asp:TableHeaderRow>
                <asp:TableHeaderRow runat="server" ID="gradeHeaderRow1"></asp:TableHeaderRow>
            </asp:Table>
            <br />
            <h3>语文成绩排名表</h3>
            <asp:Table CssClass="pure-table pure-table-bordered grade-table" ID="chineseRankTable" runat="server">
            
                <asp:TableHeaderRow CssClass="table-grade-head-row" ID="rankHeaderRow0" runat="server">
                    <asp:TableHeaderCell CssClass="table-grade-col"></asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="table-grade-col"></asp:TableHeaderCell>
                </asp:TableHeaderRow>
                <asp:TableHeaderRow ID="rankHeaderRow1" runat="server"></asp:TableHeaderRow>
            </asp:Table>
            <br />
            <h3>数学成绩表</h3>
            <asp:Table CssClass="pure-table pure-table-bordered grade-table" ID="mathGradeTable" runat="server">
                <asp:TableHeaderRow CssClass="table-grade-head-row" ID="gradeHeaderRow2" runat="server">
                    <asp:TableHeaderCell CssClass="table-grade-col"></asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="table-grade-col"></asp:TableHeaderCell>
                </asp:TableHeaderRow>
                <asp:TableHeaderRow ID="gradeHeaderRow3" runat="server"></asp:TableHeaderRow>
            </asp:Table>
            <br />
            <h3>数学成绩排名表</h3>
            <asp:Table CssClass="pure-table pure-table-bordered grade-table" ID="mathRankTable" runat="server">
            
                <asp:TableHeaderRow CssClass="table-grade-head-row" ID="rankHeaderRow2" runat="server">
                    <asp:TableHeaderCell CssClass="table-grade-col"></asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="table-grade-col"></asp:TableHeaderCell>
                </asp:TableHeaderRow>
                <asp:TableHeaderRow ID="rankHeaderRow3" runat="server"></asp:TableHeaderRow>
            </asp:Table>
            <br />
            <h3>英语成绩表</h3>
            <asp:Table CssClass="pure-table pure-table-bordered grade-table" ID="englishGradeTable" runat="server">
            
                <asp:TableHeaderRow CssClass="table-grade-head-row" ID="gradeHeaderRow4" runat="server">
                    <asp:TableHeaderCell CssClass="table-grade-col"></asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="table-grade-col"></asp:TableHeaderCell>
                </asp:TableHeaderRow>
                <asp:TableHeaderRow ID="gradeHeaderRow5" runat="server"></asp:TableHeaderRow>
            </asp:Table>
            <br />
            <h3>英语成绩排名表</h3>
            <asp:Table CssClass="pure-table pure-table-bordered grade-table" ID="englishRankTable" runat="server">
            
                <asp:TableHeaderRow CssClass="table-grade-head-row" ID="rankHeaderRow4" runat="server">
                    <asp:TableHeaderCell CssClass="table-grade-col"></asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="table-grade-col"></asp:TableHeaderCell>
                </asp:TableHeaderRow>
                <asp:TableHeaderRow ID="rankHeaderRow5" runat="server"></asp:TableHeaderRow>
            </asp:Table>
            <br />
        </div>
        <div runat="server" id="cChartRoot">
            
            
        </div>
        <div runat="server" id="mChartRoot">
            
            
        </div>
        <div  runat="server" id="eChartRoot">
            
            
        </div>
    </div>
        
    
    </form>
</body>
</html>
