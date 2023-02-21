using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace WebApplication5
{
    public partial class ProductCategory : System.Web.UI.Page
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
                    bool has = db.tblProductCategories.Any(cus => cus.CategoryDesc == txtcat.Text);
                    if (!has)
                    {
                        tblProductCategory obj = new tblProductCategory();
                        obj.CategoryDesc = txtcat.Text;

                        db.tblProductCategories.Add(obj);
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
                    tblProductCategory obj1 = db.tblProductCategories.FirstOrDefault(r => r.CategoryID == id);

                    txtcat.Text = obj1.CategoryDesc;

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
                    tblProductCategory obj = db.tblProductCategories.FirstOrDefault(r => r.CategoryID == id);

                    db.tblProductCategories.Remove(obj);
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
            txtcat.Text = "";
            txtvalid.Text = "";
        }

        public void ViewData()
        {
            var select = (from a in db.tblProductCategories
                                    select new { a.CategoryID, a.CategoryDesc }).ToList();
            Repeater1.DataSource = select.OrderByDescending(item => item.CategoryID);
            Repeater1.DataBind();
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                try
                {
                    int id = int.Parse(HiddenField1.Value);
                    var row = db.tblProductCategories.Where(a => a.CategoryID == id).FirstOrDefault();
                    if (row != null)
                    {
                        row.CategoryDesc = txtcat.Text;

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
            if (txtcat.Text.Trim() == string.Empty)
            {
                txtcat.Focus();
                txtvalid.Text = "Product Category Is Required";
                return false;
            }
            return true;
        }
        protected void txtsearchname_TextChanged(object sender, EventArgs e)
        {
            if (txtsearchname.Text != "")
            {
                string searchWord = txtsearchname.Text;
                var result = db.tblProductCategories.Where(p => p.CategoryDesc == searchWord);
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