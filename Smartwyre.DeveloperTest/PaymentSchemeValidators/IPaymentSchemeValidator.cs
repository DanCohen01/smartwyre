using Smartwyre.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.AccountValidators
{
    public interface IPaymentSchemeValidator
    {
        public PaymentScheme PaymentScheme { get; }

        public bool IsValidForAccount(Account account, MakePaymentRequest paymentRequest);
    }
}
