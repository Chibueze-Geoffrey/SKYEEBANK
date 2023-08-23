using SKYEEBANK.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKYEEBANK.UI
{
    public interface IAccountDisplay
    {

     public  void DisplayDashboard();

     public  void DisplayCreateAccountMenu(Customer customer);

     public  void DisplayViewAccountMenu(Customer customer);

     public void DisplaySingleAccount(Account account);


     public void DisplayDepositMenu(Account account);


     public void DisplayWithdrawalMenu(Account account);


     public void DisplayTransferMenu(Account account);


     public  void DisplayAccountStatement(Account account);

     public void DisplayAccountBalance(Account account);
    }
}
