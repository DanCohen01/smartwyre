using Smartwyre.DeveloperTest.AccountValidators;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Factories
{
    public interface IPaymentSchemeValidatorBuilder
    {
        IPaymentSchemeValidator CreateValidatorForPaymentScheme(PaymentScheme paymentScheme);
    }
}
