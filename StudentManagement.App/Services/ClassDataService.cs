using StudentManagement.Shared.Domain;
using System.Text;
using System.Text.Json;

namespace StudentManagement.App.Services
{
    public class ClassDataService : IClassDataService
    {
        private const string RequestUri = "api/classes";
        private readonly HttpClient _httpClient;

        public ClassDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Class>> GetAllClasses()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Class>>
                (await _httpClient.GetStreamAsync($"{RequestUri}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Class> GetClassById(int classId)
        {
            return await JsonSerializer.DeserializeAsync<Class>
                (await _httpClient.GetStreamAsync($"{RequestUri}/{classId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }


        public async Task<Class> AddClass(Class @class)
        {
            var classJson =
                new StringContent(JsonSerializer.Serialize(@class), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(RequestUri, classJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Class>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public async Task UpdateClass(Class @class)
        {
            var classJson =
                new StringContent(JsonSerializer.Serialize(@class), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync(RequestUri, classJson);
        }

        public async Task DeleteClass(int classId)
        {
            await _httpClient.DeleteAsync($"{RequestUri}/{classId}");
        }

    }
}
