<%@ Page Title="" Language="C#" 
    MasterPageFile="SystemAdmin/Admin.master" AutoEventWireup="true" 
    CodeBehind="UserList.aspx.cs" 
    Inherits="WebFormAccounting0728.UserList" %>

<%@ Register Src="~/UserControl/ucPager.ascx" TagPrefix="uc1" TagName="ucPager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ucPager runat="server" id="ucPager" />
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
</asp:Content>
