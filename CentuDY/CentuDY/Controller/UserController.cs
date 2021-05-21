using CentuDY.Handler;
using CentuDY.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentuDY.Controller
{
    public class UserController
    {

        public static Object getAllUsers()
        {
            return UserHandler.getAllUsers();
        }

        public static String getUserRoleName(int userId)
        {
            return UserHandler.getRoleNameById(userId);
        }

        public static Object getUserHistory(int userId)
        {
            return UserHandler.getUserHistory(userId);
        }

        public static String deleteUserById(String id, int currId)
        {
            int userId = int.Parse(id);
            return UserHandler.deleteUserById(userId, currId);
            
        }

        public static String changePassword(User user, String oldPass, String newPass, String confirmPass)
        {
            if (oldPass.Equals(""))
            {
                return "Old Password cannot be empty!";
            }
            else if (!user.Password.Equals(oldPass))
            {
                return "Old Password must match with the password in database!";
            }
            else if(newPass.Equals(""))
            {
                return "New Password cannot be empty!";
            }
            else if (newPass.Length<=5)
            {
                return "New Password must be longer than 5 characters!";
            }
            else if (confirmPass.Equals(""))
            {
                return "Confirm Password cannot be empty!";
            }
            else if (!confirmPass.Equals(newPass))
            {
                return "Confirm Password must match new password !";
            }
            else
            {
                return UserHandler.changePassword(user.UserId, newPass);
            }
        }

        public static String updateProfile(User user, String name, String gender, String phone, String address)
        {
            if (name.Equals(""))
            {
                return "Name must not be empty!";
            }
            else if (gender.Equals(""))
            {
                return "Gender must be chosen!";
            }
            else if (phone.Equals(""))
            {
                return "Phone number must not be empty!";
            }
            else if(!UInt64.TryParse(phone, out _))
            {
                return "Phone Number must be numeric!";
            }
            else if (address.Equals(""))
            {
                return "Address must not be empty!";
            }
            else if (!address.Contains("Street"))
            {
                return "Address Must contain the word \"Street!\"";
            }
            else
            {
                return UserHandler.updateProfile(user, name, gender, phone, address);
            }

        }

    }
}