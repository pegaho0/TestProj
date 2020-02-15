using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestProj.Api.Dtos;
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
        [HttpPost]
        public async Task<ActionResult> Create([FromBody]PayIrDto dto)
        {
            var pay = await  _sms.SendTokenRequest(dto.Amount, 1, dto.Api, dto.Mobile);

            return Ok(pay);
        }
    }
}
