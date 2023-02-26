using Smartwyre.DeveloperTest.PaymentSchemeValidators;
using Smartwyre.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Smartwyre.DeveloperTest.Tests.ValidatorTests.cs
{
    public class AutomatedPaymentSystemValidatorTests
    {
        AutomatedPaymentSystemValidator _automatedPaymentSystemValidator;

        public AutomatedPaymentSystemValidatorTests()
        {
            _automatedPaymentSystemValidator = new AutomatedPaymentSystemValidator();
        }

        [Fact]
        public void Given_PaymentSchemeSupported_When_AccountValidForPaymentCalled_Then_TrueReturned()
        {

            var account = TestHelper.CreateMockAccount(100, AllowedPaymentSchemes.AutomatedPaymentSystem);
            var payment = new MakePaymentRequest { };

            var validationResult = _automatedPaymentSystemValidator.AccountValidForPayment(account, payment);

            Assert.True(validationResult);
        }


        [Fact]
        public void Given_PaymentSchemeUnsupported_When_AccountValidForPaymentCalled_Then_FalseReturned()
        {

            var account = TestHelper.CreateMockAccount(100, AllowedPaymentSchemes.BankToBankTransfer);
            var payment = new MakePaymentRequest { };

            var validationResult = _automatedPaymentSystemValidator.AccountValidForPayment(account, payment);

            Assert.False(validationResult);
        }

        [Fact]
        public void Given_AccountStatusNotLive_When_AccountValidForPaymentCalled_Then_FalseReturned()
        {

            var account = TestHelper.CreateMockAccount(100, AllowedPaymentSchemes.BankToBankTransfer, AccountStatus.InboundPaymentsOnly);
            var payment = new MakePaymentRequest { };

            var validationResult = _automatedPaymentSystemValidator.AccountValidForPayment(account, payment);

            Assert.False(validationResult);
        }

        [Fact]
        public void Given_AccountNull_When_AccountValidForPaymentCalled_Then_FalseReturned()
        {

            var payment = new MakePaymentRequest { };

            var validationResult = _automatedPaymentSystemValidator.AccountValidForPayment(null, payment);

            Assert.False(validationResult);
        }
    }
}
