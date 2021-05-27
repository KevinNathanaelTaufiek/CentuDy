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
    public partial class ViewMedicinespage : System.Web.UI.Page
    {
        public String roleUser;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                fetchData();
                if (Session["user"] == null)
                {
                    Response.Redirect("Loginpage.aspx");
                }
                else
                {
                    //ini buat cek session dah masuk belum
                    User user = (User)Session["user"];

                    int userId = user.UserId;
                    
                    roleUser = UserController.getUserRoleName(userId);

                    if (roleUser.Equals("Administrator"))
                    {
                        gvMedicine.Columns[6].Visible = false;
                    }
                    if (roleUser.Equals("Member"))
                    {
                        gvMedicine.Columns[0].Visible = false;
                        gvMedicine.Columns[1].Visible = false;
                    }

                }

            }
        }

        private void fetchData()
        {
            List<Medicine> medicines = MedicineController.getAllMedicine();
            gvMedicine.DataSource = medicines;
            gvMedicine.DataBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            User user = (User)Session["user"];

            int userId = user.UserId;
            roleUser = UserController.getUserRoleName(userId);

            var medicineId = (sender as Button).CommandArgument;
            lblErr.Text = MedicineController.deleteMedicineById(medicineId);

            if (lblErr.Text.Equals("Success"))
            {
               Response.Redirect("ViewMedicinespage.aspx");
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var medicineId = (sender as Button).CommandArgument;
            Response.Redirect("UpdateMedicinepage.aspx?id=" + medicineId);
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertMedicinepage.aspx");
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            var medicineId = (sender as Button).CommandArgument;
            Response.Redirect("AddToCartpage.aspx?id="+medicineId);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Homepage.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            User user = (User)Session["user"];

            int userId = user.UserId;
            roleUser = UserController.getUserRoleName(userId);
            String search = txtSearch.Text;

            List<Medicine> medicines = MedicineController.getMedicinesByName(search);
            gvMedicine.DataSource = medicines;
            gvMedicine.DataBind();

        }
    }
}