using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormAccounting0728.UserControl
{
    public partial class ucPager2 : System.Web.UI.UserControl
    {
        public int PageSize { get; set; }
        public int TotalSize { get; set; }
        public int cPage { get; set; }
        public string Url { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void Bind()
        {
            if (this.PageSize <= 0)
                throw new DivideByZeroException();

            int totalpage = this.TotalSize / this.PageSize;
            if (this.TotalSize % this.PageSize > 0)
                totalpage += 1;

            this.aFirst.HRef = $"{this.Url}?page=1";
            this.aLast.HRef = $"{this.Url}?page={totalpage}";

            if (cPage == 1) 
            {
                this.a1.Visible = false;
                this.a2.Visible = false;
                this.a3.HRef = "";
            }
            else if (cPage == totalpage)
            {
                this.a4.Visible = false;
                this.a5.Visible = false;
                this.a3.HRef = "";
            }
            else
            {
                int prevM1 = this.cPage = -1;
                int prevM2 = this.cPage = -2;

                this.a2.HRef = $"{this.Url}?page={prevM1}";
                this.a1.HRef = $"{this.Url}?page={prevM2}";

                int prevP1 = this.cPage = +1;
                int prevP2 = this.cPage = +2;

                this.a4.HRef = $"{this.Url}?page={prevP1}";
                this.a5.HRef = $"{this.Url}?page={prevP2}";
            }
        }
    }
}