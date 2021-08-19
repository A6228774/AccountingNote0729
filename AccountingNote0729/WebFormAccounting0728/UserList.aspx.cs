using Accounting.dbSource;
using AccountingNote.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormAccounting0728
{
    public partial class UserList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!AuthManager.Islogined())
            {
                return;
            }
            var cUser = AuthManager.GetCurrentUser();

            this.GridView1.DataSource = AccountingManager.GetAccountingList(cUser.UserGuid);
            this.GridView1.DataBind();
        }
    }
}