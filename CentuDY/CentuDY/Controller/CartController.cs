using CentuDY.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentuDY.Controller
{
    public class CartController
    {
        public static String addtoCart(int userId, String medicine, String qty)
        {
            int quantity;
            int medicineId = int.Parse(medicine);
            int stock = MedicineHandler.getMedicineById(medicineId).Stock;
            if (qty.Equals(""))
            {
                return "Quantity cannot be empty";
            }
            else if (!int.TryParse(qty, out quantity))
            {
                return "Quantity must be numeric";
            }
            else if (quantity <= 0)
            {
                return "Quantity must be more than 0";
            }
            else if (stock < quantity)
            {
                return "Quantity must be less than or equals to current stock";
            }
            else if (CartHandler.combinedCartQty(userId, medicineId) + quantity > stock)
            {
                return "The inputted quantity and the reserved quantity in other carts combined altogether must not exceed the selected medicine’s current stock";
            }
            else
            {
                return CartHandler.addtoCart(userId, medicineId, quantity);
            }
        }

        public static Object getUserCart(int userId)
        {
            return CartHandler.getUserCart(userId);
        }

        public static void deleteCartItem(int userId, String medicineId)
        {
            CartHandler.deleteCartItem(userId, int.Parse(medicineId));
        }

        

        public static int checkoutHeader(int userId)
        {
            return CartHandler.checkoutHeader(userId);
        }
        public static void checkoutDetail(int transactionId, int medicineId, int qty)
        {
            CartHandler.checkoutDetail(transactionId, medicineId, qty);
        }

        public static void removeAllCart(int userId)
        {
            CartHandler.removeAllCart(userId);
        }
    }
}