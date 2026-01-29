using DC.Services;
using Microsoft.EntityFrameworkCore;
using Shared.Data.Models.Dtos;

public class SavedService : ISavedService
{
    private readonly AppDbContext _db;

    public SavedService(AppDbContext db)
    {
        _db = db;
    }

    public async Task SaveAsync(SaveRateDto dto)
    {
        var entity = new SavedRate
        {
            Code = dto.Code,
            Rate = dto.Rate,
            SavedAt = DateTime.UtcNow
        };

        _db.SavedRates.Add(entity);
        await _db.SaveChangesAsync();
    }

    public Task SaveAsync(SavedRate rate)
    {
        throw new NotImplementedException();
    }

    public async Task<List<SavedRateDto>> GetAllAsync()
    {
        return await _db.SavedRates
            .Select(r => new SavedRateDto
            {
                Code = r.Code,
                Rate = r.Rate,
                SavedAt = r.SavedAt
            })
            .ToListAsync();
    }
}