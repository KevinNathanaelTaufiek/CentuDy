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
    public partial class ChangePasswordpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Loginpage.aspx");
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            User user = (User)Session["user"];
            String oldPass = txtOld.Text;
            String newPass = txtNew.Text;
            String confirmPass = txtConfirm.Text;

            lblErr.Text = UserController.changePassword(user, oldPass, newPass, confirmPass);
            if (lblErr.Text.Equals("success"))
            {
                Response.Redirect("Profilepage.aspx");
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profilepage.aspx");
        }
    }
}