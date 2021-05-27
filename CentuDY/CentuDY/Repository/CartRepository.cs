using CentuDY.Factory;
using CentuDY.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentuDY.Repository
{
    public class CartRepository
    {
        private static DatabaseEntities db = new DatabaseEntities();

        public static Cart getCart(int userId, int medicineId)
        {
            Cart c = (from x in db.Carts
                      where x.MedicineId == medicineId && x.UserId == userId
                      select x).FirstOrDefault();
            return c;
        }
        public static void addtoCart(int userId, int medicineId, int qty)
        {
            Cart c = CartFactory.createCart(userId, medicineId, qty);
            db.Carts.Add(c);
            db.SaveChanges();
        }
        public static void addQuantity(Cart c, int qty)
        {
            c.Quantity += qty;
            db.SaveChanges();
        }

        public static int combinedCartQty(int userId, int medicineId)
        {
            Cart c = getCart(userId, medicineId);
            if(c == null)
            {
                return 0;
            }
            return c.Quantity;
        }

        public static Object getUserCart(int userId)
        {

            return (from x in db.Carts
                      join y in db.Users on x.UserId equals y.UserId
                      join z in db.Medicines on x.MedicineId equals z.MedicineId
                      where x.UserId == userId
                      select new {
                        MedicineName = z.Name,
                        Price = z.Price,
                        Quantity = x.Quantity,
                        SubTotal = (z.Price * x.Quantity),
                        MedicineId = z.MedicineId
                      }
                    ).ToList();
        }

        public static void deleteCartItem(int userId , int medicineId)
        {
            Cart c = getCart(userId, medicineId);
            db.Carts.Remove(c);
            db.SaveChanges();
        }


        public static int checkoutHeader(int userId, DateTime date)
        {
            HeaderTransaction ht = TransactionFactory.createHeaderTransaction(userId, date);
            db.HeaderTransactions.Add(ht);
            db.SaveChanges();
            return ht.TransactionId;
        }

        public static void checkoutDetail(int transactionId, int medicineId, int qty)
        {
            DetailTransaction dt = TransactionFactory.createDetailTransaction(transactionId, medicineId, qty);
            db.DetailTransactions.Add(dt);

            Medicine m = (from x in db.Medicines where x.MedicineId == medicineId select x).First();
            m.Stock -= qty;
            db.SaveChanges();
        }


        public static void removeAllCart(int userId)
        {
            var c = (from x in db.Carts
                     where x.UserId == userId
                     select x).ToList();

            db.Carts.RemoveRange(c);
            db.SaveChanges();
        }
    }
}