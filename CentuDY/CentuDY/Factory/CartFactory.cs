using CentuDY.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentuDY.Factory
{
    public class CartFactory
    {
        public static Cart createCart(int userId, int medicineId, int qty)
        {
            Cart c = new Cart
            {
                UserId = userId,
                MedicineId = medicineId,
                Quantity = qty
            };
            return c;
        }

    }
}