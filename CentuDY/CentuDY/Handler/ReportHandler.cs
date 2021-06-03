using CentuDY.Model;
using CentuDY.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentuDY.Handler
{
    public class ReportHandler
    {

        public static List<HeaderTransaction> GetTransactions()
        {
            return ReportRepository.GetTransactions();
        }

        public static int GetDetailById(int transactionId)
        {
            var transaksi = ReportRepository.GetDetailById(transactionId);
            int total=0;
            foreach (var t in transaksi)
            {
                total += (t.Quantity * t.Medicine.Price);
            }
            return total;
        }
    }
}