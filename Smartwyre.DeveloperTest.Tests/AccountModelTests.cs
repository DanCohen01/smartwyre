using Smartwyre.DeveloperTest.Types;
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
            var account = TestHelper.CreateMockAccount(balance);
            var expectedBalance = balance - amount;
            account.Withdraw(amount);
            Assert.Equal(expectedBalance, account.Balance);
        }

    }
}
