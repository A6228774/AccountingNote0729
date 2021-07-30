using Accounting.dbSource;
using AccountingNote.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormAccounting0728.SysteimAdmin
{
    public partial class AccountingDetail : System.Web.UI.Page
    {
        public object GV_AccountingList { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!AuthManager.Islogined())
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
            if (!this.IsPostBack)
            {
                if (this.Request.QueryString["ID"] == null)
                {
                    this.Deletebtn.Visible = false;
                }
                else
                {
                    this.Deletebtn.Visible = true;
                    string idtxt = this.Request.QueryString["ID"];
                    int id;

                    if (int.TryParse(idtxt, out id))
                    {
                        var drAccounting = AccountingManager.GetAccounting(id, dr["ID"].ToString());

                        if (drAccounting == null)
                        {
                            this.LitMsg.Text = "Data not exist.";
                            this.Savebtn.Visible = false;
                            this.Deletebtn.Visible = false;
                        }
                        else
                        {
                            this.ddlActType.SelectedValue = drAccounting["ActType"].ToString();
                            this.txtAmount.Text = drAccounting["Amount"].ToString();
                            this.txtCaption.Text = drAccounting["Caption"].ToString();
                            this.txtContent.Text = drAccounting["Body"].ToString();
                        }
                    }
                    else
                    {
                        this.LitMsg.Text = "ID is required.";
                        this.Savebtn.Visible = false;
                        this.Deletebtn.Visible = false;
                    }
                }
            }
        }
        protected void Savebtn_Click(object sender, EventArgs e)
        {
            List<string> msgList = new List<string>();
            if (!CheckInput(out msgList))
            {
                this.LitMsg.Text = string.Join("<br/>", msgList);
                return;
            }
            else
            { this.LitMsg.Visible = false; }

            string account = this.Session["UserLoginInfo"] as string;
            var dr = UserInfoManager.GetUserInfoListbyAccount(account);

            string userid = dr["ID"].ToString();
            string txtacttype = this.ddlActType.SelectedValue;
            string txtamount = this.txtAmount.Text;
            string caption = this.txtCaption.Text;
            string body = this.txtContent.Text;

            int amount = Convert.ToInt32(txtamount);
            int acttype = Convert.ToInt32(txtacttype);

            string idtxt = this.Request.QueryString["ID"];

            if (string.IsNullOrWhiteSpace(idtxt))
            {
                AccountingManager.CreateAccounting(userid, caption, amount, acttype, body);
            }
            else
            {
                int id;
                if (int.TryParse(idtxt, out id))
                {
                    AccountingManager.UpdateAccounting(id, userid, caption, amount, acttype, body);
                }
            }
            Response.Redirect("/SystemAdmin/AccountingList.aspx");
        }
        private bool CheckInput(out List<string> errorMsgList)
        {
            List<string> msgList = new List<string>();

            if (this.ddlActType.SelectedValue != "0" &&
                this.ddlActType.SelectedValue != "1")
            {
                msgList.Add("Type must be IN / OUT.");
            }
            if (string.IsNullOrWhiteSpace(this.txtAmount.Text))
            {
                msgList.Add("Amount is required.");
            }
            else
            {
                int temp_int;
                if (!int.TryParse(this.txtAmount.Text, out temp_int))
                {
                    msgList.Add("Amount must be a number.");

                    if (temp_int < 0 || temp_int > 1000000)
                    {
                        msgList.Add("Amount must between 0 and 1,000,000.");
                    }
                }
            }
            errorMsgList = msgList;

            if (msgList.Count == 0)
                return true;
            else
                return false;
        }

        protected void Deletebtn_Click(object sender, EventArgs e)
        {
            string idtxt = this.Request.QueryString["ID"];

            if (string.IsNullOrWhiteSpace(idtxt))
                return;

                int id;
                if (int.TryParse(idtxt, out id))
                {
                    AccountingManager.DeleteAccounting(id);
                }
            Response.Redirect("/SystemAdmin/AccountingList.aspx");

        }
    }
}