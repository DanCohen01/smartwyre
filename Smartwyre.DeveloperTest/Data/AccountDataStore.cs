using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Data
{
    public class AccountDataStore : IAccountDataStore
    {
        public Account GetAccount(string accountNumber)
        {
            // Access database to retrieve account, code removed for brevity 
            return new Account(accountNumber, 1000, AccountStatus.Live, AllowedPaymentSchemes.BankToBankTransfer | AllowedPaymentSchemes.ExpeditedPayments | AllowedPaymentSchemes.AutomatedPaymentSystem);
        }

        public void UpdateAccount(Account account)
        {
            // Update account in database, code removed for brevity
        }
    }
}
