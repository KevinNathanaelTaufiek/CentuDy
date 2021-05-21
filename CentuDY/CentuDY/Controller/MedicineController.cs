
using CentuDY.Handler;
using CentuDY.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentuDY.Controller
{
    public class MedicineController
    {
        public static List<Medicine> getAllMedicine()
        {
            return MedicineHandler.getAllMedicine();
        }

        public static Medicine getMedicineById(int id)
        {
            return MedicineHandler.getMedicineById(id);
        }

        public static List<Medicine> getMedicinesByName(String name)
        {
            return MedicineHandler.getMedicinesByName(name);
        }


        public static List<Medicine> getRekomen()
        {
            return MedicineHandler.getRekomen();
        }

        public static String insertMedicine(String name, String desc, String stock, String price)
        {
            int parsedStock, parsedPrice;
            if (name.Equals(""))
            {
                return "Medicine name cannot be empty!";
            }
            else if (desc.Equals(""))
            {
                return "Medicine description cannot be empty!";
            }
            else if (desc.Length < 10)
            {
                return "Desctription must be longer than 10 characters!";
            }
            else if (stock.Equals(""))
            {
                return "Medicine stock cannot be empty!";
            }
            else if(!int.TryParse(stock, out parsedStock))
            {
                return "Stock must be numeric!";
            }
            else if (parsedStock <= 0)
            {
                return "Stock must be more than 0!";
            }
            else if (price.Equals(""))
            {
                return "Medicine price cannot be empty!";
            }
            else if (!int.TryParse(price, out parsedPrice))
            {
                return "Price must be numeric!";
            }
            else if (parsedPrice <= 0)
            {
                return "Price must be more than 0!";
            }
            else
            {
                MedicineHandler.insertMedicine(name, desc, int.Parse(stock), int.Parse(price));
                return "success";
            }
            
        }

        public static String updateMedicineById(String id, String name, String desc, String stock, String price)
        {
            int medId = int.Parse(id);

            int parsedStock, parsedPrice;
            if (name.Equals(""))
            {
                return "Medicine name cannot be empty!";
            }
            else if (desc.Equals(""))
            {
                return "Medicine description cannot be empty!";
            }
            else if (desc.Length < 10)
            {
                return "Desctription must be longer than 10 characters!";
            }
            else if (stock.Equals(""))
            {
                return "Medicine stock cannot be empty!";
            }
            else if (!int.TryParse(stock, out parsedStock))
            {
                return "Stock must be numeric!";
            }
            else if (parsedStock <= 0)
            {
                return "Stock must be more than 0!";
            }
            else if (price.Equals(""))
            {
                return "Medicine price cannot be empty!";
            }
            else if (!int.TryParse(price, out parsedPrice))
            {
                return "Price must be numeric!";
            }
            else if (parsedPrice <= 0)
            {
                return "Price must be more than 0!";
            }
            else
            {
                return MedicineHandler.updateMedicineById(medId, name, desc, parsedStock, parsedPrice);
            }
        }

        public static String deleteMedicineById(String medicineId)
        {
            return MedicineHandler.deleteMedicineById(int.Parse(medicineId));
        }
    }
}