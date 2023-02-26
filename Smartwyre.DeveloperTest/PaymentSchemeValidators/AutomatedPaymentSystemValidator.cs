using Smartwyre.DeveloperTest.AccountValidators;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.PaymentSchemeValidators
{
    public class AutomatedPaymentSystemValidator : IPaymentSchemeValidator
    {
        public PaymentScheme PaymentScheme => PaymentScheme.AutomatedPaymentSystem;

        public bool AccountValidForPayment(Account account, MakePaymentRequest paymentRequest)
        {
            if (account == null)
            {
                return false;
            }
            else if (!account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.AutomatedPaymentSystem))
            {
                return false;
            }
            else if (account.Status != AccountStatus.Live)
            {
                return false;
            }   

            return true;
        }
    }
}
