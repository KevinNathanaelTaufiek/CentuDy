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
    public partial class AddToCartpage : System.Web.UI.Page
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

                if (UserController.getUserRoleName(userId).Equals("Administrator"))
                {
                    Response.Redirect("Homepage.aspx");
                }
            }
            String medId = Request.QueryString["id"];
            if (medId != null)
            {
                Medicine med = MedicineController.getMedicineById(int.Parse(medId));
                lblName.Text = med.Name;
                lblDesc.Text = med.Description;
                lblStock.Text = med.Stock.ToString();
                lblPrice.Text = med.Price.ToString();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            User user = (User)Session["user"];
            String medId = Request.QueryString["id"];
            String qty = txtQty.Text;

            lblErr.Text = CartController.addtoCart(user.UserId, medId, qty);
            if (lblErr.Text.Equals("Success"))
            {
                Response.Redirect("ViewCartpage.aspx");
            }
        }
    }
}