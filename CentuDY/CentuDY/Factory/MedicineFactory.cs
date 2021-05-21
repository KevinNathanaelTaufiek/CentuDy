using CentuDY.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentuDY.Factory
{
    public class MedicineFactory
    {

        public static Medicine createMedicine(String name, String desc, int stock, int price)
        {
            Medicine medicine = new Medicine
            {
                Name = name,
                Description = desc,
                Stock = stock,
                Price = price
            };
            return medicine;
        }

    }
}