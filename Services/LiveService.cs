using Shared.Data.Models.Dtos;

namespace DC.Services
{
    public class LiveService(HttpClient http) : ILiveService
    {
        private readonly HttpClient _http = http;

        public async Task<LiveRateDto> GetLiveRateAsync()
        {
            var coinDeskUrl = "https://data-api.coindesk.com/spot/v1/latest/tick?market=coinbase&instruments=BTC-EUR";
            var coinDeskJson = await _http.GetStringAsync(coinDeskUrl);

            // TODO: parse JSON
            // TODO: fetch CNB
            // TODO: compute CZK price

            return new LiveRateDto
            {
                Symbol = "BTC",
                EurPrice = 0,
                CzkPrice = 0,
                Timestamp = DateTime.UtcNow
            };
        }
    }
}
