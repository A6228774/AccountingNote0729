using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Accounting.dbSource;
using AccountingNote.Auth;

namespace WebFormAccounting0728.SysteimAdmin
{
    public partial class AccountingList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!AuthManager.Islogined())
            {
                Response.Redirect("/Login.aspx");
                return;
            }

            var currentUser = AuthManager.GetCurrentUser();

            if (currentUser == null)
            {
                Response.Redirect("/Login.aspx");
                return;
            }

            var dt = AccountingManager.GetAccountingList(currentUser.ID);

            if (dt.Rows.Count > 0)
            {
                var dtPaged = this.GetPagedDataTable(dt);

                this.GV_AccountingList.DataSource = dtPaged;
                this.GV_AccountingList.DataBind();

                this.ucPager2.TotalSize = dt.Rows.Count;
                this.ucPager2.Bind();
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
        private int GetcurrentPage()
        {
            string txtpage = Request.QueryString["Page"];

            if (string.IsNullOrWhiteSpace(txtpage))
                return 1;

            int intPage;
            if (!int.TryParse(txtpage, out intPage))
                return 1;

            if (intPage <= 0)
                return 1;

            return intPage;
        }
        private DataTable GetPagedDataTable(DataTable dt)
        {
            DataTable dtPaged = dt.Clone();

            int startindex = (this.GetcurrentPage() - 1) * 10;
            int endindex = (this.GetcurrentPage()) * 10;

            if (endindex > dt.Rows.Count)
                endindex = dt.Rows.Count;

            for (var i= startindex; i < endindex; i++ )
            {
                DataRow dr = dt.Rows[i];
                var drNew = dtPaged.NewRow();

                foreach (DataColumn dc in dt.Columns)
                {
                    drNew[dc.ColumnName] = dr[dc];
                }

                dtPaged.Rows.Add(drNew);
            }
            return dtPaged;
        }
    }
}