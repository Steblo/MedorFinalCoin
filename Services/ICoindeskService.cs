using Shared.Data.Models.Dtos;

namespace DC.Services
{
    public interface ICoindeskService
    {
        Task<LiveRateDto> GetBtcEurAsync();
    }
}