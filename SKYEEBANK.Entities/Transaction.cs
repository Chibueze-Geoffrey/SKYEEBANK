using SKYEEBANK.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKYEEBANK.Entities
{
    public class Transaction
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Transaction() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Transaction(int id, TransType transType, TransLayer transLayer, string description,
          int amount, decimal balance)
        {
            Id = id;
            TransType = transType;
            Created = DateTime.Now;
            Description = description;
            Amount = amount;
            Balance = balance;
        }
        public int Id { get; set; }
        public TransType TransType { get; set; }
        public TransLayer transLayer { get; set; }
        public EntityAffirmation entityAffirmation { get; set; }
        public DateTime Created { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public decimal Balance { get; set; }
    }
}
