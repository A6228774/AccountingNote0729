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
        public object stringobj { get; set; }
        public class temp
        {
            public string Name { get; set; }
            public int Age { get; set;}

            public int jsint = 250;
            public int jsint1 = 3;

            public bool IsMe { get; set; } = true;
            public string txt2 { get; set; } = "Window";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.HiddenField2.Value = "Hidden";
            temp testtemp = new temp()
            {
                Name = "Pinky",
                Age = 20
            };
            string jsontxt = Newtonsoft.Json.JsonConvert.SerializeObject(testtemp);
            this.stringobj = jsontxt;
        }

        protected void messageboxbtn_Click(object sender, EventArgs e)
        {
            //this.Label1.Text = this.txtbox1.Text;
            this.Label1.Text = this.HiddenField1.Value;
        }

    }
}