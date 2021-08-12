<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="callback.aspx.cs" Inherits="WebApplication0809.callback" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="Scripts/JQuery.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <button id="btn1" type="button">Click number</button>
            <button id="btn2" type="button">Click number</button>
            <button id="btn3" type="button">Click number</button>
            <button id="btn4" type="button">Click number</button>
            <button id="btn5" type="button">Click number</button>
            <button id="btn6" type="button">Click number</button>
        </div>
        <script>
            var btn = document.getElementById("btn1")
            btn.onclick = function () {
                alert(123);
            };

            function bindClickMethod(strBtnID, funcCallBack) {
                var btn = document.getElementById(strBtnID);
                btn.onclick = funcCallBack;
            }

            bindClickMethod("btn1", function () { alert(1); });
            bindClickMethod("btn2", function () { alert(2); });
            bindClickMethod("btn3", function () { alert(3); });
            bindClickMethod("btn4", function () { alert(4); });
            bindClickMethod("btn5", function () { alert(5); });
            bindClickMethod("btn6", function () { alert(6); });
        </script>
    </form>
    <script src="Scripts/JQuery.js"></script>
</body>
</html>
