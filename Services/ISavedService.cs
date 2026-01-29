using Shared.Data.Models.Dtos;

namespace DC.Services
{
    public interface ISavedService
    {
        Task SaveAsync(SavedRate rate);
        Task SaveAsync(SaveRateDto dto);
        Task<List<SavedRateDto>> GetAllAsync();
    }

}
