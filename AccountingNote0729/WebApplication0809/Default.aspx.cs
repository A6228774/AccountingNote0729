using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace WebApplication0809
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.HiddenField2.Value = "HF2";
        }

        protected void messageboxbtn_Click(object sender, EventArgs e)
        {
            //this.Label1.Text = this.txtbox1.Text;
            this.Label1.Text = this.HiddenField1.Value;
        }

    }
}