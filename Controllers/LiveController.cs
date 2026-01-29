using DC.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class LiveController : ControllerBase
{
    private readonly ILiveService _liveService;

    public LiveController(ILiveService liveService)
    {
        _liveService = liveService;
    }

    [HttpGet("{code}")]
    public async Task<ActionResult<CnbRateDto>> GetRate(string code)
    {
        var rateDto = await _liveService.GetRateAsync(code);
        if (rateDto is null) return NotFound();
        return Ok(new CnbRateDto
        {
            Currency = code.ToUpper(),
            Rate = rateDto.Rate,
            Date = DateTime.UtcNow
        });
    }
}