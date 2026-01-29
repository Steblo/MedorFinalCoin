using Shared.Data.Models.Dtos;

namespace DC.Services
{
    public interface ILiveService
    {
        Task<CnbRateDto?> GetRateAsync(string code);
    }
}
