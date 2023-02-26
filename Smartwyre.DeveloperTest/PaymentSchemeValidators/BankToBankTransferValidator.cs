﻿using Smartwyre.DeveloperTest.AccountValidators;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.PaymentSchemeValidators
{
    public class BankToBankTransferValidator : IPaymentSchemeValidator
    {
        public PaymentScheme PaymentScheme => PaymentScheme.BankToBankTransfer;

        public bool AccountValidForPayment(Account account, MakePaymentRequest paymentRequest)
        {
            if (account == null)
            {
                return false;
            }
            else if (!account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.BankToBankTransfer))
            {
                return false;
            }

            return true;
        }
    }
}
