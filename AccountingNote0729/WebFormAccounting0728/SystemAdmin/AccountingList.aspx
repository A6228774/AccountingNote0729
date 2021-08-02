<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountingList.aspx.cs" Inherits="WebFormAccounting0728.SysteimAdmin.AccountingList" %>

<%@ Register Src="~/UserControl/ucPager.ascx" TagPrefix="uc1" TagName="ucPager" %>


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
                    <asp:Button ID="Createbtn" runat="server" Text="Add" OnClick="Createbtn_Click" />
                    <asp:GridView ID="GV_AccountingList" runat="server" AutoGenerateColumns="False"
                        OnRowDataBound="GV_AccountingList_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="Caption" HeaderText="Caption" />
                            <asp:BoundField DataField="Amount" HeaderText="Amount" />
                            <asp:TemplateField HeaderText="In/Out">
                                <ItemTemplate>
<%--                                    <%# ((int)Eval("ActType") == 0) ? "expenditure" : "Income" %>--%>
                                    <asp:Literal ID="acttype_lt" runat="server"></asp:Literal>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="CreateDate" HeaderText="CreateDate" DataFormatString="{0:yyyy/MM/dd}"/>
                            <asp:TemplateField HeaderText="Act">
                                <ItemTemplate>
                                    <a href="AccountingDetail.aspx?ID=<%# Eval ("ID")%>">Edit</a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                    <asp:Literal runat="server" ID="ltlMsg"></asp:Literal>
                    <uc1:ucPager runat="server" ID="ucPager" Url="AccountingList.aspx" PageSize="10"/>

                    <asp:PlaceHolder ID="plc_nodata" runat="server" Visible="False">
                        <p style="color:crimson">No Data in your Accounting Note.</p>
                    </asp:PlaceHolder>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
