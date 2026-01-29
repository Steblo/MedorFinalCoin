using DC.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class DcController : ControllerBase
{
    private readonly ICryptoService _cryptoService;
    private readonly ILiveService _liveService;

    public DcController(ICryptoService cryptoService, ILiveService liveService)
    {
        _cryptoService = cryptoService;
        _liveService = liveService;
    }

    [HttpGet("btc-czk")]
    public async Task<ActionResult<object>> GetBtcCzk()
    {
        var btcEur = await _cryptoService.GetCryptoRateAsync("BTC-EUR");
        if (btcEur == null) return NotFound("BTC/EUR kurz nebyl nalezen.");

        var eurCzk = await _liveService.GetRateAsync("EUR");
        if (eurCzk == null) return NotFound("EUR/CZK kurz nebyl nalezen.");

        var btcCzk = btcEur.Price * eurCzk.Rate;

        return Ok(new
        {
            Instrument = "BTC-CZK",
            Price = btcCzk,
            RetrievedAt = DateTime.UtcNow
        });
    }
}
