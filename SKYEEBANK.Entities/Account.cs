using SKYEEBANK.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKYEEBANK.Entities
{
    public class Account
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Account(int id, string accountName, string accountNumber,
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
            AccountType accountType, decimal balance)
        {
            Id = id;
            FullName = accountName;
            AccountNumber = accountNumber;
            AccountType = accountType;
            Balance = balance;
            Created = DateTime.Now;
        }
        public int Id { get; set; }
        public string FullName { get; set; }
        public string AccountNumber { get; set; }
        public AccountType AccountType { get; set; }
        public decimal Balance { get; set; }
        public DateTime Created { get; set; }
        // Readonly values cannot be changed(minumum Balance set to 1000)
        public readonly decimal MinimumBalance = 1000.00M;
#pragma warning disable CS0169 // The field 'Account.accountNAme' is never used
        private string accountNAme;
#pragma warning restore CS0169 // The field 'Account.accountNAme' is never used
        public EntityAffirmation Status;
    }
}
