using Smartwyre.DeveloperTest.AccountValidators;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.PaymentSchemeValidators
{
    public class ExpeditedPaymentsValidator : IPaymentSchemeValidator
    {
        public PaymentScheme PaymentScheme => PaymentScheme.ExpeditedPayments;

        public bool AccountValidForPayment(Account account, MakePaymentRequest paymentRequest)
        {
            if (account == null)
            {
                return false;
            }
            else if (!account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.ExpeditedPayments))
            {
                return false;
            }
            else if (account.Balance < paymentRequest.Amount)
            {
                return false;
            }

            return true;
        }
    }
}
