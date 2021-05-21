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
    public partial class ViewTransactionHistorypage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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

        private void fetch()
        {
            User user = (User)Session["user"];
            var history = UserController.getUserHistory(user.UserId);
            gvHistory.DataSource = history;
            gvHistory.DataBind();

            decimal total = 0;
            foreach (GridViewRow row in gvHistory.Rows)
            {
                decimal subtot = Convert.ToDecimal(row.Cells[3].Text);
                total += subtot;
            }
            lblGTotal.Text = total.ToString();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Homepage.aspx");
        }
    }
}