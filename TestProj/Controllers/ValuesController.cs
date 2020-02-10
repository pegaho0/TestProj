using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestProj.Services;

namespace TestProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        #region Fields

        private readonly ISMSService _sms;

        #endregion

        #region Ctor

        public ValuesController(ISMSService sms)
        {
            _sms = sms;
        }

        #endregion

        // GET api/values
        [HttpGet]
        public async Task<ActionResult> get()
        {
            var pay = await  _sms.SendTokenRequest(1000,5, "");

            return Ok(pay);
        }

        
    }
}
