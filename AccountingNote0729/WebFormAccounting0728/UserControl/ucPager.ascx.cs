using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormAccounting0728
{
    public partial class ucPager : System.Web.UI.UserControl
    {   
        public int PageSize { get; set; }
        public int TotalSize { get; set; }
        public  int cPage { get; set; }
        public string Url { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            //Bind();
        }
        private int GetcurrentPage()
        {
            string txtpage = Request.QueryString["Page"];

            if (string.IsNullOrWhiteSpace(txtpage))
                return 1;

            int intPage;
            if (!int.TryParse(txtpage, out intPage))
                return 1;

            if (intPage <= 0)
                return 1;

            return intPage;
        }
        private int GettotalPages()
        {
            int pages = this.TotalSize / this.PageSize;
            if (this.TotalSize % 10 > 0)
                pages += 1;

            return pages;
        }
        public void Bind()
        { 
             int totalPages = this.GettotalPages();

            this.ltlMsg.Text = $"共{this.TotalSize}筆, 共{totalPages}頁。目前在第{this.GetcurrentPage()}頁。<br/>";

            for (var i = 1; i <= totalPages; i++)
            {
                this.ltlMsg.Text += $"<a href='{this.Url}'> {i}<a/>&nbsp;";
            }
        }
    }
}