using Smartwyre.DeveloperTest.AccountValidators;
using Smartwyre.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.PaymentSchemeValidators
{
    public class AutomatedPaymentSystemValidator : IPaymentSchemeValidator
    {
        public PaymentScheme PaymentScheme => PaymentScheme.AutomatedPaymentSystem;

        public bool IsValidForAccount(Account account, MakePaymentRequest paymentRequest)
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
