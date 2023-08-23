using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SKYEEBANK.Core.Implementations;
using SKYEEBANK.Core.Interfaces;
using SKYEEBANK.Helpers;
using SKYEEBANK.UI;

namespace SKYEEBANK
{
    public  class Program 
    {
      
        static void Main(string[] args)
        {

            var host = Host.CreateDefaultBuilder()
                           .ConfigureServices((context, services) =>
                           {
                               services.AddScoped<ICustomerService, CustomerService>();
                               services.AddScoped<ITransactionService, TransactionService>();
                               services.AddScoped<IAccountService, AccountService>();
                               services.AddScoped<IAccountDisplay, AccountDisplay>();
                               services.AddScoped<ILogabbleDisplay, LogabbleDisplay>();
                           }).Build();
            var print = ActivatorUtilities.CreateInstance<Print>(host.Services);
            Print.PrintLogo();
            var userInterface = ActivatorUtilities.CreateInstance<UserInterface>(host.Services);
            userInterface.Run();

        }
      
    }
}