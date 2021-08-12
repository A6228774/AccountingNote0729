<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm0811.aspx.cs" Inherits="WebApplication0809.WebForm0811" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td>地點</td><td><asp:Literal ID="ltllocation" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td>溫度</td><td><asp:Literal ID="ltltemp" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td>降雨量</td><td><asp:Literal ID="ltlPop24" runat="server"></asp:Literal></td>
            </tr>

        </table>
    </form>
</body>
</html>
