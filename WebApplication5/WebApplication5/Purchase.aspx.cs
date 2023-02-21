using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication5
{
    public partial class Purchase : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
                Master.labusername.Text = "Welcome " + Session["Username"];
            }
            if (!IsPostBack)
            {
                ProductComboBoxFill();
                //AutoSelectComboData();
                VendorComboBoxFill();
                ViewData();
                //ModelComboBoxFill();
            }
        }
        DbMobileInventoryEntities2 db = new DbMobileInventoryEntities2();
        public void ProductComboBoxFill()
        {
            drpproduct.DataSource = (from a in db.tblProducts
                                     select new { a.ProductID, a.ProductName }).ToList();
            drpproduct.DataValueField = "ProductID";
            drpproduct.DataTextField = "ProductName";
            drpproduct.DataBind();
        }

        public void VendorComboBoxFill()
        {
            Drpvendor.DataSource = (from a in db.tblVendors
                                    select new { a.VendorID, a.VendorName }).ToList();
            Drpvendor.DataValueField = "VendorID";
            Drpvendor.DataTextField = "VendorName";
            Drpvendor.DataBind();
        }
        public void ViewData()
        {
            //var select = (from a in db.tblPurchaseDetails
            //              select new { a.PurchaseDetailsID, a.PurchaseID, a.ProductID, a.Model, a.Quantity, a.PurchasePrice, a.SellPrice, a.IsNew, a.PTAApprove }).ToList();
            //Repeater1.DataSource = select.OrderByDescending(item => item.PurchaseDetailsID);

            var select = db.spViewRepeaterDataOfPurchaseForm2().ToList();
            Repeater1.DataSource = select.OrderByDescending(item => item.Sno);

            Repeater1.DataBind();
        }

        private bool IsValidCon2()
        {

            if (txtqualtity.Text.Trim() == string.Empty)
            {
                txtqualtity.Focus();
                txtvalid.Text = "Quantity Is Required";
                return false;
            }
            if (txtqualtity.Text.Trim() != string.Empty) {
                txtqualtity.Focus();
                txtqualtity.Text = txtqualtity.Text;
                return false;
            }
            if (txtpurchaseprice.Text.Trim() == string.Empty)
            {
                txtpurchaseprice.Focus();
                txtvalid.Text = "Purchase price Is Required";
                return false;
            }

            if (txtprice.Text.Trim() == string.Empty)
            {
                txtprice.Focus();
                txtvalid.Text = "Sell Price Is Required";
                return false;
            }
            return true;
        }
        private bool IsValidCon()
        {
            if (Txtdate.Text.Trim() == string.Empty)
            {
                Txtdate.Focus();
                txtvalid.Text = "Purchase Date Is Required";
                return false;
            }

            if (txtqualtity.Text.Trim() == string.Empty)
            {
                txtqualtity.Focus();
                txtvalid.Text = "Quantity Is Required";
                return false;
            }

            if (txtpurchaseprice.Text.Trim() == string.Empty)
            {
                txtpurchaseprice.Focus();
                txtvalid.Text = "Purchase price Is Required";
                return false;
            }

            if (txtprice.Text.Trim() == string.Empty)
            {
                txtprice.Focus();
                txtvalid.Text = "Sell Price Is Required";
                return false;
            }
            return true;
        }

        public void ClearAll()
        {
            Txtdate.Text = "";
            txtqualtity.Text = "";
            txtpurchaseprice.Text = "";
            txtprice.Text = "";
            chknew.Checked = false;
            chkpta.Checked = false;
        }

        protected void submitbtn_Click(object sender, EventArgs e)
        {
            if (IsValidCon())
            {
                //bool has = db.tblCompanies.Any(cus => cus.CompanyName == txtcom.Text);
                try
                {
                    int VendorID = int.Parse(Drpvendor.SelectedValue.ToString());
                    DateTime PurchaseDate = DateTime.Parse(Txtdate.Text);

                    if (String.IsNullOrEmpty(HiddenField3.Value.ToString()))
                    {
                        HiddenField3.Value = "0";
                    }
                    int isnew, pta;
                    if (chknew.Checked == true && chkpta.Checked == true)
                    {
                        isnew = 1;
                        pta = 1;

                    }

                    else if (chknew.Checked == true && chkpta.Checked == false)
                    {
                        isnew = 1;
                        pta = 0;
                    }
                    else if (chknew.Checked == false && chkpta.Checked == true)
                    {
                        isnew = 0;
                        pta = 1;
                    }

                    else
                    {
                        isnew = 0;
                        pta = 0;
                    }

                    HiddenField3.Value = db.spAddnewPurchase(VendorID, PurchaseDate, int.Parse(drpproduct.SelectedValue), int.Parse(txtqualtity.Text),
                    int.Parse(txtprice.Text), int.Parse(txtpurchaseprice.Text), isnew, pta, int.Parse(HiddenField3.Value.ToString())).FirstOrDefault().ToString();

                    //db.SpFillPurchaseform1(VendorID, PurchaseDate, ShipmentID, ShipmentTotal, AmountPaid).FirstOrDefault().ToString();

                    db.SaveChanges();
                    //Messagebox("Data Is Inserted Sucessfully");
                    //displaymessage.Visible = true;
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme()", true);
                    ViewData();
                    ClearAll();
                }
                catch
                {
                    txtvalid.Text = "Error while saving record";
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
                    tblPurchaseDetail obj1 = db.tblPurchaseDetails.FirstOrDefault(r => r.PurchaseDetailsID == id);

                    drpproduct.SelectedValue = obj1.ProductID.ToString();
                    txtqualtity.Text = obj1.Quantity.ToString();
                    txtpurchaseprice.Text = obj1.PurchasePrice.ToString();
                    txtprice.Text = obj1.SellPrice.ToString();
                    
                    if (obj1.IsNew == true && obj1.PTAApprove == true)
                    {
                        chknew.Checked = true;
                        chkpta.Checked = true;

                    }

                    else if (obj1.IsNew == true && obj1.PTAApprove == false)
                    {
                        chknew.Checked = true;
                        chkpta.Checked = false;
                    }
                    else if (obj1.IsNew == false && obj1.PTAApprove == true)
                    {
                        chknew.Checked = false;
                        chkpta.Checked = true;
                    }

                    else
                    {
                        chknew.Checked = false;
                        chkpta.Checked = false;
                    }

                    btnupdate.Visible = true;
                    submitbtn.Visible = false;

                    break;
            }
            switch (e.CommandName)
            {
                case ("delete"):

                    tblPurchaseDetail tmm = new tblPurchaseDetail();

                    int id = Convert.ToInt32(e.CommandArgument);
                    HiddenField1.Value = id.ToString();
                    tblPurchaseDetail obj = db.tblPurchaseDetails.FirstOrDefault(r => r.PurchaseDetailsID == id);

                    db.tblPurchaseDetails.Remove(obj);
                    db.SaveChanges();
                    //displaymessage.Visible = true;
                    //displaymessage.Text = "Record Is Been Deleted Sucessfully";
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "deleteme()", true);
                    ViewData();

                    break;
            }
        }
        protected void btnupdate_Click(object sender, EventArgs e)
        {
            if (IsValidCon2())
            {
                try
                {
                    int id = int.Parse(HiddenField1.Value);
                    var row = db.tblPurchaseDetails.Where(a => a.PurchaseDetailsID == id).FirstOrDefault();
                    if (row != null)
                    {
                        row.ProductID = int.Parse(drpproduct.SelectedValue.ToString());
                        row.Quantity = int.Parse(txtqualtity.Text);
                        row.PurchasePrice = int.Parse(txtpurchaseprice.Text);
                        row.SellPrice = int.Parse(txtprice.Text);

                        if (chknew.Checked)
                        {
                            row.IsNew = true;
                        }
                        else
                        {
                            row.IsNew = false;
                        }

                        if (chknew.Checked == true && chkpta.Checked == true)
                        {
                            row.IsNew = true;
                            row.PTAApprove = true;

                        }

                        else if (chknew.Checked == true && chkpta.Checked == false)
                        {
                            row.IsNew = true;
                            row.PTAApprove = false;
                        }
                        else if (chknew.Checked == false && chkpta.Checked == true)
                        {
                            row.IsNew = false;
                            row.PTAApprove = true;
                        }

                        else
                        {
                            row.IsNew = false;
                            row.PTAApprove = false;
                        }

                        db.SaveChanges();
                        //displaymessage.Text = "Record Is Been Updated Sucessfully";
                        //displaymessage.Visible = true;
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "updateme()", true);
                        btnupdate.Visible = false;
                        submitbtn.Visible = true;
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
        protected void txtsearchname_TextChanged(object sender, EventArgs e)
        {
            if (txtsearchname.Text != "")
            {
                string searchWord = txtsearchname.Text;
                //var result = db.tblPurchaseDetails.Where(p => p.PurchaseID.ToString() == searchWord);
                Repeater1.DataSource = db.Spsearchproduct(searchWord).ToList();
                Repeater1.DataBind();
            }
            else
            {
                ViewData();
            }
        }
    }
}