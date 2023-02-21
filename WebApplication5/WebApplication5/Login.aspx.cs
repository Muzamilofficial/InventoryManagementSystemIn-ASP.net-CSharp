using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication5
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        DbMobileInventoryEntities2 db = new DbMobileInventoryEntities2();
        protected void Unnamed5_Click(object sender, EventArgs e)
        {
            DbMobileInventoryEntities2 db = new DbMobileInventoryEntities2();
            string query = (from c in db.Users
                            where c.Username == textbox1.Text && c.Password == textbox2.Text
                            select c.Username).FirstOrDefault();
            if (query != null)
            {
                User obj = new User();

                string user = textbox1.Text.Trim();

                Session["Username"] = textbox1.Text;
                    Response.Redirect("Home.aspx");
                
            }
            else
            {
                Response.Write("Invalid User");
                lblinvalid.Text = "Invalid Username or Password";
            }
        }
    }
}

            /*if (textbox1.Text == obj.Username)
            {
                string user = textbox1.Text.Trim();

                Session["Username"] = textbox1.Text;
                Response.Redirect("Home.aspx");
            }*/