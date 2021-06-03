using CentuDY.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentuDY.Repository
{
    public class ReportRepository
    {
        private static DatabaseEntities db = new DatabaseEntities();

        public static List<HeaderTransaction> GetTransactions()
        {
            return db.HeaderTransactions.ToList();
        }

        public static List<DetailTransaction> GetDetailById(int transactionId)
        {
            var transaksi = (from x in db.DetailTransactions
                             where x.TransactionId == transactionId
                             select x).ToList();
            return transaksi;
        }

    }
}