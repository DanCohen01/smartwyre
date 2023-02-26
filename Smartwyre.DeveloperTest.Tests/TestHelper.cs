using Smartwyre.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Tests
{
    public static class TestHelper
    {
        public static Account CreateMockAccount(decimal balance = 100, AllowedPaymentSchemes paymentSchemes = AllowedPaymentSchemes.BankToBankTransfer | AllowedPaymentSchemes.ExpeditedPayments | AllowedPaymentSchemes.AutomatedPaymentSystem)
        {
            return new Account(
                "12345678", 
                balance, 
                AccountStatus.Live, 
                paymentSchemes);
        }
    }
}
