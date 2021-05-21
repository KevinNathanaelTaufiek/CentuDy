using CentuDY.Controller;
using CentuDY.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CentuDY.View
{
    public partial class UpdateProfilepage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["user"] == null)
                {
                    Response.Redirect("Loginpage.aspx");
                }
                User user = (User)Session["user"];
                txtName.Text = user.Name;
                txtPhone.Text = user.PhoneNumber;
                txtAddress.Text = user.Address;
                if (user.Gender.Equals("Male"))
                {
                    rbGenderMale.Checked = true;
                }
                else if (user.Gender.Equals("Female"))
                {
                    rbGenderFemale.Checked = true;
                }
            }
            

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Homepage.aspx");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            User user = (User)Session["user"];
            String name = txtName.Text;
            String phone = txtPhone.Text;
            String address = txtAddress.Text;
            String gender;

            if (rbGenderFemale.Checked)
            {
                gender = "Female";
            }
            else if (rbGenderMale.Checked)
            {
                gender = "Male";
            }
            else
            {
                gender = "";
            }

            lblErr.Text = UserController.updateProfile(user,name,gender,phone,address);

            if (lblErr.Text.Equals("success"))
            {
                Response.Redirect("Profilepage.aspx");
            }
        }
    }
}