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
    public partial class InsertMedicinepage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            String name = txtName.Text;
            String desc = txtDesc.Text;
            String stock = txtStock.Text;
            String price = txtPrice.Text;

            lblErr.Text = MedicineController.insertMedicine(name, desc, stock, price);
            if (lblErr.Text.Equals("success"))
            {
                Response.Redirect("ViewMedicinespage.aspx");
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewMedicinespage.aspx");
        }
    }
}