using Shared.Data.Models.Dtos;
using System.Text.Json;

namespace DC.Services
{
    public class LiveService : ILiveService
    {
        private readonly HttpClient _httpClient;

        public LiveService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            // Base URL na CNB API projekt
            _httpClient.BaseAddress = new Uri("https://localhost:7130/");
        }

        public async Task<CnbRateDto?> GetRateAsync(string code)
        {
            var response = await _httpClient.GetAsync($"api/Cnb/{code}");
            if (!response.IsSuccessStatusCode) return null;

            var stream = await response.Content.ReadAsStreamAsync();
            var dto = await JsonSerializer.DeserializeAsync<CnbRateDto>(stream, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return dto;
        }
    }
}
