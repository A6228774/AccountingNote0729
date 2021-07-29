<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebFormAccounting0728.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:PlaceHolder ID="plcLogin" runat="server">
        Account:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtAccount" runat="server"></asp:TextBox><br />
        Password:&nbsp;
        <asp:TextBox ID="txtPWD" runat="server" TextMode="Password"></asp:TextBox><br />
        <asp:Button ID="Loginbtn" runat="server" Text="Login" OnClick="Loginbtn_Click" /><br />
        <asp:Literal ID="LiteralMsg" runat="server"></asp:Literal>
        </asp:PlaceHolder>
    </form>
</body>
</html>
