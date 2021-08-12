<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JQuery0810.aspx.cs" Inherits="WebApplication0809.JQuery0810" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="Scripts/JQuery.js"></script>
    <script>
        $(document).ready(function () {
            $(".pp").click(function () {
                $(this).hide();
            });
            $("#txt1").change(function () {
                alert($(this).val());
            });
            $("#btn1").on("click", function () {
                $("#txt1").val('');
            });
            $("#btn1").mouseenter(function () {
                alert("Don't Click");
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
