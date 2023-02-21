using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace WebApplication5
{
    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
                Master.labusername.Text = "Welcome " + Session["Username"];
            }
            if(!IsPostBack)
            {
                CatComboBoxFill();
                ComComboBoxFill();
            }
            ViewData();
            btnupdate.Visible = false;
            submitbtn.Visible = true;
        }

        DbMobileInventoryEntities2 db = new DbMobileInventoryEntities2();
        public void CatComboBoxFill()
        {
            drpdowncatID.DataSource=(from a in db.tblProductCategories
                                         select new { a.CategoryID, a.CategoryDesc }).ToList();
            drpdowncatID.DataValueField = "CategoryID";
            drpdowncatID.DataTextField = "CategoryDesc";
            drpdowncatID.DataBind();
        }
        public void ComComboBoxFill()
        {
            drpdowncomID.DataSource = (from a in db.tblCompanies
                                       select new { a.CompanyID, a.CompanyName }).ToList();
            drpdowncomID.DataValueField = "CompanyID";
            drpdowncomID.DataTextField = "CompanyName";
            drpdowncomID.DataBind();
        }

        public void AddProductData()
        {
            if (IsValid())
            {
                try
                {
                    tblProduct obj = new tblProduct();
                    obj.CategoryID = int.Parse(drpdowncatID.SelectedValue.ToString());
                    obj.CompanyID = int.Parse(drpdowncomID.SelectedValue.ToString());
                    //obj.CategoryID = drpdowncatID.SelectedIndex;
                    //obj.CompanyID = drpdowncomID.SelectedIndex;
                    obj.ProductName = txtprodname.Text;
                    obj.Model = txtmodel.Text;
                    obj.IMEI1 = txtimi1.Text;
                    obj.IMEI2 = txtimi2.Text;
                    obj.IMEI3 = txtimi3.Text;
                    obj.IMEI4 = txtimi4.Text;

                    db.tblProducts.Add(obj);
                    db.SaveChanges();
                    //Messagebox("Data Is Inserted Sucessfully");
                    //displaymessage.Visible = true;
                    ClearAll();
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme()", true);
                    ViewData();
                }
                catch
                {
                    txtvalid.Text = "Error while saving record";
                }
            }
        }
        
        protected void btnupdate_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                try
                {
                    int id = int.Parse(HiddenField1.Value);
                    var row = db.tblProducts.Where(a => a.ProductID == id).FirstOrDefault();
                    if (row != null)
                    {
                        row.ProductName = txtprodname.Text;
                        row.Model = txtmodel.Text;
                        row.IMEI1 = txtimi1.Text;
                        row.IMEI2 = txtimi2.Text;
                        row.IMEI3 = txtimi3.Text;
                        row.IMEI4 = txtimi4.Text;

                        db.SaveChanges();
                        //displaymessage.Text = "Record Is Been Updated Sucessfully";
                        //displaymessage.Visible = true;
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "updateme()", true);
                        ClearAll();
                        ViewData();

                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
        }
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case ("EDIT"):

                    //==== Getting id of the selelected record(We have passed on link button's command argument property).
                    int id = Convert.ToInt32(e.CommandArgument);
                    HiddenField1.Value = id.ToString();
                    tblProduct obj1 = db.tblProducts.FirstOrDefault(r => r.ProductID == id);
                    txtprodname.Text = obj1.ProductName;
                    txtmodel.Text = obj1.Model;
                    txtimi1.Text = obj1.IMEI1;
                    txtimi2.Text = obj1.IMEI2;
                    txtimi3.Text = obj1.IMEI3;
                    txtimi4.Text = obj1.IMEI4;
                    drpdowncatID.SelectedValue = obj1.CategoryID.ToString();
                    drpdowncomID.SelectedValue = obj1.CompanyID.ToString();

                    btnupdate.Visible = true;
                    submitbtn.Visible = false;
                    break;
            }
            switch (e.CommandName)
            {
                case ("delete"):

                    tblProductCategory tmm = new tblProductCategory();

                    int id = Convert.ToInt32(e.CommandArgument);
                    HiddenField1.Value = id.ToString();
                    tblProduct obj = db.tblProducts.FirstOrDefault(r => r.ProductID == id);

                    db.tblProducts.Remove(obj);
                    db.SaveChanges();
                    //displaymessage.Visible = true;
                    //displaymessage.Text = "Record Is Been Deleted Sucessfully";
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "deleteme()", true);
                    ViewData();

                    break;
            }

        }

        protected void submitbtn_Click(object sender, EventArgs e)
        {
            AddProductData();
        }

        private bool IsValid()
        {
            if (txtprodname.Text.Trim() == string.Empty)
            {
                txtvalid.Text = "Product Name Is Required";
                txtprodname.Focus();
                return false;
            }
            if (txtmodel.Text.Trim() == string.Empty)
            {
                txtvalid.Text = "Model Is Required";
                txtmodel.Focus();
                return false;
            }
            
            return true;
        }
        public void ClearAll()
        {
            txtprodname.Text = "";
            txtmodel.Text = "";
            txtimi1.Text = "";
            txtimi2.Text = "";
            txtimi3.Text = "";
            txtimi4.Text = "";
            txtvalid.Text = "";
        }
        public void ViewData()
        {
            Repeater1.DataSource = (from a in db.tblProducts
                                    select new { a.ProductID, a.CategoryID, a.CompanyID, a.ProductName, a.Model, a.IMEI1, a.IMEI2, a.IMEI3, a.IMEI4 }).ToList();
            Repeater1.DataBind();
        }
        protected void txtsearchname_TextChanged(object sender, EventArgs e)
        {
            if (txtsearchname.Text != "")
            {
                string searchWord = txtsearchname.Text;
                var result = db.tblProducts.Where(p => p.ProductName == searchWord);
                Repeater1.DataSource = result.ToList();
                Repeater1.DataBind();
            }
            else
            {
                ViewData();
            }
        }
    }
}