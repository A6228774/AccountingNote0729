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
        }
    }
}