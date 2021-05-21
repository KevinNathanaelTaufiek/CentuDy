using CentuDY.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CentuDY.View
{
    public partial class Registerpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            String username = txtUsername.Text;
            String password = txtPassword.Text;
            String confirmPass = txtConfirmPassword.Text;
            String name = txtName.Text;
            String gender;
            String phone = txtPhone.Text;
            String address = txtAddress.Text;

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

            lblErr.Text = RegisterController.insertNewUser(username, password, 
                confirmPass, name, gender, phone, address);

            if (lblErr.Text.ToString().Equals("Success"))
            {
                Response.Redirect("Loginpage.aspx");
            }

        }
    }
}