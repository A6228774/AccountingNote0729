using Accounting.dbSource;
using AccountingNote.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebFormAccounting0728.Models
{
    /// <summary>
    /// AccountingNoteList 的摘要描述
    /// </summary>
    public class AccountingNoteList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string account = context.Request.QueryString["Account"];

            if (string.IsNullOrWhiteSpace(account))
            {
                context.Response.StatusCode = 404;
                context.Response.End();
                return;
            }

            var dr = UserInfoManager.GetUserInfoListbyAccount(account);

            if (dr == null)
            {
                context.Response.StatusCode = 404;
                context.Response.End();
                return;
            }

            string userid = dr["ID"].ToString();
            DataTable dt = AccountingManager.GetAccountingList(userid);
            string jsontxt = Newtonsoft.Json.JsonConvert.SerializeObject(dt);

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

            context.Response.ContentType = "application/json";
            context.Response.Write(jsontxt);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}