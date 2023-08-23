using SKYEEBANK.Entities;
using SKYEEBANK.Helpers;
using static System.Console;
using SKYEEBANK.Core.Loging;
using SKYEEBANK.Core.Interfaces;
using SKYEEBANK.Core.Implementations;

namespace SKYEEBANK.UI
{

    public class AccountDisplay : IAccountDisplay
    {
        private readonly IAccountService _accountService;
        private readonly ITransactionService _transactionService;

        public AccountDisplay(IAccountService accountService, ITransactionService transactionService)
        {
            _accountService = accountService;
            _transactionService = transactionService;
        }
       
        public void DisplayDashboard()
        {
            Print.PrintLogo();

            WriteLine($"Good {Print.GetGreeting()}, {Log.CurrentCustomer.FirstName}.\n");
            WriteLine("Select an option to continue:");
            WriteLine("\t1. View Accounts\n\t2. Create new Savings or Current account\n\t3. Logout");
            Write("==> ");

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string answer = ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            var customer = Log.CurrentCustomer;


            if (answer == "1")
            {
                DisplayViewAccountMenu(customer);
            }
            else if (answer == "2")
            {
                DisplayCreateAccountMenu(customer);
            }
            else if (answer == "3")
            {
                Log.Logout();
            }
        }

        public void DisplayCreateAccountMenu(Customer customer)
        {
            WriteLine("Please Select  account type:");
            WriteLine("\t1. Savings\n\t2. Current\n");
            Write("==> ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string answer = ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            if (answer == "1" || answer == "2")
            {
                WriteLine("Creating account. Please wait ...");
                Thread.Sleep(1500);

                _accountService.Create(answer);
                var account = _accountService.Get(AccountService.IdCount);

                WriteLine("Account successfully created. Your account details are:");
                WriteLine($"\t- Account Name: {customer.FullName}\n\t- Account Number:" +
                    $" {account.AccountNumber} \n\t- Account Type: {account.AccountType}");
                Write("Press Enter to continue: ");
                ReadLine();

                DisplayDashboard();
            }
        }

        public void DisplayViewAccountMenu(Customer customer)
        {
            var accounts = _accountService.GetAllCustomerAccount(customer.Id);

            if (accounts.Count > 0)
            {
                Print.PrintAccountDetails(accounts);

                WriteLine("Select an account to continue: ");
                var answer = ReadLine();
                int.TryParse(answer, out int num);

                if (num > 0 && num <= accounts.Count)
                {
                    var account = accounts[num - 1];
                    DisplaySingleAccount(account);
                }
            }
            else
            {
                WriteLine("You currently have no accounts.");
                ReadLine();
            }
        }
        public void DisplaySingleAccount(Account account)
        {
            Print.PrintLogo();
            WriteLine($"\t- Account Name: {account.FullName}\t- Account Number: {account.AccountNumber} " +
                $"\t- Account Type: {account.AccountType}");
            WriteLine("Select an action to continue:");
            WriteLine("\t1. Deposit\t2. Withdraw\n\t3. Transfer\t4. Request Statement\n\t5." +
                " Get Balance\t6. Main Menu");
            Write("==> ");
            var answer = ReadLine();

            if (answer == "1")
            {
                DisplayDepositMenu(account);
            }
            else if (answer == "2")
            {
                DisplayWithdrawalMenu(account);
            }
            else if (answer == "3")
            {
                DisplayTransferMenu(account);
            }
            else if (answer == "4")
            {
                DisplayAccountStatement(account);
            }
            else if (answer == "5")
            {
                DisplayAccountBalance(account);
            }
            else if (answer == "6")
            {
                DisplayDashboard();
            }
        }

        public void DisplayDepositMenu(Account account)
        {
            WriteLine("Enter Amount to deposit: ");
            var answer = ReadLine();

            if (decimal.TryParse(answer, out decimal amount))
            {
                try
                {
                    _accountService.Deposit(amount, account.Id);

                    WriteLine("Deposit transaction successful");
                }
                catch (Exception e)
                {
                    WriteLine(e.Message);
                }
            }

            WriteLine("Press Enter to continue: ");
            ReadLine();
            DisplaySingleAccount(account);
        }
        public void DisplayWithdrawalMenu(Account account)
        {
            WriteLine("Amount to withdraw: ");
            var answer = ReadLine();

            if (!decimal.TryParse(answer, out decimal amount))
            {
                WriteLine("Invalid input");
                ReadLine();
                DisplaySingleAccount(account);
            }

            Write($"Enter your 4 digit PIN to withdraw from your account: ");
            var answer2 = Validate.GetPassword();

            if (answer2 == Log.CurrentCustomer.Pin)
            {
                try
                {
                    _accountService.Withdraw(amount, account.Id);
                    WriteLine("Withdrawal transaction successful");
                }
                catch (Exception e)
                {
                    WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("Invalid transaction PIN");
            }

            Write("Press Enter to continue: ");
            ReadLine();
            DisplaySingleAccount(account);
        }
    
        public void DisplayAccountBalance(Account account)
        {
            WriteLine($"Your available balance for account {account.AccountNumber}: {account.Balance}");

            Write("Press Enter to continue: ");
            ReadLine();

            DisplaySingleAccount(account);
        }

        public void DisplayAccountStatement(Account account)
        {
            throw new NotImplementedException();
        }


        public void DisplayTransferMenu(Account account)
        {
            WriteLine("Enter amount: ");
            var answer = ReadLine();

            if (!decimal.TryParse(answer, out decimal amount))
            {
                WriteLine("Invalid input");
                ReadLine();
                DisplaySingleAccount(account);
            }

            WriteLine("Enter destination account: ");
            var answer2 = ReadLine();
#pragma warning disable CS8604 // Possible null reference argument.
            var destinationAccount = Validate.CheckAccountExists(answer2, out string message);
#pragma warning restore CS8604 // Possible null reference argument.

            if (destinationAccount == null)
            {
                WriteLine(message);
                WriteLine("Press Enter to continue: ");
                ReadLine();

                DisplaySingleAccount(account);
            }
            else
            {
                WriteLine($"Enter your 4 digit PIN to transfer {amount} SKyeBank ]: ");
                var answer3 = Validate.GetPassword();

                if (answer3 == Log.CurrentCustomer.Pin)
                {
                    try
                    {
                        _accountService.Transfer(amount, account.Id, destinationAccount);
                        WriteLine("Transfer transaction successful");
                    }
                    catch (Exception e)
                    {
                        WriteLine(e.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid transaction PIN");
                }

                WriteLine("Press Enter to continue: ");
                ReadLine();
                DisplaySingleAccount(account);
            }
        }

        private void Write(object p)
        {

        }

    }
}
      
    

