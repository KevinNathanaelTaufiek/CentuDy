using CentuDY.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CentuDY.View
{
    public partial class Profilepage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Loginpage.aspx");
            }
            else
            {
                User user = (User)Session["user"];
                lblUsername.Text = user.Username;
                lblName.Text = user.Name;
                lblGender.Text = user.Gender;
                lblPhone.Text = user.PhoneNumber;
                lblAddress.Text = user.Address;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Homepage.aspx");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateProfilepage.aspx");
        }

        protected void btnChangePass_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangePasswordpage.aspx");
        }
    }
}