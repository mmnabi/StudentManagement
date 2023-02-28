using StudentManagement.Shared.Domain;
using System.Text;
using System.Text.Json;

namespace StudentManagement.App.Services
{
    public class CountryDataService : ICountryDataService
    {
        private const string RequestUri = "api/countries";
        private readonly HttpClient _httpClient;

        public CountryDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Country>> GetAllCountries()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Country>>
                (await _httpClient.GetStreamAsync($"{RequestUri}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Country> GetCountryById(int countryId)
        {
            return await JsonSerializer.DeserializeAsync<Country>
                (await _httpClient.GetStreamAsync($"{RequestUri}/{countryId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }


        public async Task<Country> AddCountry(Country country)
        {
            var countryJson =
                new StringContent(JsonSerializer.Serialize(country), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(RequestUri, countryJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Country>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public async Task UpdateCountry(Country country)
        {
            var countryJson =
                new StringContent(JsonSerializer.Serialize(country), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync(RequestUri, countryJson);
        }

        public async Task DeleteCountry(int countryId)
        {
            await _httpClient.DeleteAsync($"{RequestUri}/{countryId}");
        }

    }
}
