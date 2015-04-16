<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LevelStructureManageMent.aspx.cs" Inherits="Account_LevelStructureManageMent" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Table ID="lvsTable" runat="server">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>类别</asp:TableHeaderCell>
                <asp:TableHeaderCell>名称</asp:TableHeaderCell>
                <asp:TableHeaderCell>5分标准</asp:TableHeaderCell>
                <asp:TableHeaderCell>4分标准</asp:TableHeaderCell>
                <asp:TableHeaderCell>3分标准</asp:TableHeaderCell>
                <asp:TableHeaderCell>2分标准</asp:TableHeaderCell>
                <asp:TableHeaderCell>1分标准</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
        <br />
        <asp:Button ID="addNewRow" runat="server" Text="添加新项" OnClick="addNewRow_Click"/>
        <br />
        <br />
        <asp:Table ID="inputTable" runat="server">
            <asp:TableHeaderRow ID="iptRow" runat="server">
                <asp:TableHeaderCell>类别</asp:TableHeaderCell>
                <asp:TableHeaderCell>名称</asp:TableHeaderCell>
                <asp:TableHeaderCell>5分标准</asp:TableHeaderCell>
                <asp:TableHeaderCell>4分标准</asp:TableHeaderCell>
                <asp:TableHeaderCell>3分标准</asp:TableHeaderCell>
                <asp:TableHeaderCell>2分标准</asp:TableHeaderCell>
                <asp:TableHeaderCell>1分标准</asp:TableHeaderCell>
                <asp:TableCell ID="markCell" runat="server"></asp:TableCell>
            </asp:TableHeaderRow>
            <asp:TableRow ID="showRow" runat="server" >
                <asp:TableCell ID="SCi" runat="server"><asp:TextBox ID="STi" runat="server" TextMode="MultiLine"></asp:TextBox></asp:TableCell>
                <asp:TableCell ID="SCs" runat="server"><asp:TextBox ID="STs" runat="server" TextMode="MultiLine"></asp:TextBox></asp:TableCell>
                <asp:TableCell ID="SC1" runat="server"><asp:TextBox ID="ST5" runat="server" TextMode="MultiLine"></asp:TextBox></asp:TableCell>
                <asp:TableCell ID="SC2" runat="server"><asp:TextBox ID="ST4" runat="server" TextMode="MultiLine"></asp:TextBox></asp:TableCell>
                <asp:TableCell ID="SC3" runat="server"><asp:TextBox ID="ST3" runat="server" TextMode="MultiLine"></asp:TextBox></asp:TableCell>
                <asp:TableCell ID="SC4" runat="server"><asp:TextBox ID="ST2" runat="server" TextMode="MultiLine"></asp:TextBox></asp:TableCell>
                <asp:TableCell ID="SC5" runat="server"><asp:TextBox ID="ST1" runat="server" TextMode="MultiLine"></asp:TextBox></asp:TableCell>
                <asp:TableCell ID="SCb" runat="server"><asp:Button ID="submit" runat="server" Text="确定" OnClick="submit_Click"/></asp:TableCell>
                <asp:TableCell ID="SCc" runat="server"><asp:Button ID="cancel" runat="server" Text="取消" OnClick="Cancel_Click"/></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ID="errorMessageCell" runat="server"></asp:TableCell>
            </asp:TableRow>

        </asp:Table>
    </div>
    <div>
    <table id="changeTable" style="visibility:hidden">
	    <tr id="Tr1">
		<th>类别</th>
        <th>名称</th>
        <th>5分标准</th>
        <th>4分标准</th>
        <th>3分标准</th>
        <th>2分标准</th>
        <th>1分标准</th>
	    </tr>
        <tr id="Tr2">
		    <td id="Td2"><label id="HTA0" ></label></td>
            <td id="Td3"><label id="HTA1" ></label></td>
            <td id="Td4"><textarea name="HT2" rows="2" cols="20" id="HTA2"></textarea></td>
            <td id="Td5"><textarea name="HT3" rows="2" cols="20" id="HTA3"></textarea></td>
            <td id="Td6"><textarea name="HT4" rows="2" cols="20" id="HTA4"></textarea></td>
            <td id="Td7"><textarea name="HT5" rows="2" cols="20" id="HTA5"></textarea></td>
            <td id="Td8"><textarea name="HT6" rows="2" cols="20" id="HTA6"></textarea></td>
            <td id="Td9"><input type="button" name="JSsubmit" value="确定" id="JSsubmit" onclick="changeData()"/></td>
            <td id="Td10"><input type="button" name="JScancel" value="取消" id="JScancle" onclick="jsCancel()"/></td>
	    </tr>
        <tr>
		    <td id="Td11"></td>
	    </tr>
    </table>
    </div>
    </form>
    <script src="css/jquery-1.4.2.js" type="text/javascript"></script>
    <script type="text/javascript">
        function selectChangeRow(irow) {
            var char1 = document.getElementById("Td8").innerHTML;
            var jstable = document.getElementById("changeTable");
            jstable.style.visibility = "visible";
            document.getElementById("HTA0").innerHTML = document.getElementById(irow.toString() + ":0").innerHTML;
            document.getElementById("HTA1").innerHTML = document.getElementById(irow.toString() + ":1").innerHTML;
            document.getElementById("HTA2").value = document.getElementById(irow.toString() + ":2").innerHTML;
            document.getElementById("HTA3").value = document.getElementById(irow.toString() + ":3").innerHTML;
            document.getElementById("HTA4").value = document.getElementById(irow.toString() + ":4").innerHTML;
            document.getElementById("HTA5").value = document.getElementById(irow.toString() + ":5").innerHTML;
            document.getElementById("HTA6").value = document.getElementById(irow.toString() + ":6").innerHTML;
        }

        function changeData() {
            var info = {
                operation: "change",
                item:       document.getElementById("HTA0").innerHTML,
                subitem:    document.getElementById("HTA1").innerHTML,
                five:       document.getElementById("HTA2").value,
                four:       document.getElementById("HTA3").value,
                three:      document.getElementById("HTA4").value,
                two:        document.getElementById("HTA5").value,
                one:        document.getElementById("HTA6").value

            }
            $.ajax({
                type: 'POST',
                url: 'LevelStrctHandler.ashx',
                data: info,
                success: function (data) {
                    location.reload();
                }
            });
        }

        function deleteData(irow) {
            var info = {
                operation: "delete",
                number: irow.toString()
            };
            $.ajax({
                type: 'POST',
                url: 'LevelStrctHandler.ashx',
                data: info,
                success: function (data) {
                    location.reload();
                }
            });

        }

        function jsCancel() {
            var jstable = document.getElementById("changeTable");
            jstable.style.visibility = "hidden";
        }
    </script>       
</body>
</html>
