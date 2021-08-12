<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication0809.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
                <script>
<%--                var item = <% =this.jsint %>;
                    var item1 = <% =this.jsint1 %>;

                    var item2 = <% =this.IsMe ? "true":"false"%>;
                    var item3 = "<% = this.txt2%>";--%>

                    var obj = <%= this.stringobj%>
                </script>
            <script src="js1.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="messageboxbtn" runat="server" Text="Button" onclick="messageboxbtn_Click"
                onClientclick="excu()"/><br />

            <asp:TextBox ID="txtbox1" runat="server" Visible =" false"></asp:TextBox>
            <asp:HiddenField ID="HiddenField1" runat="server" />

            <asp:HiddenField ID="HiddenField2" runat="server" />

            <asp:Label ID="Label1" runat="server" Text="Label">ABCDEFG</asp:Label>
            <button type="button" onclick="excu()">Click</button>

               <%-- function excu2() {
                    var hf2 = document.getElementById("HiddenField2");
                    var val = hf2.value;

                    alert(val);
                }

                function excu() {
                    var lbl = document.getElementById("Label1");
                    lbl.innerHTML = "HIJKLMNOP";

                    //var txt = document.getElementById("txtbox1")
                    //txt.value = "HIJKLMNOP";

                    var hiddenfield1 = document.getElementById("HiddenField1");
                    hiddenfield1.value = "QRSTUV";
                }--%>
        </div>
    </form>
</body>
</html>
