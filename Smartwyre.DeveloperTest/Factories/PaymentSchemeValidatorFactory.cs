using Smartwyre.DeveloperTest.AccountValidators;
using Smartwyre.DeveloperTest.Exceptions;
using Smartwyre.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Factories
{
    public class PaymentSchemeValidatorFactory : IPaymentSchemeValidatorBuilder
    {
        IEnumerable<IPaymentSchemeValidator> _paymentSchemeValidators;

        public PaymentSchemeValidatorFactory(IEnumerable<IPaymentSchemeValidator> paymentSchemeValidators)
        {
            _paymentSchemeValidators = paymentSchemeValidators;
        }

        public IPaymentSchemeValidator CreateValidatorForPayment(MakePaymentRequest paymentRequest)
        {
            var validator = _paymentSchemeValidators.FirstOrDefault(validator => validator.PaymentScheme == paymentRequest.PaymentScheme);
            if (validator is null)
            {
                throw new ValidatorNotFoundException();
            }
            return validator;
        }
    }
}
