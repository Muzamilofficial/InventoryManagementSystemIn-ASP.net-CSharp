using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace WebApplication5
{
    public partial class Vendor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
                Master.labusername.Text = "Welcome " + Session["Username"];
            }
            ViewData();

            btnupdate.Visible = false;
            submitbtn.Visible = true;
        }

        //public void Messagebox(string xMessage)
        //{
        //    Response.Write("<script>alert('" + xMessage + "')</script>");
        //}

        DbMobileInventoryEntities2 db = new DbMobileInventoryEntities2();
        public void ViewData()
        {
            //var select = from sort in db.tblVendors
            //             select sort;
            //Repeater1.DataSource = select.OrderBy(item => item.VendorID);
            //Sort using Name select.OrderBy(item => item.Name);
            //Similarly using Country select.OrderBy(item => item.Country);

            //Repeater1.DataBind();

            var select = (from a in db.tblVendors
                          select new { a.VendorID, a.VendorName, a.Email, a.ContactNo, a.VendorAddress, a.CNIC }).ToList();
            Repeater1.DataSource = select.OrderByDescending(item => item.VendorID);
            Repeater1.DataBind();
        }

        public void InsertVendorData()
        {
            if (IsValid())
            {
                //bool has = db.tblVendors.Any(cus => cus.VendorName == txtname.Text);
                try
                {
                    tblVendor obj = new tblVendor();
                    obj.VendorName = txtname.Text;
                    obj.Email = txtemail.Text;
                    obj.ContactNo = txtcontactno.Text;
                    obj.VendorAddress = txtaddress.Text;
                    obj.CNIC = txtcnic.Text;

                    db.tblVendors.Add(obj);
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

        public void ClearAll()
        {
            txtname.Text = "";
            txtemail.Text = "";
            txtcontactno.Text = "";
            txtaddress.Text = "";
            txtcnic.Text = "";
            txtvalid.Text = "";
        }

        private bool IsValid()
        {
            if (txtname.Text.Trim() == string.Empty)
            {
                txtvalid.Text = "Vendor Name Is Required";
                txtname.Focus();
                return false;
            }
            if (txtemail.Text.Trim() == string.Empty)
            {
                txtvalid.Text = "Email Is Required";
                txtemail.Focus();
                return false;
            }
            if (txtcontactno.Text.Trim() == string.Empty)
            {
                txtvalid.Text = "Contact no Is Required";
                txtcontactno.Focus();
                return false;
            }
            if (txtaddress.Text.Trim() == string.Empty)
            {
                txtvalid.Text = "Address Is Required";
                txtaddress.Focus();
                return false;
            }
            if (txtcnic.Text.Trim() == string.Empty)
            {
                txtvalid.Text = "CNIC Is Required";
                txtcnic.Focus();
                return false;
            }
            return true;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "easy()", true);
        }

        protected void submitbtn_Click(object sender, EventArgs e)
        {
            InsertVendorData();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {

        }
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case ("EDIT"):

                    //==== Getting id of the selelected record(We have passed on link button's command argument property).
                    int id = Convert.ToInt32(e.CommandArgument);
                    HiddenField1.Value = id.ToString();
                    tblVendor obj1 = db.tblVendors.FirstOrDefault(r => r.VendorID == id);

                    txtname.Text = obj1.VendorName;
                    txtemail.Text = obj1.Email;
                    txtcontactno.Text = obj1.ContactNo;
                    txtaddress.Text = obj1.VendorAddress;
                    txtcnic.Text = obj1.CNIC;

                    btnupdate.Visible = true;
                    submitbtn.Visible = false;
                    break;
            }
            switch (e.CommandName)
            {
                case ("delete"):

                    tblVendor tmm = new tblVendor();

                    int id = Convert.ToInt32(e.CommandArgument);
                    HiddenField1.Value = id.ToString();
                    tblVendor obj = db.tblVendors.FirstOrDefault(r => r.VendorID == id);

                    db.tblVendors.Remove(obj);
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
            if (IsValid())
            {
                try
                {
                    int id = int.Parse(HiddenField1.Value);
                    var row = db.tblVendors.Where(a => a.VendorID == id).FirstOrDefault();
                    if (row != null)
                    {
                        row.VendorName = txtname.Text;
                        row.Email = txtemail.Text;
                        row.ContactNo = txtcontactno.Text;
                        row.VendorAddress = txtaddress.Text;
                        row.CNIC = txtcnic.Text;

                        db.SaveChanges();
                        ViewData();
                        //displaymessage.Text = "Record Is Been Updated Sucessfully";
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "updateme()", true);
                        //displaymessage.Visible = true;
                        ClearAll();

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
                var result = db.tblVendors.Where(p => p.VendorName == searchWord);
                Repeater1.DataSource = result.ToList();
                Repeater1.DataBind();
            }
            else
            {
                ViewData();
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            
        }
    }
}