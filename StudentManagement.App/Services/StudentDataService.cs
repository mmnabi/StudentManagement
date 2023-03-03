using StudentManagement.Shared.Domain;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace StudentManagement.App.Services
{
    public class StudentDataService : IStudentDataService
    {
        private const string RequestUri = "api/students";
        private readonly HttpClient _httpClient;

        public StudentDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Student>>
                (await _httpClient.GetStreamAsync($"{RequestUri}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Student> GetStudentById(int studentId)
        {
            return await JsonSerializer.DeserializeAsync<Student>
                (await _httpClient.GetStreamAsync($"{RequestUri}/{studentId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }


        public async Task<Student> AddStudent(Student student)
        {
            var studentJson =
                new StringContent(JsonSerializer.Serialize(student), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(RequestUri, studentJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Student>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public async Task UpdateStudent(Student student)
        {
            var studentJson =
                new StringContent(JsonSerializer.Serialize(student), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync(RequestUri, studentJson);
        }

        public async Task DeleteStudent(int studentId)
        {
            await _httpClient.DeleteAsync($"{RequestUri}/{studentId}");
        }

        public async Task<Dictionary<string, int>> GetStudentsPerClass()
        {
            return await JsonSerializer.DeserializeAsync<Dictionary<string, int>>
                (await _httpClient.GetStreamAsync($"{RequestUri}/students-per-class"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Dictionary<string, int>> GetStudentsPerCountry()
        {
            return await JsonSerializer.DeserializeAsync<Dictionary<string, int>>
                (await _httpClient.GetStreamAsync($"{RequestUri}/students-per-country"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<double> GetStudentsAvgAge()
        {
            return await JsonSerializer.DeserializeAsync<double>
                (await _httpClient.GetStreamAsync($"{RequestUri}/students-avg-age"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

    }
}
