using SKYEEBANK.Core.Loging;
using SKYEEBANK.Helpers;
using System.Globalization;
using System.Text;

namespace SKYEEBANK.UI;

public class UserInterface
{

    private readonly IAccountDisplay _accountDisplay;
    private readonly ILogabbleDisplay _logabbleDisplay;


#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public UserInterface(IAccountDisplay accountDisplay, ILogabbleDisplay logabbleDisplay)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
        _accountDisplay = accountDisplay;
        _logabbleDisplay = logabbleDisplay;
    }

    public Encoding OutputEncoding { get; set; }

    public void Run()
    {
        // set console output encoding to accept unicode
        OutputEncoding = Encoding.UTF8;

        // change current culture to english-Nigeria
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-NG", false);

        Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol = "\u20A6";
        // set currency symbol to naira (already works)

        // skip authentication and bank account creation stages
        //Faker.Initiate();


        while (true)
        {
            while (Log.CurrentCustomer == null)
            {
                Print.PrintLogo();
                _logabbleDisplay.DisplayAccountMenu();
            }

            _accountDisplay.DisplayDashboard();
        }
    }



}