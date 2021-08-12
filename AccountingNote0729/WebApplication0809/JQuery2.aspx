<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JQuery2.aspx.cs" Inherits="WebApplication0809.JQuery2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="Scripts/JQuery.js"></script>
    <script>
        $(document).ready(function () {
            $(".pp").click(function () {
                $(this).hide('slow');
                $("#btn1").on("click", function () {
                    $(".pp").show(1300).css("color", "Red");
                });
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>If you click on me, I will disappear.</p>
            <p class="pp">Click me away!</p>
            <p class="pp" id="p1">Click me too!</p>

            <input type="text" id="txt1" /><br />
            <button id="btn1" type="button">Click</button>
        </div>
    </form>
</body>
</html>
