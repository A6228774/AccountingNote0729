using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Accounting.dbSource;
using AccountingNote.Auth;

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
            string errorMsg;

            if (!AuthManager.tryLogin(inp_Account, inp_PWD, out errorMsg))
            {
                this.LiteralMsg.Text = errorMsg;
                return;
            }
            else
                Response.Redirect("./SystemAdmin/UserInfo.aspx");
        }
    }
}