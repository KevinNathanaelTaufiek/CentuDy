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
    public partial class ViewCartpage : System.Web.UI.Page
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
                    User user = (User)Session["user"];

                    int userId = user.UserId;

                    if (UserController.getUserRoleName(userId).Equals("Administrator"))
                    {
                        Response.Redirect("Homepage.aspx");
                    }
                    fetch();
                }

            }
        }

        private void fetch()
        {
            User user = (User)Session["user"];
            var carts = CartController.getUserCart(user.UserId);
            gvInfo.DataSource = carts;
            gvInfo.DataBind();

            decimal total = 0;
            foreach (GridViewRow row in gvInfo.Rows)
            {
                decimal x = Convert.ToDecimal(row.Cells[4].Text);
                total += x;
            }
            lblGTotal.Text = total.ToString();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var medicineId = (sender as Button).CommandArgument;
            User user = (User)Session["user"];
            CartController.deleteCartItem(user.UserId, medicineId);
            fetch();
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            User user = (User)Session["user"];
            int flag=0;
            String medicineName="";
            foreach (GridViewRow row in gvInfo.Rows)
            {
                int medId = Convert.ToInt32(row.Cells[5].Text);
                int qty = Convert.ToInt32(row.Cells[3].Text);
                medicineName = Convert.ToString(row.Cells[1].Text);
                if (MedicineController.getMedicineById(medId).Stock < qty)
                {
                    flag=1;
                    break;
                }
            }

            if (flag == 0)
            {
                int transactionId = CartController.checkoutHeader(user.UserId);
                foreach (GridViewRow row in gvInfo.Rows)
                {
                    int qty = Convert.ToInt32(row.Cells[3].Text);
                    int medId = Convert.ToInt32(row.Cells[5].Text);
                    CartController.checkoutDetail(transactionId, medId, qty);
                }
                CartController.removeAllCart(user.UserId);
                Response.Redirect("ViewCartpage.aspx");
            }
            else
            {
                lblErr.Text = medicineName + " medicine that you ordered has exceeded the available stock";
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Homepage.aspx");
        }
    }
}