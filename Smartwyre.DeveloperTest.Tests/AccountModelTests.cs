using Smartwyre.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Smartwyre.DeveloperTest.Tests
{
    public  class AccountModelTests
    {
        [Theory]
        [InlineData(100, 50)]
        [InlineData(300, 299)]
        [InlineData(15, 7.37)]
        public void Given_ValidAccount_When_WithdrawCalled_Then_BalanceReduced(decimal balance, decimal amount)
        {
            var account = CreateMockAccount(balance);
            var expectedBalance = balance - amount;
            account.Withdraw(amount);
            Assert.Equal(expectedBalance, account.Balance);
        }

        public Account CreateMockAccount(decimal balance)
        {
            return new Account("12345678", balance, AccountStatus.Live, AllowedPaymentSchemes.BankToBankTransfer | AllowedPaymentSchemes.ExpeditedPayments | AllowedPaymentSchemes.AutomatedPaymentSystem);
        }
    }
}
