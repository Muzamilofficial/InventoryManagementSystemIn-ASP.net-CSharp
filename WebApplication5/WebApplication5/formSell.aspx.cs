using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication5
{
    public partial class formSell : System.Web.UI.Page
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
                LoadQuantityUpdate();
                LoadSellUpdate();
                //AutoSelectComboData();
                CustomerComboBoxFill();
                ViewData();
                //ModelComboBoxFill();
            }
            txtquantitychk.Enabled = false;

            ShowQuantity();
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
        public void CustomerComboBoxFill()
        {
            DrpCustomer.DataSource = (from a in db.tblCustomers
                                      select new { a.CustomerID, a.FirstName }).ToList();
            DrpCustomer.DataValueField = "CustomerID";
            DrpCustomer.DataTextField = "FirstName";
            DrpCustomer.DataBind();
        }

        public void ShowQuantity()
        {
            int ID = int.Parse(drpproduct.SelectedValue.ToString());

            var avaible = db.tblStocks.Where(p => p.productID == ID).Select(u => u.AvailableQty).FirstOrDefault();
            var s = int.Parse(avaible.ToString());

            if (s >= 100)
            {
                quantitytextbox.Text = avaible.ToString();
                quantitytextbox.ForeColor = System.Drawing.Color.Green;
            }

            else
            {
                quantitytextbox.Text = avaible.ToString();
                quantitytextbox.ForeColor = System.Drawing.Color.Red;
            }
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
            if (Convert.ToInt32(txtqualtity.Text) < 0)
            {
                txtqualtity.Focus();
                txtvalid.Text = "Quantity is less than 0";
                return false;
            }
            if (txtsell.Text.Trim() == string.Empty)
            {
                txtsell.Focus();
                txtvalid.Text = "Sell Price Is Required";
                return false;
            }

            return true;
        }
        //public void AddAmountPaid()
        //{
        //    if (IsValidCon())
        //    {

        //        try
        //        {

        //            TextBox2.Text = (Convert.ToInt32(txtsell.Text) * Convert.ToInt32(txtqualtity.Text)).ToString();

        //            int a = Convert.ToInt32(TextBox1.Text);
        //            int b = Convert.ToInt32(txtamountpaid.Text);
        //            int c = (a - b);

        //            txtremaincharges.Text = (c).ToString();

        //            tblSell obj = new tblSell();
        //            obj.AmountPaid = int.Parse(txtamountpaid.Text);

        //            db.tblSells.Add(obj);
        //            db.SaveChanges();
        //            Messagebox("Data Is Inserted Sucessfully");
        //            displaymessage.Visible = true;
        //            ClearAll();
        //            ViewData();

        //        }

        //        catch
        //        {
        //            txtvalid.Text = "Error while saving record";
        //        }
        //    }
        //}

        public void InsertData()
        {
            if (IsValidCon())
            {
                try
                {
                    if (float.Parse(quantitytextbox.Text) >= float.Parse(txtqualtity.Text))
                    {
                        int CustomerID = int.Parse(DrpCustomer.SelectedValue.ToString());
                        DateTime SellDate = DateTime.Parse(Txtdate.Text);

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

                        HiddenField3.Value = db.spAddnewSellRecord(CustomerID, SellDate, int.Parse(drpproduct.SelectedValue), int.Parse(txtqualtity.Text),
                        int.Parse(txtsell.Text), isnew, pta, int.Parse(HiddenField3.Value.ToString())).FirstOrDefault().ToString();

                        //db.SpFillPurchaseform1(VendorID, PurchaseDate, ShipmentID, ShipmentTotal, AmountPaid).FirstOrDefault().ToString();

                        db.SaveChanges();
                        //Messagebox("Data Is Inserted Sucessfully");
                        //displaymessage.Visible = true;
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme()", true);
                        txtvalid.Text = "";
                        LoadQuantityUpdate();
                        LoadSellUpdate();
                        ViewData();
                        ClearAll();
                    }
                    else
                    {
                        txtvalid.Text = "Quantity Should Not Be Greater Than Stock";
                    }
                }

                catch
                {
                    txtvalid.Text = "Error while saving record";
                }
            }
        }
        public void ViewData()
        {
            //var select = (from a in db.tblPurchaseDetails
            //              select new { a.PurchaseDetailsID, a.PurchaseID, a.ProductID, a.Model, a.Quantity, a.PurchasePrice, a.SellPrice, a.IsNew, a.PTAApprove }).ToList();
            //Repeater1.DataSource = select.OrderByDescending(item => item.PurchaseDetailsID);

            var select = db.spViewRepeaterDataOfformSell().ToList();
            Repeater1.DataSource = select.OrderByDescending(item => item.SellID);

            Repeater1.DataBind();
        }
        public void ClearAll()
        {
            Txtdate.Text = "";
            txtqualtity.Text = "";
            txtsell.Text = "";
            chknew.Checked = false;
            chkpta.Checked = false;
        }

        protected void submitbtn_Click1(object sender, EventArgs e)
        {
            if (IsValidCon())
            {
                InsertData();
            }
        }

        protected void drpproduct_TextChanged(object sender, EventArgs e)
        {
            //string ProductName = drpproduct.SelectedValue.ToString();
            //var select = db.spLoadQuantity(ProductName).ToString();

            //txtqualtity.Text = ProductName.ToString();

            //var SakePrice = db.tblSellDetails.Select(a => a.SellPrice > 0).ToString();
            //txtsell.Text = SakePrice;

        }

        protected void drpproduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string ProductName = drpproduct.SelectedValue.ToString();
            //var select = db.spLoadQuantity(ProductName).ToString();

            //txtqualtity.Text = ProductName.ToString();

            //var SakePrice = db.tblSellDetails.Select(a => a.SellPrice > 0).ToString();
            //txtsell.Text = SakePrice;

            LoadQuantityUpdate();
            LoadSellUpdate();
        }
        public void LoadQuantityUpdate()
        {
            int ID = int.Parse(drpproduct.SelectedValue.ToString());

            var avaible = db.tblStocks.Where(p => p.productID == ID).Select(u => u.AvailableQty).FirstOrDefault();
            var s = int.Parse(avaible.ToString());

            if (s >= 100)
            {
                txtqualtity.Text = avaible.ToString();
                txtqualtity.ForeColor = System.Drawing.Color.Green;
            }

            else
            {
                txtqualtity.Text = avaible.ToString();
                txtqualtity.ForeColor = System.Drawing.Color.Red;
            }
        }
        public void LoadSellUpdate()
        {
            int ID = int.Parse(drpproduct.SelectedValue.ToString());

            var avaible = db.tblPurchaseDetails.Where(p => p.ProductID == ID).Select(u => u.SellPrice).FirstOrDefault();
            txtsell.Text = avaible.ToString();
        }
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case ("EDIT"):

                    //==== Getting id of the selelected record(We have passed on link button's command argument property).
                    int id = Convert.ToInt32(e.CommandArgument);
                    HiddenField1.Value = id.ToString();
                    tblSellDetail obj1 = db.tblSellDetails.FirstOrDefault(r => r.SellDetailID == id);

                    drpproduct.SelectedValue = obj1.ProductID.ToString();
                    txtqualtity.Text = obj1.Quantity.ToString();
                    txtsell.Text = obj1.SellPrice.ToString();

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

                    tblSellDetail tmm = new tblSellDetail();

                    int id = Convert.ToInt32(e.CommandArgument);
                    HiddenField1.Value = id.ToString();
                    tblSellDetail obj = db.tblSellDetails.FirstOrDefault(r => r.SellDetailID == id);

                    db.tblSellDetails.Remove(obj);
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
            if (IsValidCon())
            {
                try
                {
                    int id = int.Parse(HiddenField1.Value);
                    var row = db.tblSellDetails.Where(a => a.SellDetailID == id).FirstOrDefault();
                    if (row != null)
                    {
                        row.ProductID = int.Parse(drpproduct.SelectedValue.ToString());
                        row.Quantity = int.Parse(txtqualtity.Text);

                        row.SellPrice = int.Parse(txtsell.Text);

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
            //}
        }
        public void SearchProductByName()
        {
            if (txtsearchname.Text != "")
            {
                var result = db.spViewReapeaterDataOnTextChangedNew3(txtsearchname.Text);
                Repeater1.DataSource = result.ToList();
                Repeater1.DataBind();
            }
            else
            {
                ViewData();
            }
        }

        protected void txtsearchname_TextChanged(object sender, EventArgs e)
        {
            SearchProductByName();
        }

        protected void quantitytextbox_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtamountpaid_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}