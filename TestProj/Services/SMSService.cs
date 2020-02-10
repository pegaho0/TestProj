using System;
using Payir.Models;
using Payir;
using System.Threading.Tasks;

namespace TestProj.Services
{
    public class SMSService  : ISMSService
    {
        private string apiKey = "test";

        #region PaymentResultStatusCode

        public enum PaymentResultStatusCode
        {
            Failed = 0,
            Succeeded = 1
        }

        #endregion

        #region Payment

        public async Task<string>  SendTokenRequest(int amount, int enrollmentId, string mobile = "")
        {
            try
            {
                var request = new PaymentRequest
                {
                    Amount = amount * 10,
                    FactorNumber = enrollmentId.ToString(),
                    Description = ""
                };
                var api = new Payment();
                var response = await api.GetTokenAsync(request);
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
