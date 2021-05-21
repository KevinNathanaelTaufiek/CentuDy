using CentuDY.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentuDY.Factory
{
    public class UserFactory
    {
        public static User CreateUser(String username, String password, String name, String gender, String phone, String address, int role)
        {
            User user = new User
            {
                Username = username,
                Password = password,
                Name = name,
                Gender = gender,
                PhoneNumber = phone,
                Address = address,
                RoleId = role
            };
            return user;
        }

    }
}