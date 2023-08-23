using SKYEEBANK.Common;
using SKYEEBANK.Core.Interfaces;
using SKYEEBANK.Data;
using SKYEEBANK.Entities; 

namespace SKYEEBANK.Core.Implementations
{
    public class TransactionService : ITransactionService
    {
        public void Create(decimal amount, int accountId, TransType transType, 
            TransLayer transLayer, string description)
        {
            var trans = new Transaction();

            DataStore.transactions.Add(trans);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(int id)
        {
            throw new NotImplementedException();
        }

        public Transaction Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Transaction> GetAllTransactions(int id)
        {
            throw new NotImplementedException();
        }


    }
}
