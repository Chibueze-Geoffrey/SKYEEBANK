using SKYEEBANK.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SKYEEBANK.UI
{
    internal class Validate
    {
        internal static string GetPassword()
        {
            string pass = string.Empty;
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && pass.Length > 0)
                {
                    Console.WriteLine("\b \b");
                    //pass = pass[0..^1];
                    pass = pass.Substring(0, pass.Length - 1);
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    pass += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);
            Console.WriteLine();

            return pass;
        }

        internal static bool CheckPasswordMatch(string password, string passwordConfirm)
        {
            return password == passwordConfirm;
        }

        internal static bool CheckPin(string pin)
        {
            return Regex.IsMatch(pin, @"^\d{4}$");
        }

        internal static bool CheckName(string FullName)
        {
            return Regex.IsMatch(FullName, @"[A-Z][a-z]{2,}");
        }
        internal static bool lastName(string lastName)
        {
            return Regex.IsMatch(lastName, @"[A-Z][a-z]{2,}");
        }
        internal static bool CheckfirstName(string firstName)
        {
            return Regex.IsMatch(firstName, @"[A-Z][a-z]{2,}");
        }

        internal static bool CheckEmailUnique(string email)
        {
            return DataStore.customers.FirstOrDefault(u =>
            {
                return u.EmailAddress == email;
            }) == null; ;
        }

        internal static bool CheckEmail(string email)
        {
            return Regex.IsMatch(email, @"^[a-z0-9]{5,20}@[a-z]{3,20}\.[a-z.]{2,}$");
        }

        internal static bool CheckPassword(string password)
        {
            return Regex.IsMatch(password, @"^(?=.*[@$!%*#?&])(?=.*[A-Za-z])(?=.*\d)[A-Za-z0-9@$!%*#?&]{6,}$");
        }

        internal static object CheckAccountExists(string answer2, out string message)
        {
            return message = answer2; 
        }
    }
}
