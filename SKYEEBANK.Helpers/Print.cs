using SKYEEBANK.Common;
using SKYEEBANK.Entities;
using static System.Console;

namespace SKYEEBANK.Helpers
{
    public class Print
    {
        public static void PrintAccountDetails(List<Account> accounts)
        {
            Console.WriteLine($"| {"---",-3} | {"---------------------------",-27} | {"-------------",-14} | {"------------",-12} | {"-------------------",-19} |");
            Console.WriteLine($"| {"S/N",-3} | {"ACCOUNT NAME",-27} | {"ACCOUNT NUMBER",-13} | {"ACCOUNT TYPE",-12} | {"ACCOUNT BALANCE",-19} |");
            Console.WriteLine($"| {"---",-3} | {"---------------------------",-27} | {"--------------",-14} | {"------------",-12} | {"-------------------",-19} |");
            int num = 0;

            foreach (var account in accounts)
            {
                Thread.Sleep(400);
                Console.WriteLine($"| {++num,-3} | {account.FullName,-27} | {account.AccountNumber,-14} " +
                    $"| {account.AccountType,-12} | {account.Balance,19:C} |");
            }
            Console.WriteLine($"| {"---------------------------------------------------------------------------------------",-87} |");
        }
        public static void PrintAccountStatement(Account account, List<Transaction> transactions)
        {
            Console.WriteLine($"ACCOUNT STATEMENT FOR [ {account.FullName}, {account.AccountNumber} ]");

            Console.WriteLine($"| {"----------",-10} | {"----------------------------------",-34} | {"-------------------",-19} | {"----------",-10} | {"-------------------",-19} |");
            Console.WriteLine($"| {"DATE",-10} | {"DESCRIPTION",-34} | {"AMOUNT",-19} | {"TYPE",-10} | {"BALANCE",-19} |");
            Console.WriteLine($"| {"----------",-10} | {"----------------------------------",-34} | {"-------------------",-19} | {"----------",-10} | {"-------------------",-19} |");

            if (transactions.Count > 0)
            {
                foreach (var transaction in transactions)
                {
                    Thread.Sleep(300);
                    Write($"| {transaction.Created.ToString("d"),-10} ");
                    Write($"| {transaction.Description,-34} | ");
                    BackgroundColor = transaction.TransType == TransType.Debit ? ConsoleColor.DarkRed : ConsoleColor.DarkGreen;
                    Write($"{transaction.Amount,19:C}");
                    BackgroundColor = ConsoleColor.Black;
                    Write($" | {transaction.TransType,-10} ");
                    WriteLine($"| {transaction.Balance,19:C} |");
                }
            }
            Console.WriteLine($"| {"--------------------------------------------------------------------------------------------------------",-90} |");
        }
        public static void PrintLogo()
        {
            Clear();
            BackgroundColor = ConsoleColor.White;
            ForegroundColor = ConsoleColor.Green;
            ForegroundColor = ConsoleColor.White;
            BackgroundColor = ConsoleColor.Black;
        }
        public static string GetGreeting()
        {
            var now = DateTime.Now;

            if (now.Hour > 16) return "evening";
            else if (now.Hour >= 12) return "afternoon";
            else return "morning";
        }
    }
}