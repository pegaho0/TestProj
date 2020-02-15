using System;
using Payir.Models;
using Payir;
using System.Threading.Tasks;

namespace TestProj.Services
{
    public interface ISMSService 
    {

        Task<string> SendTokenRequest(int amount, int enrollmentId, string api, string mobile = "");

        string CheckTransId(string token);
       
    }
}
