using CentuDY.Factory;
using CentuDY.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentuDY.Repository
{
    public class MedicineRepository
    {
        private static DatabaseEntities db = new DatabaseEntities();
        

        public static Medicine getMedicinesById(int medicineId)
        {
            return db.Medicines.Find(medicineId);
        }

        public static List<Medicine> getRekomen()
        {
            List<Medicine> all = getAllMedicine();

            return all.OrderBy(x => Guid.NewGuid()).Take(5).ToList();
        }
        public static List<Medicine> getAllMedicine()
        {
            DatabaseEntities a = new DatabaseEntities();
            List<Medicine> medicines = a.Medicines.ToList();
            return medicines;
        }

        public static List<Medicine> getMedicinesByName(String name)
        {
            List<Medicine> meds = (from x in db.Medicines
                                   where x.Name.Contains(name)
                                   select x).ToList();
            return meds;
        }

        public static void insertMedicine(String name, String desc, int stock, int price)
        {
            Medicine med = MedicineFactory.createMedicine(name, desc, stock, price);
            db.Medicines.Add(med);
            db.SaveChanges();
        }

        public static void updateMedicineById(int id, String name, String desc, int stock, int price)
        {
            Medicine med = getMedicinesById(id);

            med.Name = name;
            med.Description = desc;
            med.Stock = stock;
            med.Price = price;
            db.SaveChanges();

        }

        public static void deleteMedicines(int medicineId)
        {
            Medicine med = getMedicinesById(medicineId);
            db.Medicines.Remove(med);
            db.SaveChanges();
        }

        public static bool validasiDelete(int medicineId)
        {
            List<Cart> c = (from x in db.Carts
                      where x.MedicineId == medicineId
                      select x).ToList();

            List<DetailTransaction> dt = (from x in db.DetailTransactions
                            where x.MedicineId == medicineId
                            select x).ToList();

            if(c.Count != 0 || dt.Count != 0)
            {
                return true;
            }
            return false;
        }

    }
}