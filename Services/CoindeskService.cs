using System.Text.Json;
using DC.Models; // CoinDeskResponse, CoinDeskTick
using Shared.Data.Models.Dtos;

namespace DC.Services
{
    public class CoindeskService : ICoindeskService
    {
        private readonly HttpClient _http;

        public CoindeskService(HttpClient http)
        {
            _http = http;
        }

        public async Task<LiveRateDto> GetBtcEurAsync()
        {
            var url = "https://data-api.coindesk.com/spot/v1/latest/tick?market=coinbase&instruments=BTC-EUR";

            var json = await _http.GetStringAsync(url);

            var response = JsonSerializer.Deserialize<CoinDeskResponse>(json);

            var tick = response.Data["BTC-EUR"];

            return new LiveRateDto
            {
                Symbol = "BTC",
                EurPrice = tick.Price,
                Timestamp = DateTimeOffset.FromUnixTimeSeconds(tick.Timestamp).UtcDateTime
            };
        }
    }
}
