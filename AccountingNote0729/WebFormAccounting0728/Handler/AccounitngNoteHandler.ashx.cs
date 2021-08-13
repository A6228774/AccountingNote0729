using Accounting.dbSource;
using AccountingNote.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebFormAccounting0728.Handler
{
    /// <summary>
    /// AccounitngNoteHandler 的摘要描述
    /// </summary>
    public class AccounitngNoteHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string actionName = context.Request.QueryString["ActionName"];

            if (string.IsNullOrWhiteSpace(actionName))
            {
                context.Response.StatusCode = 400;
                context.Response.ContentType = "text/plain";
                context.Response.Write("ActionName is required.");
                context.Response.End();
            }
            if (actionName == "create")
            {
                string caption = context.Request.Form["Caption"];
                string amounttxt = context.Request.Form["Amount"];
                string acttypetxt = context.Request.Form["ActType"];
                string body = context.Request.Form["Body"];

                //admin:6EBB9D69-C52F-46D8-9A35-CAB24F6F1FBC
                string id = "6EBB9D69-C52F-46D8-9A35-CAB24F6F1FBC";

                if (string.IsNullOrWhiteSpace(caption) ||
                    string.IsNullOrWhiteSpace(amounttxt) ||
                    string.IsNullOrWhiteSpace(acttypetxt))
                {
                    this.ProcessError(context, "Caption, Amount, ActType is required.");
                    return;
                }

                int tempAmount, tempActType;
                if (!int.TryParse(amounttxt, out tempAmount) || !int.TryParse(acttypetxt, out tempActType))
                {
                    this.ProcessError(context, "Amount, ActType must be integer.");
                    return;
                }
                try
                {
                    AccountingManager.CreateAccounting(id, caption, tempAmount, tempActType, body);
                    context.Response.ContentType = "text/plain";
                    context.Response.Write("OK.");
                }
                catch (Exception ex)
                {
                    context.Response.StatusCode = 503;
                    context.Response.ContentType = "text/plain";
                    context.Response.Write("Error");

                }
            }
            else if(actionName == "update")
            {
            }
            else if (actionName == "delete")
            {
            }
            else if (actionName == "query")
            {
                string idtxt = context.Request.Form["ID"];
                int id;
                int.TryParse(idtxt, out id);
                string UserID = "6EBB9D69-C52F-46D8-9A35-CAB24F6F1FBC";

                var drAccounting = AccountingManager.GetAccounting(id, UserID);

                if (drAccounting == null)
                {
                    context.Response.StatusCode = 404;
                    context.Response.ContentType = "text/plain";
                    context.Response.Write("No Data : " + idtxt);
                    context.Response.End();
                    return;
                }

                AccountingNoteViewModel model = new AccountingNoteViewModel()
                {
                    ID = drAccounting["ID"].ToString(),
                    Caption = drAccounting["Caption"].ToString(),
                    Body = drAccounting["Body"].ToString(),
                    CreateDate = drAccounting.Field<DateTime>("CreateDate").ToString("yyyy/MM/dd"),
                    ActType = drAccounting.Field<int>("ActType").ToString(),
                    Amount = drAccounting.Field<int>("Amount")
                };
                string jsontxt = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                context.Response.ContentType = "application/json";
                context.Response.Write(jsontxt);
            }
            else if (actionName == "list")
            {
                string userid = "6EBB9D69-C52F-46D8-9A35-CAB24F6F1FBC";
                DataTable dt = AccountingManager.GetAccountingList(userid);

                List<AccountingNoteViewModel> list = new List<AccountingNoteViewModel>();
                foreach (DataRow drAccounting in dt.Rows)
                {
                    AccountingNoteViewModel model = new AccountingNoteViewModel()
                    {
                        ID = drAccounting["ID"].ToString(),
                        Caption = drAccounting["Caption"].ToString(),
                        Amount = drAccounting.Field<int>("Amount"),
                        ActType = (drAccounting.Field<int>("ActType") == 0) ? "Expenditure" : "Income",
                        CreateDate = drAccounting.Field<DateTime>("CreateDate").ToString("yyyy/MM/dd")
                    };
                    list.Add(model);
                }
                string jsontxt = Newtonsoft.Json.JsonConvert.SerializeObject(list);
                context.Response.ContentType = "application/json";
                context.Response.Write(jsontxt);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        private void ProcessError(HttpContext context, string msg)
        {
            context.Response.StatusCode = 400;
            context.Response.ContentType = "text/plain";
            context.Response.Write(msg);
            context.Response.End();
        }

    }
}