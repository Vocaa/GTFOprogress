using GTFOprogress.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http.Json;

namespace GTFOprogress.Services
{
    public class RundownRepository
    {
        private HttpClient _httpClient;
        private readonly string _dataFilePath = "Data/levels.json";
        private JsonSerializerOptions _jsonSerializerOptions;

        public RundownRepository(HttpClient client)
        {
            _httpClient = client;
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter() },
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<State> GetData() => await _httpClient.GetFromJsonAsync<State>("Data/levels.json");
    }
}
