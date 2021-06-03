using CentuDY.Controller;
using CentuDY.DataSet;
using CentuDY.Model;
using CentuDY.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CentuDY.View
{
    public partial class ViewTransactionReportpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Loginpage.aspx");
            }
            else
            {
                CrystalReportTransaction reports = new CrystalReportTransaction();
                CrystalReportViewer.ReportSource = reports;
                DataSetTransaction d = getDataSet(ReportController.GetTransactions());
                reports.SetDataSource(d);
            }

        }

        private DataSetTransaction getDataSet(List<HeaderTransaction> trans)
        {
            DataSetTransaction d = new DataSetTransaction();

            var header = d.HeaderTransaction;
            var detail = d.DetailTransaction;
            List<Medicine> med = MedicineController.getAllMedicine();

            foreach (HeaderTransaction i in trans)
            {
                var rowHeader = header.NewRow();
                rowHeader["TransactionId"] = i.TransactionId;
                rowHeader["UserId"] = i.UserId;
                rowHeader["TransactionDate"] = i.TransactionDate;
                rowHeader["GrandTotal"] = ReportController.GetTotalById(i.TransactionId);
                header.Rows.Add(rowHeader);

                foreach (DetailTransaction j in i.DetailTransactions)
                {
                    var rowDetail = detail.NewRow();
                    rowDetail["TransactionId"] = j.TransactionId;
                    rowDetail["MedicineId"] = j.MedicineId;
                    rowDetail["Quantity"] = j.Quantity;
                    rowDetail["Price"] = j.Medicine.Price;
                    rowDetail["SubTotal"] = j.Quantity * j.Medicine.Price;

                    foreach (Medicine x in med)
                    {
                        if (j.MedicineId == x.MedicineId)
                        {
                            rowDetail["SubTotal"] = x.Price * j.Quantity;

                            break;
                        }
                    }

                    /*foreach(Medicine x in med)
                    {
                        var rowMedic = medic.NewRow();
                        if(j.MedicineId == x.MedicineId)
                        {
                            rowMedic["Price"] = x.Price;
                            medic.Rows.Add(rowMedic);
                            break;
                        }
                    }*/

                    detail.Rows.Add(rowDetail);
                }
            }
            return d;
        }
    }
}