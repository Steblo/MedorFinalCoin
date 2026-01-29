using DC.Models.DC.Models;
using DC.Services;
using Microsoft.AspNetCore.Mvc;

namespace DC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CryptoController : ControllerBase
    {
        private readonly ICryptoService _cryptoService;

        public CryptoController(ICryptoService cryptoService)
        {
            _cryptoService = cryptoService;
        }

        [HttpGet("{instrument}")]
        public async Task<ActionResult<CryptoRateDto>> GetCryptoRate(string instrument)
        {
            var rate = await _cryptoService.GetCryptoRateAsync(instrument);
            if (rate == null) return NotFound($"Instrument {instrument} nebyl nalezen.");
            return Ok(rate);
        }
    }
}
