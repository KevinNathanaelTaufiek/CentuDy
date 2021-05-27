using CentuDY.Model;
using CentuDY.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentuDY.Handler
{
    public class MedicineHandler
    {
        public static List<Medicine> getAllMedicine()
        {
            return MedicineRepository.getAllMedicine();
        }

        public static Medicine getMedicineById(int id)
        {
            return MedicineRepository.getMedicinesById(id);
        }

        public static List<Medicine> getMedicinesByName(String name)
        {
            return MedicineRepository.getMedicinesByName(name);
        }

        public static List<Medicine> getRekomen()
        {
            return MedicineRepository.getRekomen();
        }

        public static void insertMedicine(String name, String desc, int stock, int price)
        {
            MedicineRepository.insertMedicine(name, desc, stock, price);
        }

        public static String updateMedicineById(int id, String name, String desc, int stock, int price)
        {
            if (MedicineRepository.getMedicinesById(id) == null)
            {
                return "Failed";
            }

            MedicineRepository.updateMedicineById(id,name,desc,stock,price);
            return "Success";
        }

        public static String deleteMedicineById(int medicineId)
        {
            if(MedicineRepository.getMedicinesById(medicineId) == null || MedicineRepository.validasiDelete(medicineId))
            {
                return "Medicine cannot be referenced in another table in the database";
            }

            MedicineRepository.deleteMedicines(medicineId);
            return "Success";
        }
    }
}