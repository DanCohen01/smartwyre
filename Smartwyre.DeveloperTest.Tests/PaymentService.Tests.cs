using Moq;
using Smartwyre.DeveloperTest.AccountValidators;
using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Factories;
using Smartwyre.DeveloperTest.PaymentSchemeValidators;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Types;
using System;
using Xunit;

namespace Smartwyre.DeveloperTest.Tests
{
    public class PaymentServiceTests
    {
        Mock<IAccountDataStore> _mockDataStore;
        Mock<IPaymentSchemeValidatorBuilder> _mockPaymentSchemeValidatorFactory;
        Mock<IPaymentSchemeValidator> _mockPaymentSchemeValidator;
        PaymentService _paymentService;

        public PaymentServiceTests()
        {
            _mockDataStore = new Mock<IAccountDataStore>();
            _mockPaymentSchemeValidatorFactory = new Mock<IPaymentSchemeValidatorBuilder>();
            _mockPaymentSchemeValidator = new Mock<IPaymentSchemeValidator>();
            _paymentService = new PaymentService(_mockPaymentSchemeValidatorFactory.Object, _mockDataStore.Object);
        }

        [Fact]
        public void Given_ValidPaymentRequest_When_MakePaymentCalled_Then_SuccessReturned()
        {
            var makePaymentRequest = new MakePaymentRequest()
            {
                Amount = 1,
                DebtorAccountNumber = "12345678",
                CreditorAccountNumber = "87654321",
                PaymentDate = DateTime.UtcNow,
                PaymentScheme = PaymentScheme.ExpeditedPayments
            };

            _mockDataStore.Setup(x => x.GetAccount(It.IsAny<string>())).Returns(TestHelper.CreateMockAccount());
            _mockPaymentSchemeValidator.Setup(x => x.AccountValidForPayment(It.IsAny<Account>(), It.IsAny<MakePaymentRequest>())).Returns(true);
            _mockPaymentSchemeValidatorFactory.Setup(x => x.CreateValidatorForPaymentScheme(It.IsAny<PaymentScheme>())).Returns(_mockPaymentSchemeValidator.Object);

            var paymentResult = _paymentService.MakePayment(makePaymentRequest);

            Assert.True(paymentResult.Success);

        }

        [Fact]
        public void Given_ValidatorFails_When_MakePaymentCalled_Then_FailureReturned()
        {
            var makePaymentRequest = new MakePaymentRequest()
            {
                Amount = 1,
                DebtorAccountNumber = "12345678",
                CreditorAccountNumber = "87654321",
                PaymentDate = DateTime.UtcNow,
                PaymentScheme = PaymentScheme.ExpeditedPayments
            };

            _mockDataStore.Setup(x => x.GetAccount(It.IsAny<string>())).Returns(TestHelper.CreateMockAccount());
            _mockPaymentSchemeValidator.Setup(x => x.AccountValidForPayment(It.IsAny<Account>(), It.IsAny<MakePaymentRequest>())).Returns(false);
            _mockPaymentSchemeValidatorFactory.Setup(x => x.CreateValidatorForPaymentScheme(It.IsAny<PaymentScheme>())).Returns(_mockPaymentSchemeValidator.Object);

            var paymentResult = _paymentService.MakePayment(makePaymentRequest);

            Assert.False(paymentResult.Success);

        }

        [Fact]
        public void Given_ValidPaymentRequest_When_MakePaymentCalled_Then_AccountBalanceReduced()
        {
            var makePaymentRequest = new MakePaymentRequest()
            {
                Amount = 1,
                DebtorAccountNumber = "12345678",
                CreditorAccountNumber = "87654321",
                PaymentDate = DateTime.UtcNow,
                PaymentScheme = PaymentScheme.ExpeditedPayments
            };

            var mockAccount = TestHelper.CreateMockAccount();
            var expectedBalance = mockAccount.Balance - makePaymentRequest.Amount;
            _mockDataStore.Setup(x => x.GetAccount(It.IsAny<string>())).Returns(mockAccount);
            _mockPaymentSchemeValidator.Setup(x => x.AccountValidForPayment(It.IsAny<Account>(), It.IsAny<MakePaymentRequest>())).Returns(true);
            _mockPaymentSchemeValidatorFactory.Setup(x => x.CreateValidatorForPaymentScheme(It.IsAny<PaymentScheme>())).Returns(_mockPaymentSchemeValidator.Object);

            var paymentResult = _paymentService.MakePayment(makePaymentRequest);

            Assert.Equal(expectedBalance, mockAccount.Balance);
            Assert.True(paymentResult.Success);

        }

        [Fact]
        public void Given_ValidPaymentRequest_When_MakePaymentCalled_Then_AccountUpdated()
        {
            var makePaymentRequest = new MakePaymentRequest()
            {
                Amount = 1,
                DebtorAccountNumber = "12345678",
                CreditorAccountNumber = "87654321",
                PaymentDate = DateTime.UtcNow,
                PaymentScheme = PaymentScheme.ExpeditedPayments
            };

            _mockDataStore.Setup(x => x.GetAccount(It.IsAny<string>())).Returns(TestHelper.CreateMockAccount());
            _mockPaymentSchemeValidator.Setup(x => x.AccountValidForPayment(It.IsAny<Account>(), It.IsAny<MakePaymentRequest>())).Returns(true);
            _mockPaymentSchemeValidatorFactory.Setup(x => x.CreateValidatorForPaymentScheme(It.IsAny<PaymentScheme>())).Returns(_mockPaymentSchemeValidator.Object);

            var paymentResult = _paymentService.MakePayment(makePaymentRequest);

            _mockDataStore.Verify(x => x.UpdateAccount(It.IsAny<Account>()), Times.Once);
            Assert.True(paymentResult.Success);

        }

    }
}
