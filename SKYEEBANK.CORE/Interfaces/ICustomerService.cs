using SKYEEBANK.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKYEEBANK.Core.Interfaces
{
    public interface ICustomerService : IService
    {
     public void Create(string firstName, string lastName, string email, string password, string pin);
        Customer Get(int id);
    }
}
