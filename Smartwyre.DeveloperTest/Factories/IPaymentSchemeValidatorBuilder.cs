using Smartwyre.DeveloperTest.AccountValidators;
using Smartwyre.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Factories
{
    public interface IPaymentSchemeValidatorBuilder
    {
        IPaymentSchemeValidator CreateValidatorForPayment(MakePaymentRequest paymentRequest);
    }
}
