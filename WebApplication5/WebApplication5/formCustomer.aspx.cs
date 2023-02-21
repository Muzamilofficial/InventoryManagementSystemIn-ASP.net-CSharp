using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication5
{
    public partial class formCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
                Master.labusername.Text = "Welcome " + Session["Username"];
            }
            ViewData();
        }

        DbMobileInventoryEntities2 db = new DbMobileInventoryEntities2();

        public void ViewData()
        {
            var select = (from a in db.tblCustomers
                          select new { a.CustomerID, a.FirstName, a.LastName, a.FatherName, a.Email, a.ContactNo, a.CNIC, a.U_FilePath }).ToList();
            Repeater1.DataSource = select.OrderByDescending(item => item.CustomerID);
            Repeater1.DataBind();
        }

        public void InsertData()
        {
            try
            {
                if (FileUpload1.HasFile)
                {
                    string videofile = Path.GetFileName(FileUpload1.PostedFile.FileName);

                    string path = "~/UploadFiles/" + videofile;
                    if (FileUpload1.PostedFile != null)
                    {
                        videofile = Path.GetFileName(FileUpload1.PostedFile.FileName);

                        if (videofile != "")
                        {
                            tblCustomer obj = new tblCustomer();
                            obj.FirstName = txtfirstname.Text;
                            obj.LastName = txtlastname.Text;
                            obj.FatherName = txtfathername.Text;
                            obj.Email = txtemail.Text;
                            obj.ContactNo = txtcontactno.Text;
                            obj.CNIC = txtcnic.Text;
                            obj.U_FileName = videofile;
                            obj.U_FilePath = path;

                            db.tblCustomers.Add(obj);
                            db.SaveChanges();

                            FileUpload1.SaveAs(Server.MapPath("~/UploadFiles/") + videofile);

                            //Messagebox("Data Is Inserted Sucessfully");
                            //displaymessage.Visible = true;
                            ClearAll();
                            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme()", true);
                            ViewData();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //txtvalid.Text = "Error while saving record";
                txtvalid.Text = ex.ToString();
            }
        }
        public void ClearAll()
        {
            txtfirstname.Text = "";
            txtlastname.Text = "";
            txtfathername.Text = "";
            txtemail.Text = "";
            txtcontactno.Text = "";
            txtcnic.Text = "";
            txtvalid.Text = "";
        }
        protected void submitbtn_Click(object sender, EventArgs e)
        {
            InsertData();
        }
        private bool IsValidFields()
        {
            if (txtfirstname.Text.Trim() == string.Empty)
            {
                txtvalid.Text = "First Name Is Required";
                txtfirstname.Focus();
                return false;
            }
            if (txtlastname.Text.Trim() == string.Empty)
            {
                txtvalid.Text = "Last Name Is Required";
                txtlastname.Focus();
                return false;
            }
            if (txtfathername.Text.Trim() == string.Empty)
            {
                txtvalid.Text = "Father Name Is Required";
                txtfathername.Focus();
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
            if (txtcnic.Text.Trim() == string.Empty)
            {
                txtvalid.Text = "CNIC Is Required";
                txtcnic.Focus();
                return false;
            }
            //if (txtimage.Text.Trim() == string.Empty)
            //{
            //    txtvalid.Text = "Customer Image Is Required";
            //    txtimage.Focus();
            //    return false;
            //}
            return true;
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case ("EDIT"):

                    //==== Getting id of the selelected record(We have passed on link button's command argument property).
                    int id = Convert.ToInt32(e.CommandArgument);
                    HiddenField1.Value = id.ToString();
                    tblCustomer obj1 = db.tblCustomers.FirstOrDefault(r => r.CustomerID == id);

                    txtfirstname.Text = obj1.FirstName;
                    txtlastname.Text = obj1.LastName;
                    txtfathername.Text = obj1.FatherName;
                    txtemail.Text = obj1.Email;
                    txtcontactno.Text = obj1.ContactNo;
                    txtcnic.Text = obj1.CNIC;

                    btnupdate.Visible = true;
                    submitbtn.Visible = false;
                    break;
            }
            switch (e.CommandName)
            {
                case ("delete"):

                    tblCustomer tmm = new tblCustomer();

                    int id = Convert.ToInt32(e.CommandArgument);
                    HiddenField1.Value = id.ToString();
                    tblCustomer obj = db.tblCustomers.FirstOrDefault(r => r.CustomerID == id);

                    db.tblCustomers.Remove(obj);
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
            try
            {
                int id = int.Parse(HiddenField1.Value);
                var row = db.tblCustomers.Where(a => a.CustomerID == id).FirstOrDefault();
                if (row != null)
                {
                    row.FirstName = txtfirstname.Text;
                    row.LastName = txtlastname.Text;
                    row.FatherName = txtfathername.Text;
                    row.Email = txtemail.Text;
                    row.ContactNo = txtcontactno.Text;
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

        protected void txtsearchcnic_TextChanged(object sender, EventArgs e)
        {
            if (txtsearchcnic.Text != "")
            {
                string searchWord = txtsearchcnic.Text;
                var result = db.tblCustomers.Where(p => p.CNIC == searchWord);
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