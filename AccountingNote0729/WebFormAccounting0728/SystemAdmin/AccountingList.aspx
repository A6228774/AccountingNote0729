<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountingList.aspx.cs" Inherits="WebFormAccounting0728.SysteimAdmin.AccountingList" %>

<%@ Register Src="~/UserControl/ucPager2.ascx" TagPrefix="uc1" TagName="ucPager2" %>



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
                        OnRowDataBound="GV_AccountingList_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>

                    <asp:Literal runat="server" ID="ltlMsg"></asp:Literal>
                    <uc1:ucPager2 runat="server" id="ucPager2" Url="/SystemAdmin/AccountingList.aspx" PageSize="10"/>

                    <asp:PlaceHolder ID="plc_nodata" runat="server" Visible="False">
                        <p style="color:crimson">No Data in your Accounting Note.</p>
                    </asp:PlaceHolder>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
