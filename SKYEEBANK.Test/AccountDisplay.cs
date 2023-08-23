using SKYEEBANK.Common;
using SKYEEBANK.Entities;

namespace SKYEEBANK.Test
{
    public class AccountDisplay
    {
        [Fact]
        public void AccountBalanceValid()
        {
            var customer = new Customer(0, "Chibueze", "Geoffrey", "chibueze@mail.com",
                "Chibueze11@", "1234");
            var account = new Account(0, customer.FullName, "011999", AccountType.Current,40000);

            decimal expected = 40000M;
            decimal actual = account.Balance;
            Assert.Equal(expected, actual);

        }
        [Fact]
        public void Withdraw()
        {
            var account = new Transaction(11, TransType.Debit, TransLayer.Withdrawal, "Groceries", 2000,10000);
            decimal expected = 2000;
            decimal actual = account.Amount;
            Assert.Equal(expected, actual);
          
        }
        [Fact]
        public void Transfer()
        {
            var transfer = new Transaction(0, TransType.Credit, TransLayer.Transfer, "book", 4000,6000);
            decimal expected = 4000;
            decimal actual = transfer.Amount;
            Assert.Equal(expected, actual);
        }
    }
}