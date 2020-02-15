using System;
using Payir.Models;
using Payir;
using System.Threading.Tasks;

namespace TestProj.Services
{
    public class SMSService  : ISMSService
    {
        public const string ApiKey = "X-API-KEY";

        #region PaymentResultStatusCode

        public enum PaymentResultStatusCode
        {
            Failed = 0,
            Succeeded = 1
        }

        #endregion

        #region Payment

        public async Task<string>  SendTokenRequest(int amount, int enrollmentId, string api, string mobile)
        {
            try
            {
                var request = new PaymentRequest
                {
                    amount = amount * 10,
                    redirect = "https://ukademu.com",
                    FactorNumber = enrollmentId.ToString(),
                    Description = ""
                };
                var apiKey = new Payment();
                
                var response = await apiKey.GetTokenAsync(request);
                if (response.Status) 
                    return response.Token;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return null;
        }

        public string CheckTransId(string token)
        {
            var paymentVerify = new PaymentVerify { };
            var api = new Payment();
            var verify = api.VerifyAsync(paymentVerify);

            return verify.Status.ToString();
        }

        #endregion
    }
}
