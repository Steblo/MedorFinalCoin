using Microsoft.AspNetCore.Mvc;
using Shared.Data.Models.Dtos;
using DC.Services;

namespace DC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LiveController : ControllerBase
    {
        private readonly ILiveService _service;

        public LiveController(ILiveService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<LiveRateDto>> GetLiveRate()
        {
            var result = await _service.GetLiveRateAsync();
            return Ok(result);
        }
    }
}
