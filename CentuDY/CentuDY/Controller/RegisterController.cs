using CentuDY.Handler;
using CentuDY.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentuDY.Controller
{
    public class RegisterController
    {
        public static String insertNewUser(String username, String password, 
            String confirmPass, String name, String gender, String phone, String address)
        {
            String response;
            bool isNumeric = false;

            if (username.Equals(""))
            {
                response = "Username must not be empty!";
            }
            else if (username.Length < 3)
            {
                response = "Username minimal length is 3 characters!";
            }
            else if (password.Equals(""))
            {
                response = "Password must not be empty!";
            }
            else if (password.Length<8)
            {
                response = "Password minimal length is 8 characters!";
            }
            else if (confirmPass.Equals(""))
            {
                response = "Confirm Password must not be empty!";
            }
            else if (!password.Equals(confirmPass))
            {
                response = "Confirm Password must be the same as the inputted password!";
            }
            else if (name.Equals(""))
            {
                response = "Name must not be empty!";
            }
            else if (gender.Equals(""))
            {
                response = "Gender must be chosen!";
            }
            else if (phone.Equals(""))
            {
                response = "Phone Number must not be empty!";
            }
            else if (UInt64.TryParse(phone, out _) == false) //gabisa pake int, 12 digit
            {
                response = "Phone Number must be numeric!";
            }
            else if (address.Equals(""))
            {
                response = "Address must not be empty!";
            }
            else if (!address.Contains("Street"))
            {
                response = "Address Must contain the word \"Street!\"";
            }
            else if (!UserHandler.isUniqueUsername(username))
            {
                response = "Username already in use!";
            }
            else
            {
                response = "Success";
                UserHandler.insertNewUser(username, password, name, gender, phone, address);
            }

            return response;

        }

    }
}