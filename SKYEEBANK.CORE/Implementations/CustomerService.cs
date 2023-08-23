using SKYEEBANK.Core.Interfaces;
using SKYEEBANK.Data;
using SKYEEBANK.Entities;


namespace SKYEEBANK.Core.Implementations
{
    public class CustomerService : ICustomerService
    {

        private int idCount;
        public void Create(string firstName, string lastName, string email, string password, string pin)
        {
            idCount++;
            var customer = new Customer(idCount, firstName, lastName, email, password, pin);
            DataStore.customers.Add(customer);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(int id)
        {
            throw new NotImplementedException();
        }

        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
