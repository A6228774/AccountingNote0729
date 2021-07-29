<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="WebFormAccounting0728.SysteimAdmin.UserInfo" %>

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
                <td colspan="2"><h2>流水帳管理系統</h2></td>
            </tr>
            <tr>
                <td><a href="UserInfo.aspx">使用者資訊</a>
                    <br />
                    <a href="AccountingList.aspx">流水帳管理</a>
                </td>
                <td>
                    <asp:Table ID="Table1" runat="server" border="1">
                        <asp:TableRow>
                            <asp:TableCell>Name:</asp:TableCell><asp:TableCell>
                                <asp:Literal ID="LitName" runat="server"></asp:Literal>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>Account:</asp:TableCell><asp:TableCell>
                                <asp:Literal ID="LitAccount" runat="server"></asp:Literal>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>Email:</asp:TableCell><asp:TableCell>
                                <asp:Literal ID="LitEmail" runat="server"></asp:Literal>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    <asp:Button ID="Logoutbtn" runat="server" Text="Logout" OnClick="Logoutbtn_Click" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
