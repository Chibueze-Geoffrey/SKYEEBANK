using SKYEEBANK.Common;
using SKYEEBANK.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKYEEBANK.Core.Interfaces
{
    public interface ITransactionService : IService
    {
     public void Create(decimal amount, int accountId, TransType transType, TransLayer transLayer, string description);
     public Transaction Get(int id);
     public  List<Transaction> GetAllTransactions(int id);
    }
}
