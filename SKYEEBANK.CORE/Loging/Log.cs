using SKYEEBANK.Data;
using SKYEEBANK.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKYEEBANK.Core.Loging
{
    public class Log
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public static Customer CurrentCustomer { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public static bool Login(string email, string password)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Customer customer = DataStore.customers.FirstOrDefault(x => x.EmailAddress == email);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            if (customer == null || !verify(password, customer.Password)) return false;
           else
            {
                CurrentCustomer = customer;
                return true;
            }
            
        }

        private static bool verify(string password1, string password2)
        {
            return true;
        }

        public static void Logout()
        {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            CurrentCustomer = null;
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        }
    }


}
