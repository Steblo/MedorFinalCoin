using Microsoft.AspNetCore.Mvc;
using DC.Services;
using Shared.Data.Models.Dtos;

namespace DC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CryptoController : ControllerBase
    {
        private readonly ICoindeskService _coindesk;

        public CryptoController(ICoindeskService coindesk)
        {
            _coindesk = coindesk;
        }

        [HttpGet("btc-eur")]
        public async Task<ActionResult<LiveRateDto>> GetBtcEur()
        {
            var result = await _coindesk.GetBtcEurAsync();
            return Ok(result);
        }
    }
}
