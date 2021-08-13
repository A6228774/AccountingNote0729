<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ajax0812.aspx.cs" Inherits="WebApplication0809.ajax0812" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="Scripts/JQuery.js"></script>
    <script>
        $(function () {
            var domweatherdata = $("#HF_WeatherData").val();

            if (domweatherdata) {
                try {
                    //狀態保留
                    var wData = JSON.parse(domweatherdata);
                    $("#ltllocation").text(wData["Name"]);
                    $("#ltltemp").text(wData["T"]);
                    $("#ltlPop24").text(wData["Pop"]);
                }
                catch {
                    $("#ltllocation").text("-");
                    $("#ltltemp").text("-");
                    $("#ltlPop24").text("-");
                }
            }

            $("#btn1").click(function () {
                var acctxt = $("#txt1").val();
                var pwdtxt = $("#pwd1").val();
                var url = "WeatherDataHandler.ashx?account=" + acctxt;

                $.ajax({
                    url: url,
                    Type: "POST",
                    data: {
                        "password" : pwdtxt
                    },
                    success: function (result) {
                        var txt = JSON.stringify(result);
                        $("#HF_WeatherData").val(txt);

                        $("#ltllocation").text(result["Name"]);
                        $("#ltltemp").text(result["T"]);
                        $("#ltlPop24").text(result["Pop"]);
                    }
                });
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        Account: <input type="text" id="txt1" />
        Password:<input type="text" id="pwd1"/><br />
        <button type="button" id="btn1">SHOW</button>
        <asp:HiddenField ID="HF_WeatherData" runat="server" value=""/>
        <table border="1">
            <tr>
                <td>地點</td>
                <td><Literal ID="ltllocation">-</Literal></td>
            </tr>
            <tr>
                <td>溫度</td>
                <td><Literal ID="ltltemp">-</Literal></td>
            </tr>
            <tr>
                <td>降雨量</td>
                <td><Literal ID="ltlPop24">-</Literal></td>
            </tr>
        </table>
        <asp:Literal ID="ltlMsg" runat="server">1</asp:Literal>
        <asp:Button ID="btn2" runat="server" Text="Button" onclick="btn2_Click"/>
    </form>
</body>
</html>
