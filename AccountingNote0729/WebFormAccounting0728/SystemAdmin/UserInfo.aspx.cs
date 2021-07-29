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
    public partial class UserInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["UserLoginInfo"] == null)
            {
                Response.Redirect("/Login.aspx");
                return;
            }

            string account = this.Session["UserLoginInfo"] as string;
            DataRow dr = UserInfoManager.GetUserInfoListbyAccount(account);

            if (dr == null)
            {
                this.Session["UserLoginInfo"] = null;
                Response.Redirect("/Login.aspx");
                return;
            }

            this.LitAccount.Text = dr["Account"].ToString();
            this.LitName.Text = dr["Name"].ToString();
            this.LitEmail.Text = dr["Email"].ToString();
        }

        protected void Logoutbtn_Click(object sender, EventArgs e)
        {
            this.Session["UserLoginInfo"] = null;
            Response.Redirect("/Login.aspx");
        }
    }
}