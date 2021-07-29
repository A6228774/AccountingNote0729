using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Accounting.dbSource;

namespace WebFormAccounting0728.SysteimAdmin
{
    public partial class AccountingList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["UserLoginInfo"] == null)
            {
                Response.Redirect("/Login.aspx");
                return;
            }

            string account = this.Session["UserLoginInfo"] as string;
            var dr = UserInfoManager.GetUserInfoListbyAccount(account);

            if (dr == null)
            {
                Response.Redirect("/Login.aspx");
                return;
            }

            var dt = AccountingManager.GetAccountingList(dr["ID"].ToString());

            if (dt.Rows.Count > 0)
            {
                this.GV_AccountingList.DataSource = dt;
                this.GV_AccountingList.DataBind();
            }
            else            
            {
                this.GV_AccountingList.Visible = false;
                this.plc_nodata.Visible = true;
            }
        }

        protected void Createbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SystemAdmin/AccountingDetail.aspx");
        }

        protected void GV_AccountingList_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            var row = e.Row;

            if (row.RowType == DataControlRowType.DataRow)
            {
                Literal ltl = row.FindControl("acttype_lt") as Literal;

                var dr = row.DataItem as DataRowView;
                int acttype = dr.Row.Field<int>("ActType");

                if (acttype == 0)
                    ltl.Text = "Expenditure";
                else
                    ltl.Text = "Income";
            }
        }
    }
}