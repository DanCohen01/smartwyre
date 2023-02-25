using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Factories;
using Smartwyre.DeveloperTest.Types;
using System.Configuration;

namespace Smartwyre.DeveloperTest.Services
{
    public class PaymentService : IPaymentService
    {
        IPaymentSchemeValidatorBuilder _paymentSchemeValidatorBuilder;

        public PaymentService(IPaymentSchemeValidatorBuilder paymentSchemeValidatorBuilder)
        {
            _paymentSchemeValidatorBuilder = paymentSchemeValidatorBuilder;
        }

        public MakePaymentResult MakePayment(MakePaymentRequest request)
        {
            var accountDataStoreGetData = new AccountDataStore();
            Account account = accountDataStoreGetData.GetAccount(request.DebtorAccountNumber);

            var result = new MakePaymentResult();
            var validator = _paymentSchemeValidatorBuilder.CreateValidatorForPayment(request);
            if (validator.IsValidForAccount(account, request))
            {
                result.Success = true;
                account.Withdraw(request.Amount);

                var accountDataStoreUpdateData = new AccountDataStore();
                accountDataStoreUpdateData.UpdateAccount(account);
                return result;
            }
            return result;

        }
    }
}
