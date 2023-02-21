using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace WebApplication5
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
                Master.labusername.Text = "Welcome " + Session["Username"];
            }

            LoadDataOfTotalEntries();
        }

        DbMobileInventoryEntities2 db = new DbMobileInventoryEntities2();

        public void LoadDataOfTotalEntries()
        {
            var totalvendorsum = db.tblVendors.Count(a => a.VendorID > 0).ToString();
            lblvendors.Text = totalvendorsum;

            var totalcompaniessum = db.tblCompanies.Count(a => a.CompanyID > 0).ToString();
            lblcompanies.Text = totalcompaniessum;

            var totalproductsum = db.tblProducts.Count(a => a.ProductID > 0).ToString();
            lblproducts.Text = totalproductsum;

            var totalpurchasesum = db.tblpurchases.Count(a => a.PurchaseID > 0).ToString();
            lbltotalpurchase.Text = totalpurchasesum;

            var totalstocksum = db.tblStocks.Count(a => a.StockID > 0).ToString();
            lblstock.Text = totalstocksum;

            var totalcustomersum = db.tblCustomers.Count(a => a.CustomerID > 0).ToString();
            lblcustomer.Text = totalcustomersum;
        }
    }
}