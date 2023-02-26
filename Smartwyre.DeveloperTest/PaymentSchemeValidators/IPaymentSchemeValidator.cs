using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.AccountValidators
{
    public interface IPaymentSchemeValidator
    {
        public PaymentScheme PaymentScheme { get; }

        public bool AccountValidForPayment(Account account, MakePaymentRequest paymentRequest);
    }
}
