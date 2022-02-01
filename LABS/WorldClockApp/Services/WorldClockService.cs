using Newtonsoft.Json;
using WorldClockApp.Models;

namespace WorldClockApp.Services
{
    public class WorldClockService : IWorldClockService
    {
        readonly HttpClient _httpClient;

        public WorldClockService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WorldClockResult?> GetWorldClockTimeAsync()
        {
            HttpResponseMessage httpResponse = await _httpClient
                .GetAsync("http://worldtimeapi.org/api/timezone/Europe/Berlin");

            string jsonRoughResult = await httpResponse.Content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(jsonRoughResult))
                throw new Exception();

            return JsonConvert.DeserializeObject<WorldClockResult>(jsonRoughResult);
        }
    }
}
