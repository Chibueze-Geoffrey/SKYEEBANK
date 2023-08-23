using SKYEEBANK.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKYEEBANK.Core.Interfaces
{
    public interface IAccountService : IService   
    {
     public  void Create(string type);


     public  Account Get(int id);

     public void Deposit(decimal amount, int accountId);

     public void Withdraw(decimal amount, int accountId);


     public void Transfer(decimal amount, int accountId, int destinationAccountId);

     public  List<Account> GetAllCustomerAccount(int id);
     public object Get(object countId);
     public void Transfer(decimal amount, int id, object destinationAccount);
    }
}
