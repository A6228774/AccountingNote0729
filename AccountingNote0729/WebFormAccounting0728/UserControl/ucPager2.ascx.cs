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

            this.cPage = this.GetCurrentPage();

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
            else if (cPage == 2)
            {
                this.a1.Visible = false;
            }
            else if (cPage == (totalpage - 1))
            {
                this.a4.Visible = false;
            }

            int prevM1 = this.cPage - 1;
            int prevM2 = this.cPage - 2;

            this.a2.HRef = $"{this.Url}?page={prevM1}";
            this.a2.InnerText = prevM1.ToString();
            this.a1.HRef = $"{this.Url}?page={prevM2}";
            this.a1.InnerText = prevM2.ToString();

            int nextP1 = this.cPage + 1;
            int nextP2 = this.cPage + 2;

            this.a4.HRef = $"{this.Url}?page={nextP1}";
            this.a4.InnerText = nextP1.ToString();
            this.a5.HRef = $"{this.Url}?page={nextP2}";
            this.a5.InnerText = nextP2.ToString();

            this.a3.InnerText = this.cPage.ToString();

            if (prevM2 <= 0)
                this.a1.Visible = false;
            if (prevM1 <= 0)
                this.a2.Visible = false;
            if (nextP1 > totalpage)
                this.a4.Visible = false;
            if (nextP2 > totalpage)
                this.a5.Visible = false;

            this.Literal1.Text = $"共{this.TotalSize}筆, 共{totalpage}頁。" +
                $"目前在第{this.GetCurrentPage()}頁。<br/>";
        }
        private int GetCurrentPage()
        {
            string txtpage = Request.QueryString["Page"];

            if (string.IsNullOrWhiteSpace(txtpage))
                return 1;

            int PageIndex = 0;

            if (!int.TryParse(txtpage, out PageIndex))
                return 1;

            return PageIndex;
        }
    }
}