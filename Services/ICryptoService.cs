using DC.Models.DC.Models;

namespace DC.Services
{
    public interface ICryptoService
    {
        Task<CryptoRateDto?> GetCryptoRateAsync(string instrument);
    }
}
