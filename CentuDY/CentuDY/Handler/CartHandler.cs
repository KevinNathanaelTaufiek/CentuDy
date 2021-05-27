using CentuDY.Model;
using CentuDY.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentuDY.Handler
{
    public class CartHandler
    {
        public static String addtoCart(int userId, int medicineId, int qty)
        {
            Cart c = CartRepository.getCart(userId, medicineId);
            if (c == null)
            {
                CartRepository.addtoCart(userId, medicineId, qty);
            }
            else
            {
                CartRepository.addQuantity(c, qty);
            }
            return "Success";
        }

        //Combined cart yang dimaksud itu yag punya sendiri atau semua orang?
        public static int combinedCartQty(int userId, int medicineId)
        {
            return CartRepository.combinedCartQty(userId, medicineId);
        }

        public static Object getUserCart(int userId)
        {
            return CartRepository.getUserCart(userId);
        }

        public static void deleteCartItem(int userId, int medicineId)
        {
            CartRepository.deleteCartItem(userId,medicineId);
        }


        public static int checkoutHeader(int userId)
        {
            DateTime date = DateTime.Now;
            return CartRepository.checkoutHeader(userId, date);
        }
        public static void checkoutDetail(int transactionId, int medicineId, int qty)
        {
            CartRepository.checkoutDetail(transactionId, medicineId, qty);
        }

        public static void removeAllCart(int userId)
        {
            CartRepository.removeAllCart(userId);
        }
    }
}