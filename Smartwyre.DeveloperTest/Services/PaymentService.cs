using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Exceptions;
using Smartwyre.DeveloperTest.Factories;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Services
{
    public class PaymentService : IPaymentService
    {
        IPaymentSchemeValidatorBuilder _paymentSchemeValidatorBuilder;
        IAccountDataStore _accountDataStore;

        public PaymentService(IPaymentSchemeValidatorBuilder paymentSchemeValidatorBuilder, IAccountDataStore accountDataStore)
        {
            _paymentSchemeValidatorBuilder = paymentSchemeValidatorBuilder;
            _accountDataStore = accountDataStore;
        }

        public MakePaymentResult MakePayment(MakePaymentRequest request)
        {
            var account = _accountDataStore.GetAccount(request.DebtorAccountNumber);

            var result = new MakePaymentResult();
            var validator = _paymentSchemeValidatorBuilder.CreateValidatorForPaymentScheme(request.PaymentScheme);
            if (validator.AccountValidForPayment(account, request))
            {
                result.Success = true;
                account.Withdraw(request.Amount);
                _accountDataStore.UpdateAccount(account);
                return result;
            }
            return result;

        }
    }
}
