<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountingDetail.aspx.cs" Inherits="WebFormAccounting0728.SysteimAdmin.AccountingDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td colspan="2"><h2>流水帳管理系統 - 後台</h2></td>
            </tr>
            <tr>
                <td><a href="UserInfo.aspx">使用者資訊</a>
                    <br />
                    <a href="AccountingList.aspx">流水帳管理</td>
                <td>
                    Type:   <asp:DropDownList ID="ddlActType" runat="server">
                        <asp:ListItem Value="0">Out</asp:ListItem>
                        <asp:ListItem Value="1">In</asp:ListItem>
                            </asp:DropDownList><br />
                    Amount: <asp:TextBox ID="txtAmount" runat="server" TextMode="Number"></asp:TextBox><br />
                    Caption:<asp:TextBox ID="txtCaption" runat="server"></asp:TextBox><br />
                    Content:<asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine"></asp:TextBox><br />
                    <asp:Button ID="Savebtn" runat="server" Text="Save" OnClick="Savebtn_Click" />
                    &nbsp;&nbsp;
                    <asp:Button ID="Deletebtn" runat="server" Text="Delete" OnClick="Deletebtn_Click" /><br />
                    <asp:Literal ID="LitMsg" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
