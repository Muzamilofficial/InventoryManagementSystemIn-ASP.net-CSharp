using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication5
{
    public partial class Stock : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
                Master.labusername.Text = "Welcome " + Session["Username"];
            }
            if (!IsPostBack)
            {
                //AutoSelectComboData();
                CompanyComboBoxFill();
                ViewSpaceData();
                ViewData();
                //ModelComboBoxFill();
            }
        }

        DbMobileInventoryEntities2 db = new DbMobileInventoryEntities2();
        public void CompanyComboBoxFill()
        {
            Drpcompany.DataSource = (from a in db.tblCompanies
                                     select new { a.CompanyID, a.CompanyName }).ToList();
            Drpcompany.DataValueField = "CompanyID";
            Drpcompany.DataTextField = "CompanyName";
            Drpcompany.DataBind();
        }
        public void ViewData()
        {
            string searchWord = Drpcompany.SelectedItem.ToString();
            //var result = db.tblPurchaseDetails.Where(p => p.PurchaseID.ToString() == searchWord);
            Repeater1.DataSource = db.SpsearchProductInStockFirst(searchWord).ToList();
            Repeater1.DataBind();
        }

        protected void submitbtn_Click(object sender, EventArgs e)
        {
            ViewData();
        }

        protected void Drpcompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewData();
        }
        public void ViewSpaceData()
        {
            var select = db.Spsearchstockproduct().ToList();
            Repeater2.DataSource = select.OrderByDescending(item => item.sno);

            Repeater2.DataBind();
        }
        protected void txtsearchname_TextChanged(object sender, EventArgs e)
        {
            if (txtsearchname.Text != "")
            {
                string searchWord = txtsearchname.Text;
                //var result = db.tblPurchaseDetails.Where(p => p.PurchaseID.ToString() == searchWord);
                Repeater2.DataSource = db.SpsearchProductInStock2(searchWord).ToList();
                Repeater2.DataBind();
            }
            else
            {
                ViewSpaceData();
            }
        }
    }
}