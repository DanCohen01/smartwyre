using Microsoft.Extensions.DependencyInjection;
using Smartwyre.DeveloperTest.AccountValidators;
using Smartwyre.DeveloperTest.Factories;
using Smartwyre.DeveloperTest.PaymentSchemeValidators;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Types;
using System;

namespace Smartwyre.DeveloperTest.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IPaymentService, PaymentService>()
                .AddSingleton<IPaymentSchemeValidatorBuilder,PaymentSchemeValidatorFactory>()
                .AddSingleton<IPaymentSchemeValidator, AutomatedPaymentSystemValidator>()
                .AddSingleton<IPaymentSchemeValidator, BankToBankTransferValidator>()
                .AddSingleton<IPaymentSchemeValidator, ExpeditedPaymentsValidator>()
                .BuildServiceProvider();

           
            var paymentService = serviceProvider.GetService<IPaymentService>();
            var paymentResult = paymentService.MakePayment(new MakePaymentRequest()
            {
                Amount = 1,
                DebtorAccountNumber = "12345678",
                CreditorAccountNumber = "87654321",
                PaymentDate = DateTime.UtcNow,
                PaymentScheme = PaymentScheme.ExpeditedPayments
            });

        }
    }
}
