using SKYEEBANK.Common;
using SKYEEBANK.Core.Interfaces;
using SKYEEBANK.Core.Loging;
using SKYEEBANK.Data;
using SKYEEBANK.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKYEEBANK.Core.Implementations
{
    public class AccountService : IAccountService
    {

        private readonly ITransactionService _transactionService;

        public AccountService(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public static int IdCount { get; set; }
      
        public void Create(string type)
        {
            var customer = Log.CurrentCustomer;
            IdCount++;
            string accountNumber = "01";
            AccountType accountType = type == "1" ? AccountType.Savings : AccountType.Current;
            var rand = new Random();
            for (int i = 0; i <= 9; i++)
            {
                int num = rand.Next(10);
                accountNumber += num;
            }

            var Account = new Account(IdCount, customer.FullName, accountNumber, accountType, customer.Id);
            DataStore.accounts.Add(Account);

        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Deposit(decimal amount, int accountId)
        {

            if (amount < 0)
            {
                throw new Exception("OOPS!");
            }

            var account = DataStore.accounts.First(x =>
            {
                return x.Id == accountId;
            });
            account.Balance += amount;
            string transDesc = $"Deposit by {Log.CurrentCustomer.FullName}";
        }

      

        public Account Get(int id)
        {
            return DataStore.accounts.Where(x => x.Status == EntityAffirmation.Active)
               .First(x => x.Id == id);
        }

        public object Get(object countId)
        {
            throw new NotImplementedException();
        }

        public List<Account> GetAllCustomerAccount(int id)
        {
            return DataStore.accounts.Where(x =>
            {
                return x.Id == id;
            }).ToList();
        }

        public void Transfer(decimal amount, int accountId, int destinationAccountId)
        {
            if (amount < 0)
            {
                throw new Exception("OOPS");
            }

            var account = DataStore.accounts.First(x =>
            {
                return x.Id == accountId;
            });
            var destinationAccount = DataStore.accounts.First(x =>
            {
                return x.Id == destinationAccountId;
            });
            if (account.AccountType == AccountType.Savings)
            {
                if (account.Balance - amount < 1000)
                {
                    throw new Exception("You have insufficient funds to complete this transaction.");
                }
            }
            else if (account.AccountType == AccountType.Current)
            {
                if (account.Balance < amount)
                {
                    throw new Exception("You have insufficient funds to complete this transaction.");
                }
            }

            account.Balance -= amount;
            string transDesc = $"Transfer by {Log.CurrentCustomer.FullName}";

            destinationAccount.Balance += amount;
            string transDesc2 = $"Transfer from {Log.CurrentCustomer.FullName}";
        }

        public void Withdraw(decimal amount, int accountId)
        {
            if (amount < 0)
            {
                throw new Exception("OOPS!");
            }

            Account account = DataStore.accounts.First(x =>
            {
                return x.Id == accountId;
            });

            if (account.AccountType == AccountType.Savings)
            {
                if (account.Balance - amount < 1000)
                {
                    throw new Exception("You have insufficient funds.");
                }
            }
            else if (account.AccountType == AccountType.Current)
            {
                if (account.Balance < amount)
                {
                    throw new Exception("You have insufficient funds");
                }
            }

            account.Balance -= amount;

        }

        public void Transfer(decimal amount, int id, object destinationAccount)
        {
          
        }

       void IService.Edit(int id)
        {
            throw new NotImplementedException();
        }
    }
}
