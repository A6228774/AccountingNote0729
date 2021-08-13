using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication0809
{
    public partial class ajax0812 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btn2_Click(object sender, EventArgs e)
        {
            int val = int.Parse(this.ltlMsg.Text);
            this.ltlMsg.Text = (val + 1).ToString();
        }
    }
}