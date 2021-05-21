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
    public partial class UpdateMedicinepage : System.Web.UI.Page
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
                String medId = Request.QueryString["id"];
                if(medId != null)
                {
                    Medicine med = MedicineController.getMedicineById(int.Parse(medId));
                    txtName.Text = med.Name;
                    txtDesc.Text = med.Description;
                    txtStock.Text = med.Stock.ToString();
                    txtPrice.Text = med.Price.ToString();
                }

            }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            String medId = Request.QueryString["id"];
            String name = txtName.Text;
            String desc = txtDesc.Text;
            String stock = txtStock.Text;
            String price = txtPrice.Text;
            lblErr.Text = MedicineController.updateMedicineById(medId, name, desc, stock, price);
            if (lblErr.Text.Equals("Success"))
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