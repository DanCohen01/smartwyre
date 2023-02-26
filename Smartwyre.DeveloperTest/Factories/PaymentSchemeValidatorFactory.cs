using Smartwyre.DeveloperTest.AccountValidators;
using Smartwyre.DeveloperTest.Exceptions;
using Smartwyre.DeveloperTest.Types;
using System.Collections.Generic;
using System.Linq;

namespace Smartwyre.DeveloperTest.Factories
{
    public class PaymentSchemeValidatorFactory : IPaymentSchemeValidatorBuilder
    {
        IEnumerable<IPaymentSchemeValidator> _paymentSchemeValidators;

        public PaymentSchemeValidatorFactory(IEnumerable<IPaymentSchemeValidator> paymentSchemeValidators)
        {
            _paymentSchemeValidators = paymentSchemeValidators;
        }

        public IPaymentSchemeValidator CreateValidatorForPaymentScheme(PaymentScheme paymentScheme)
        {
            var validator = _paymentSchemeValidators.FirstOrDefault(validator => validator.PaymentScheme == paymentScheme);

            if (validator is null)
            {
                throw new ValidatorNotFoundException();
            }
            return validator;
        }
    }
}
