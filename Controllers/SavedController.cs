using DC.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.Data.Models.Dtos;

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
    public async Task<IActionResult> Save(SaveRateDto dto)
    {
        await _service.SaveAsync(dto);
        return Ok(new { message = "Rate saved successfully" });
    }

    [HttpGet]
    public async Task<List<SavedRateDto>> GetAll()
    {
        return await _service.GetAllAsync();
    }
}
