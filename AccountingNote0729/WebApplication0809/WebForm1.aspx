<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication0809.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table>       
            <tr><td>Product</td>
                <td><asp:DropDownList ID="ddlProduct" runat="server">
                    <asp:ListItem Value="001">Apple</asp:ListItem>
                    <asp:ListItem Value="002">Oragne</asp:ListItem>
                    <asp:ListItem Value="003">Pear</asp:ListItem>
                    </asp:DropDownList></td></tr> 
            <tr><td>UnitPrice</td><td>
                <asp:TextBox ID="unitpricetxt" runat="server"></asp:TextBox></td></tr> 
            <tr><td>Quantity</td><td>
                <asp:TextBox ID="quantxt" runat="server" TextMode="Number"></asp:TextBox></td></tr> 
        </table><br />
        <asp:Label ID="resultlb" runat="server" Text="Label"></asp:Label><br />
        -------------------<br />
        <asp:Label ID="resultlb_client" runat="server" Text="Label">0</asp:Label><br />
        <asp:Button ID="Button" runat="server" Text="Send" OnClick="Button_Click" /><br />
        <asp:Label ID="errorlb" runat="server" Text="Label"></asp:Label>

        <script>
            var ddlproduct = document.getElementById("ddlProduct");
            var price = document.getElementById("unitpricetxt");
            var quan = document.getElementById("quantxt");
            var lbtotalprice = document.getElementById("resultlb");

            var pricemap = {
                "001": 10,
                "002": 20,
                "003": 50
            };

            ddlproduct.onchange = function () {
                var productID = ddlproduct.value;
                var unitprice = pricemap[productID];

                price.value = unitprice;
            }

            quan.onblur = function () {
                var quantity = parseInt(quan.value, 10);
                var unitprice = price.value;

                var totalprice = unitprice * quantity;
                resultlb_client.innerText = totalprice;
            }

        </script>
    </form>           
</body>
</html>
