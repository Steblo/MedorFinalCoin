using DC.Models.DC.Models;
using System.Text.Json;

namespace DC.Services
{
    public class CryptoService : ICryptoService
    {
        private readonly HttpClient _httpClient;

        public CryptoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://data-api.coindesk.com/");
        }

        public async Task<CryptoRateDto?> GetCryptoRateAsync(string instrument)
        {
            string url = $"spot/v1/latest/tick?market=coinbase&instruments={instrument}";
            var response = await _httpClient.GetStringAsync(url);

            using var doc = JsonDocument.Parse(response);
            var root = doc.RootElement;

            // JSON struktura: { "data": { "BTC-EUR": { "last": 12345.67 } } }
            var data = root.GetProperty("Data");
            if (data.TryGetProperty(instrument, out var instrumentData))
            {
                var price = instrumentData.GetProperty("PRICE").GetDecimal();

                return new CryptoRateDto
                {
                    Instrument = instrument,
                    Price = price,
                    RetrievedAt = DateTime.UtcNow
                };
            }

            return null;
        }
    }
}