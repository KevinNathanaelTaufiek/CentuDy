using CentuDY.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentuDY.Factory
{
    public class TransactionFactory
    {
        public static HeaderTransaction createHeaderTransaction(int userId, DateTime date)
        {
            return new HeaderTransaction
            {
                UserId = userId,
                TransactionDate = date
            };
        }

        public static DetailTransaction createDetailTransaction(int transactionId, int medicineId, int qty)
        {
            return new DetailTransaction
            {
                TransactionId = transactionId,
                MedicineId = medicineId,
                Quantity = qty
            };
        }
    }
}