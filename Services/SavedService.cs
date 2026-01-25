using DC.Services;
using Shared.Data;
using Shared.Data.Models;

public class SavedService : ISavedService
{
    private readonly AppDbContext _db;

    public SavedService(AppDbContext db)
    {
        _db = db;
    }

    public async Task SaveAsync(SavedRate rate)
    {
        _db.SavedRates.Add(rate);
        await _db.SaveChangesAsync();
    }
}