using SKYEEBANK.Core.Interfaces;
using SKYEEBANK.Core.Loging;
using static System.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKYEEBANK.UI
{
    public class LogabbleDisplay : ILogabbleDisplay
    {
        private readonly ICustomerService _customerService;
        private readonly IAccountDisplay _accountDisplay;

        public LogabbleDisplay(ICustomerService customerService, IAccountDisplay accountDisplay)
        {
            _customerService = customerService;
            _accountDisplay = accountDisplay;
        }

        public void DisplayAccountMenu()
        {
            WriteLine("Welcome, select an option to continue:");
            WriteLine("\t1. Login\n\t2. Register\n\t3. Exit");
            Write("==== ");
            ForegroundColor = ConsoleColor.Blue;

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string reply = ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            if (reply == "1")
            {
                Login();
            }
            else if (reply == "2")
            {
                Register();
            }
            else if (reply == "3")
            {
                Environment.Exit(0);
            }

        }

        public void displaylogabblemenu()
        {
            WriteLine("welcome, select an option to continue:");
            WriteLine("\t1. login\n\t2. register\n\t3. exit");
            Write("==== ");
           try
            {

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string reply = ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                if (reply == "1")
                {
                    Login();
                }
                else if (reply == "2")
                {
                    Register();
                }
                else if (reply == "3")
                {
                    Environment.Exit(0);
                }
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
        }

        public void Login()
        {
            int count = 0;

            while (count < 3)
            {
                WriteLine("Enter your details to login");
                Write("Email: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string email = ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

                Write("Password: ");
                string password = Validate.GetPassword();

#pragma warning disable CS8604 // Possible null reference argument.
                if (Log.Login(email, password)) break;
#pragma warning restore CS8604 // Possible null reference argument.

                WriteLine("Invalid email or password");
                count++;
            }
        }

        public void Register()
        {
            string firstName = "", lastName = "", email = "", password = "",
                passwordConfirm = "", pin = "", passwordHash = "";
            WriteLine("Press q at any time to quit:");

            while (true)
            {
                Write("Firstname: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                firstName = ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

#pragma warning disable CS8602 // Dereference of a possibly null reference.
                if (firstName.ToLower() == "q") return;
#pragma warning restore CS8602 // Dereference of a possibly null reference.

                if (!Validate.CheckName(firstName))
                {
                    WriteLine("Invalid input for Firstname: name must be in Title case.");
                    continue;
                }
                break;
            }

            while (true)
            {
                Write("Lastname: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                lastName = ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

#pragma warning disable CS8602 // Dereference of a possibly null reference.
                if (lastName.ToLower() == "q") return;
#pragma warning restore CS8602 // Dereference of a possibly null reference.

                if (!Validate.CheckName(lastName))
                {
                    WriteLine("Invalid input for Lastname: name must be in Title " +
                        "case and 3 or more characters long.");
                    continue;
                }
                break;
            }

            while (true)
            {
                WriteLine("Email: In this Format(********@****.com)");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                email = ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

#pragma warning disable CS8602 // Dereference of a possibly null reference.
                if (email.ToLower() == "q") return;
#pragma warning restore CS8602 // Dereference of a possibly null reference.

                if (!Validate.CheckEmail(email))
                {
                    WriteLine("Invalid input for Email: must be a valid email address.");
                    continue;
                }
                if (!Validate.CheckEmailUnique(email))
                {
                    WriteLine("A user account with this email already exists.");
                    continue;
                }
                break;
            }

            while (true)
            {
                Write("Password: ");
                password = Validate.GetPassword();

                if (password.ToLower() == "q") return;

                if (!Validate.CheckPassword(password))
                {
                    WriteLine("Invalid input for Password: must be minimum 6 characters that" +
                        " include alphanumeric and at least one special character.");
                    continue;
                }
                passwordHash = HashPassword(password);
                break;
            }

            while (true)
            {
                Write("Confirm Password: ");
                passwordConfirm = Validate.GetPassword();

                if (passwordConfirm.ToLower() == "q") return;

                if (!Validate.CheckPasswordMatch(password, passwordConfirm))
                {
                    WriteLine("Passwords do not match.");
                    continue;
                }
                break;
            }

            while (true)
            {
                Write("Enter a 4-digit PIN to use for your transactions: ");
                pin = Validate.GetPassword();

                if (pin.ToLower() == "q") return;

                if (!Validate.CheckPin(pin))
                {
                    WriteLine("Invalid input for PIN: must be 4 diigits.");
                    continue;
                }
                break;
            }

            _customerService.Create(firstName, lastName, email, passwordHash, pin);
            Log.Login(email, password);
            _accountDisplay.DisplayCreateAccountMenu(Log.CurrentCustomer);
        }

        private string HashPassword(string password)
        {
            return password;
        }
    }
}
