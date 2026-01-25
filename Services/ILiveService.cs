using Shared.Data.Models.Dtos;

namespace DC.Services
{
    public interface ILiveService
    {
        Task<LiveRateDto> GetLiveRateAsync();
    }
}
