using DC.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.Data.Models;

namespace DC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SavedController : ControllerBase
    {
        private readonly ISavedService _service;

        public SavedController(ISavedService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] SavedRate rate)
        {
            await _service.SaveAsync(rate);
            return Ok();
        }
    }
}