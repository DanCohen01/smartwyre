using Smartwyre.DeveloperTest.AccountValidators;
using Smartwyre.DeveloperTest.Exceptions;
using Smartwyre.DeveloperTest.Factories;
using Smartwyre.DeveloperTest.PaymentSchemeValidators;
using Smartwyre.DeveloperTest.Types;
using System.Collections.Generic;
using Xunit;

namespace Smartwyre.DeveloperTest.Tests
{
    public class PaymentSchemeValidatorFactoryTests
    {

        PaymentSchemeValidatorFactory factory;
        public PaymentSchemeValidatorFactoryTests()
        {
            var validatorsList = new List<IPaymentSchemeValidator>()
            {
                new AutomatedPaymentSystemValidator(),
                new BankToBankTransferValidator(),
                new ExpeditedPaymentsValidator()
                
            };
            factory = new PaymentSchemeValidatorFactory(validatorsList);
        }

        [Theory]
        [InlineData(PaymentScheme.ExpeditedPayments)]
        [InlineData(PaymentScheme.BankToBankTransfer)]
        [InlineData(PaymentScheme.AutomatedPaymentSystem)]
        public void Given_KnownPaymentScheme_When_CreateValidatorForPaymentSchemeCalled_ThenMatchingValidatorReturned(PaymentScheme paymentScheme)
        {
            var validator = factory.CreateValidatorForPaymentScheme(paymentScheme);
            Assert.Equal(paymentScheme, validator.PaymentScheme);
        }

        [Fact]
        public void Given_UnknownPaymentScheme_When_CreateValidatorForPaymentSchemeCalled_ThenMatchingValidatorReturned()
        {
            //exclude B2B
            var validatorsList = new List<IPaymentSchemeValidator>()
            {
                new AutomatedPaymentSystemValidator(),
                new ExpeditedPaymentsValidator()

            };
            factory = new PaymentSchemeValidatorFactory(validatorsList);
            var unknownScheme = PaymentScheme.BankToBankTransfer;

            Assert.Throws<ValidatorNotFoundException>(() => factory.CreateValidatorForPaymentScheme(unknownScheme));
        }
    }
}
