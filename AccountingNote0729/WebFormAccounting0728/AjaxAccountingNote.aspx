<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjaxAccountingNote.aspx.cs" Inherits="WebFormAccounting0728.AjaxAccountingNote" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="Scripts/JQuery.js"></script>
    <script>
        $(function () {
            $("#Savebtn").click(function () {
                var id = $("#HF_1").val();
                var actType = $("#ddlActType").val();
                var amount = $("#txtAmount").val();
                var caption = $("#txtCaption").val();
                var body = $("#txtContent").val();
                if (id) {
                    $.ajax({
                        url: "http://localhost:60053/Handler/AccountingNoteHandler.ashx?ActionName=update",
                        type: "POST",
                        data: {
                            "ID": id,
                            "Caption": caption,
                            "Amount": amount,
                            "ActType": actType,
                            "Body": body
                        },
                        success: function (result) {
                            alert("更新成功");
                        }
                    });
                }
                else {
                    $.ajax({
                        url: "http://localhost:60053/Handler/AccountingNoteHandler.ashx?ActionName=create",
                        type: "POST",
                        data: {
                            "Caption": caption,
                            "Amount": amount,
                            "ActType": actType,
                            "Body": body
                        },
                        success: function (result) {
                            alert("新增成功");
                        }
                    });
                }
            });
            $("#Readbtn").click(function () {
                $.ajax({
                    url: "http://localhost:60053/Handler/AccountingNoteHandler.ashx?ActionName=list",
                    type: "POST",
                    data: {
                        "ID": 12,
                    },
                    success: function (result) {
                        $("#HF_1").val(result["ID"]);
                        $("#ddlActType").val(result["ActType"]);
                        $("#txtAmount").val(result["Amount"]);
                        $("#txtCaption").val(result["Caption"]);
                        $("#txtContent").val(result["Body"]);
                    }
                });
            });
            $(document).on("click", ".btn_readdata", function () {
                var td = $(this).closest("td");
                var hf = td.find("input.HF_RowID");

                var rowID = hf.val();

                $.ajax({
                    url: "http://localhost:60053/Handler/AccountingNoteHandler.ashx?ActionName=query",
                    type: "POST",
                    data: {
                        "ID": rowID
                    },
                    success: function (result) {
                        $("#HF_RowID").val(result["ID"]);
                        $("#ddlActType").val(result["ActType"]);
                        $("#txtAmount").val(result["Amount"]);
                        $("#txtCaption").val(result["Caption"]);
                        $("#txtContent").val(result["Body"]);
                    }
                }
                })
            $("#Addbtn").click(function () {
                $("#HF_RowID").val('');
                $("#ddlActType").val('');
                $("#txtAmount").val('');
                $("#txtCaption").val('');
                $("#txtContent").val('');

                $("#div_editor").show(300);
            })
            $("#Cancelbtn").click(function () {
                $("#HF_RowID").val('');
                $("#ddlActType").val('');
                $("#txtAmount").val('');
                $("#txtCaption").val('');
                $("#txtContent").val('');

                $("#div_editor").hide(300);
            })
            $.ajax({
            url: "http://localhost:60053/Handler/AccountingNoteHandler.ashx?ActionName=list",
            type: "GET",
            data: {},
            success: function (result) {
                var table = '<table border="1">';
                table += "<tr><th>Caption</th><th>Amount</th><th>ActType</th><th>CreateDate</th><th>Act</th</tr>";

                for (var i = 0; i < result.length; i++) {
                    var obj = result[i];
                    var htmltxt = `<tr>
                                        <td>${obj.Caption}</td>
                                        <td>${obj.Amount}</td>
                                        <td>${obj.ActType}</td>
                                        <td>${obj.CreateDate}</td>
                                        <td>
                                            <input type="hidden" class="HF_RowID" value="${obj.ID}"/>
                                            <button type="button" class="btn_readdata"/>
                                        </td>
                                       </tr >`;
                    table += htmltxt;
                }
                table += "</table>";
                $("#div_accountinglist").append(table);
            }
        })
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="div_editor">
            <input type="hidden" id="HF_1" />
            <table>
                <tr>
                    <td>Type:<select id="ddlActType">
                        <option value="0">Out</option>
                        <option value="1">In</option>
                    </select><br />
                        Amount:
                    <input id="txtAmount" type="number" /><br />
                        Caption:<input id="txtCaption" type="text" /><br />
                        Content:<textarea id="txtContent" type="text" rows="5" column="60"></textarea><br />
                        <button id="Savebtn" type="button">Save</button>
                        <button id="Cancelbtn" type="button">Cancel</button>
                    </td>
                </tr>
            </table>
        </div>
        <button type="button" id="Addbtn">ADD</button>
        <div id="div_accountinglist"></div>
    </form>
</body>
</html>
