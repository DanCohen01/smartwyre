using Smartwyre.DeveloperTest.AccountValidators;
using Smartwyre.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.PaymentSchemeValidators
{
    public class ExpeditedPaymentsValidator : IPaymentSchemeValidator
    {
        public PaymentScheme PaymentScheme => PaymentScheme.ExpeditedPayments;

        public bool IsValidForAccount(Account account, MakePaymentRequest paymentRequest)
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
