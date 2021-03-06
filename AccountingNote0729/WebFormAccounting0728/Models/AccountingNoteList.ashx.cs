using Accounting.dbSource;
using AccountingNote.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebFormAccounting0728.Extensions;

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

            var userInfo = UserInfoManager.GetUserInfoListbyAccount_ORM(account);

            if (userInfo == null)
            {
                context.Response.StatusCode = 404;
                context.Response.End();
                return;
            }

            string userid = userInfo.ID.ToString();
            Guid userguid = userid.ToGuid();
            List<AccountingNoteORM.DBModels.AccountingNote> sourcelist = AccountingManager.GetAccountingList(userguid);

            List<AccountingNoteViewModel> list = sourcelist.Select(obj => new AccountingNoteViewModel()
            {
                ID = obj.ID,
                Caption = obj.Caption,
                Amount = obj.Amount,
                ActType = (obj.ActType == 0) ? "Expenditure" : "Income",
                CreateDate = obj.CreateDate.ToString("yyyy/MM/dd")
            }).ToList();

            //foreach (DataRow drAccounting in dt.Rows)
            //{
            //    AccountingNoteViewModel model = new AccountingNoteViewModel()
            //    {
            //        ID = drAccounting["ID"].ToString(),
            //        Caption = drAccounting["Caption"].ToString(),
            //        Amount = drAccounting.Field<int>("Amount"),
            //        ActType = (drAccounting.Field<int>("ActType") == 0) ? "Expenditure" : "Income",
            //        CreateDate = drAccounting.Field<DateTime>("CreateDate").ToString("yyyy/MM/dd")
            //    };
            //    list.Add(model);
            //}
            string jsontxt = Newtonsoft.Json.JsonConvert.SerializeObject(list);
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