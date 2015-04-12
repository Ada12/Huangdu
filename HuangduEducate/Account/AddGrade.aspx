<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddGrade.aspx.cs" Inherits="Account_AddGrade" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="css/buttons.css" />
    <link rel="Stylesheet" href="css/input.min.css" />
    <link rel="Stylesheet" href="css/AddGrade.css" />
    <script src="css/jquery-1.4.2.js" type="text/javascript"></script>  
    <script type="text/javascript">

        $(function () {
            $("#test").live("click", function () {
                var t = document.getElementById("ddl:200635001:0").selectedIndex;
                var table = document.getElementById("classListTable");
                var tableRowNum = table.rows.length;
                var tableColNum = table.rows.item(2).cells.length - 2;

                var studentID = new Array();
                for (var i = 2; i < tableRowNum; i++) {
                    var trob = document.getElementById(i);
                    studentID.push(trob.innerHTML);
                }
                var grade = "";
                var gradeInfo = new Array();
                for (var a = 0; a < studentID.length; a++) {
                    for (var b = 0; b < tableColNum; b++) {
                        var id = "ddl:" + studentID[a] + ":" + b;
                        var mygrade = document.getElementById(id).selectedIndex;
                        grade = grade + mygrade;
                    }
                    gradeInfo.push(grade);
                    grade = "";
                }

                var studentIDStr = studentID[0];
                for (var c = 1; c < studentID.length; c++) {
                    studentIDStr = studentIDStr + "_" + studentID[c];
                }

                var gradeInfoStr = gradeInfo[0];
                for (var d = 1; d < gradeInfo.length; d++) {
                    gradeInfoStr = gradeInfoStr + "_" + gradeInfo[d];
                }

                var info = {
                    week: $("#ddlWeek").val(),
                    subject: $("#ddlSubject").val(),
                    studentID: studentIDStr,
                    grade: gradeInfoStr
                }
                $.ajax({
                    type: 'POST',
                    url: 'Handler.ashx',
                    data: info,
                    success: function (data) {
                        //alert("haha");
                        alert(data);
                    }
                });
            });
        });
        
    </script>

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
        <input type="button" name="test" id="test" value="保存"/> 
    </form>
</body>
</html>
