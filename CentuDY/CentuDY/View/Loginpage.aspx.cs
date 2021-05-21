using CentuDY.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CentuDY.View
{
    public partial class Loginpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*if (Session["user"] == null)
            {*/
            if (Request.Cookies["user_id"] != null)
            {
                int id = int.Parse(Request.Cookies["user_id"].Value);
                txtUsername.Text = LoginController.getUsernameById(id);
                txtPassword.Text = LoginController.getPasswordById(id);
                txtPassword.Attributes["value"] = txtPassword.Text;
                Response.Cookies["user_id"].Expires = DateTime.Now.AddDays(-1);
            }/*
            }
            else
            {
                Response.Redirect("Homepage.aspx");
            }*/

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            String username = txtUsername.Text;
            String password = txtPassword.Text;
            bool remember;

            if (cbRemember.Checked)
            {
                remember = true;
            }
            else
            {
                remember = false;
            }

            lblErr.Text = LoginController.loginUser(username, password, remember);
            if(lblErr.Text.Equals("login success"))
            {
                Response.Redirect("Homepage.aspx");
            }
        }
    }
}