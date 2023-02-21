using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace WebApplication5
{
    public partial class Company : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
                Master.labusername.Text = "Welcome " + Session["Username"];
            }
            ViewData();
            //displaymessage.Visible = false;

            btnupdate.Visible = false;
            submitbtn.Visible = true;
        }

        DbMobileInventoryEntities2 db = new DbMobileInventoryEntities2();
        protected void submitbtn_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                try
                {
                    bool has = db.tblCompanies.Any(cus => cus.CompanyName == txtcom.Text);
                    if (!has)
                    {
                        tblCompany obj = new tblCompany();
                        obj.CompanyName = txtcom.Text;

                        db.tblCompanies.Add(obj);
                        db.SaveChanges();
                        //Messagebox("Data Is Inserted Sucessfully");
                        //displaymessage.Visible = true;
                        ClearAll();
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme()", true);
                        ViewData();
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "duplicateme()", true);
                    }
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
                    tblCompany obj1 = db.tblCompanies.FirstOrDefault(r => r.CompanyID == id);

                    txtcom.Text = obj1.CompanyName;

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
                    tblCompany obj = db.tblCompanies.FirstOrDefault(r => r.CompanyID == id);

                    db.tblCompanies.Remove(obj);
                    db.SaveChanges();
                    //displaymessage.Visible = true;
                    //displaymessage.Text = "Record Is Been Deleted Sucessfully";
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "deleteme()", true);
                    ViewData();

                    break;
            }

        }

        public void ClearAll()
        {
            txtcom.Text = "";
            txtvalid.Text = "";
        }

        public void ViewData()
        {
            var select = (from a in db.tblCompanies
                                    select new { a.CompanyID, a.CompanyName }).ToList();
            Repeater1.DataSource = select.OrderByDescending(item => item.CompanyID);
            Repeater1.DataBind();
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                try
                {
                    int id = int.Parse(HiddenField1.Value);
                    var row = db.tblCompanies.Where(a => a.CompanyID == id).FirstOrDefault();
                    if (row != null)
                    {
                        row.CompanyName = txtcom.Text;

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

        private bool IsValid()
        {
            if (txtcom.Text.Trim() == string.Empty)
            {
                txtcom.Focus();
                txtvalid.Text = "Company Name Is Required";
                return false;
            }
            return true;
        }
        protected void txtsearchname_TextChanged(object sender, EventArgs e)
        {
            if (txtsearchname.Text != "")
            {
                string searchWord = txtsearchname.Text;
                var result = db.tblCompanies.Where(p => p.CompanyName == searchWord);
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