using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Accounting.dbSource;

namespace WebFormAccounting0728
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["UserLoginInfo"] != null)
            {
                this.plcLogin.Visible = false;
                Response.Redirect("./SystemAdmin/UserInfo.aspx");
            }
            else
            {
                this.plcLogin.Visible = true;
            }
        }

        protected void Loginbtn_Click(object sender, EventArgs e)
        {
            //string db_account = "admin";
            //string db_password = "12222";

            string inp_Account = this.txtAccount.Text;
            string inp_PWD = this.txtPWD.Text;

            if (string.IsNullOrWhiteSpace(inp_Account) || string.IsNullOrWhiteSpace(inp_PWD))
            {
                this.LiteralMsg.Text = "Account / Password is needed.";
                return;
            }

            var dr = UserInfoManager.GetUserInfoListbyAccount(this.txtAccount.Text);

            if (dr == null)
            {
                this.LiteralMsg.Text = "Account is not exist.";
                return;
            }

            if (string.Compare(dr["Account"].ToString(), this.txtAccount.Text) == 0 &&
                string.Compare(dr["PWD"].ToString(), this.txtPWD.Text) ==0)
            {
                this.Session["UserLoginInfo"] = dr["Account"].ToString();
                Response.Redirect("./SystemAdmin/UserInfo.aspx");
            }
            else
            {
                this.LiteralMsg.Text = "Login Fail.Please check Account / Password.";
                return;
            }
        }
    }
}