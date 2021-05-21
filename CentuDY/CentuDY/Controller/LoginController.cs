using CentuDY.Handler;
using CentuDY.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentuDY.Controller
{
    public class LoginController
    {
        public static String loginUser(String username, String password, bool remember)
        {
            User user = UserHandler.loginUser(username,password);
            String loginStat;

            if (username.Equals(""))
            {
                loginStat = "Username must be filled";
            }
            else if (password.Equals(""))
            {
                loginStat = "Password must be filled";
            }
            else if (user == null)
            {
                loginStat = "Incorrect username or password";
            }
            else
            {
                loginStat = "login success";
                HttpContext.Current.Session.Add("user", user);

                if (remember)
                {
                    HttpCookie cookie = new HttpCookie("user_id");
                    cookie.Value = user.UserId.ToString();
                    cookie.Expires = DateTime.Now.AddMinutes(45);
                    HttpContext.Current.Response.Cookies.Add(cookie);
                }
                
            }
            return loginStat;
        }

        public static string getUsernameById(int userId)
        {
            return UserHandler.getUserById(userId).Username;
        }

        public static string getPasswordById(int userId)
        {
            return UserHandler.getUserById(userId).Password;
        }
    }
}