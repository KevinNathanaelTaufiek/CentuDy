using CentuDY.Factory;
using CentuDY.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentuDY.Repository
{
    public class UserRepository
    {
        private static DatabaseEntities db = new DatabaseEntities();

        public static Object getAllUsers()
        {
            return (from x in db.Users
                    join y in db.Roles on x.RoleId equals y.RoleId
                    select new { x.Name, x.UserId, x.Username, x.Gender, x.PhoneNumber, x.Address, y.RoleName }).ToList();
        }

        public static Object getUserHistory(int userId)
        {
            return (from x in db.Users
                    join y in db.HeaderTransactions on x.UserId equals y.UserId
                    join z in db.DetailTransactions on y.TransactionId equals z.TransactionId
                    join q in db.Medicines on z.MedicineId equals q.MedicineId
                    select new
                    {
                        MedicineName = q.Name,
                        Quantity = z.Quantity,
                        Date = y.TransactionDate,
                        SubTotal = (q.Price * z.Quantity)
                    }).ToList();
        }

        public static List<int> getAllRoles()
        {
            return (from x in db.Users select x.RoleId).ToList();
        }

        public static void insertNewUser(String username, String password, 
            String name, String gender, String phone, String address, int role)
        {
            User user = UserFactory.CreateUser(username, password, name, gender, phone, address, role);
            db.Users.Add(user);
            db.SaveChanges();
        }

        public static User getUserByUsername(String username)
        {
            User user = (from i in db.Users 
                         where i.Username.Equals(username) 
                         select i).FirstOrDefault();
            return user;
        }

        public static User getLoginUser(String username, String password)
        {
            User user = (from i in db.Users
                         where i.Username.Equals(username)
                         && i.Password.Equals(password)
                         select i).FirstOrDefault();
            return user;
        }

        public static User getUserById(int userId)
        {
            return (from i in db.Users
                    where i.UserId == userId
                    select i).FirstOrDefault();
        }

        public static int getRoleById(int userId)
        {
            return (from i in db.Users
                    where i.UserId == userId
                    select i.RoleId)
                    .FirstOrDefault();

        }

        public static void deleteUserById(int id)
        {
            db.Users.Remove(getUserById(id));
            db.SaveChanges();
        }

        public static bool validasiDelete(int id)
        {
            Cart c = (from x in db.Carts
                      where x.UserId == id
                      select x).FirstOrDefault();

            HeaderTransaction ht = (from x in db.HeaderTransactions
                                    where x.UserId == id
                                    select x).FirstOrDefault();

            if(c == null && ht == null)
            {
                return false;
            }
            return true;

        }

        public static void changePassword(int id, String newPass)
        {
            User user = getUserById(id);
            user.Password = newPass;
            db.SaveChanges();
        }

        public static void updateProfile(User user, String name, String gender, String phone, String address)
        {
            User u = getUserById(user.UserId);

            u.Name = name;
            u.Gender = gender;
            u.PhoneNumber = phone;
            u.Address = address;

            db.SaveChanges();

        }

        

    }
}