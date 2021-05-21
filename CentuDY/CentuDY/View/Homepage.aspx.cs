using CentuDY.Controller;
using CentuDY.Model;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CentuDY.View
{
    public partial class Homepage : System.Web.UI.Page
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
                    lblUsername.Text = user.Name;

                    int userId = user.UserId;

                    if (UserController.getUserRoleName(userId).Equals("Administrator"))
                    {
                        gvRekomen.Visible = false;
                        btnInsertMedicines.Visible = true;
                        btnViewUsers.Visible = true;
                        btnTransReport.Visible = true;
                    }
                    else if (UserController.getUserRoleName(userId).Equals("Member"))
                    {
                        List<Medicine> rekomen = MedicineController.getRekomen();
                        gvRekomen.DataSource = rekomen;
                        gvRekomen.DataBind();

                        btnViewCart.Visible = true;
                        btnTransHistory.Visible = true;
                    }

                }
            }

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Cookies["user_id"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("Loginpage.aspx");
        }

        protected void btnInsertMedicines_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertMedicinepage.aspx");
        }

        protected void btnViewUsers_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewUserspage.aspx");
        }

        protected void btnTransReport_Click(object sender, EventArgs e)
        {

        }

        protected void btnViewCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewCartpage.aspx");
        }

        protected void btnTransHistory_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewTransactionHistorypage.aspx");
        }

        protected void btnViewMedicines_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewMedicinespage.aspx");
        }

        protected void btnProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profilepage.aspx");
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            var medicineId = (sender as Button).CommandArgument;
            Response.Redirect("AddToCartpage.aspx?id=" + medicineId);
        }
    }
}