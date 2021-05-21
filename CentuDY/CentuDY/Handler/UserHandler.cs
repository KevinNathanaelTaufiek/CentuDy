using CentuDY.Model;
using CentuDY.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentuDY.Handler
{
    public class UserHandler
    {
        
        public static Object getAllUsers()
        {
            return UserRepository.getAllUsers();
        }

        public static bool isUniqueUsername(String username)
        {
            User user = UserRepository.getUserByUsername(username);

            if(user == null)
            {
                return true;
            }
            return false;
        }

        public static void insertNewUser(String username, String password,
            String name, String gender, String phone, String address)
        {
            UserRepository.insertNewUser(username, password, name, gender, phone, address, 2);
        }

        public static User loginUser(String username, String password)
        {
            return UserRepository.getLoginUser(username, password);
        }

        public static User getUserById(int userId)
        {
            return UserRepository.getUserById(userId);
        }

        public static String getRoleNameById(int userId)
        {
            int roleId = UserRepository.getRoleById(userId);
            if(roleId == 1)
            {
                return "Administrator";
            }
            else if(roleId == 2)
            {
                return "Member";
            }
            else
            {
                return "guest";
            }
        }

        public static String deleteUserById(int id, int currId)
        {
            if (UserRepository.validasiDelete(id))
            {
                return "User cannot be referenced in another table in the database ";
            }
            else if (id == currId)
            {
                return "Cannot delete current user";
            }
            UserRepository.deleteUserById(id);
            return "Success";
        }

        public static String changePassword(int id, String newPass)
        {
            UserRepository.changePassword(id, newPass);
            return "success";
        }

        public static String updateProfile(User user, String name, String gender, String phone, String address)
        {
            UserRepository.updateProfile(user, name, gender, phone, address);
            return "success";
        }

        public static Object getUserHistory(int userId)
        {
            return UserRepository.getUserHistory(userId);
        }


    }
}