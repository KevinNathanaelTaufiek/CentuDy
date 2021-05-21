using CentuDY.Controller;
using CentuDY.Model;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CentuDY.View
{
    public partial class ViewUserspage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["user"] == null)
                {
                    Response.Redirect("Loginpage.aspx");
                }
                else
                {
                    //ini buat cek session dah masuk belum
                    User user = (User)Session["user"];

                    int userId = user.UserId;

                    if (UserController.getUserRoleName(userId).Equals("Member"))
                    {
                        Response.Redirect("Homepage.aspx");
                    }
                }
                fetchData();
            }
        }

        private void fetchData()
        {
            var users = UserController.getAllUsers();
            gvUsers.DataSource = users;
            gvUsers.DataBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            User user = (User)Session["user"];
            int currId = user.UserId;
            var userId = (sender as Button).CommandArgument;
            lblErr.Text = UserController.deleteUserById(userId, currId);

            if (lblErr.Text.Equals("Success"))
            {
                Response.Redirect("ViewUserspage.aspx");
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Homepage.aspx");
        }
    }
}