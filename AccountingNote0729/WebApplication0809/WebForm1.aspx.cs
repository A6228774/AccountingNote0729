using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication0809
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_Click(object sender, EventArgs e)
        {
            string product = this.ddlProduct.SelectedValue;
            string quantxt1 = this.quantxt.Text;

            int tempint;
            if (! int.TryParse(quantxt1, out tempint))
            {
                this.errorlb.Text = "Quantity Must be an Integer greater than 0.";
                return;
            }
            if (tempint <= 0)
            {
                this.errorlb.Text = "Quantity Must be an Integer greater than 0.";
                return;
            }
            switch (product)
            {
                case "001":
                    this.resultlb.Text = $"Apple, total {tempint * 10}";
                    break;
                case "002":
                    this.resultlb.Text = $"Orange, total {tempint * 20}";
                    break;
                case "003":
                    this.resultlb.Text = $"Pear, total {tempint * 50}";
                    break;
                default:
                    break;

            }
        }
    }
}