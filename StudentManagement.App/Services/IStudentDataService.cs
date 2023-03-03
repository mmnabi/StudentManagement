using StudentManagement.Shared.Domain;

namespace StudentManagement.App.Services
{
    public interface IStudentDataService
    {
        Task<IEnumerable<Student>> GetAllStudents();
        Task<Student> GetStudentById(int studentId);
        Task<Student> AddStudent(Student student);
        Task UpdateStudent(Student student);
        Task DeleteStudent(int studentId);
        Task<Dictionary<string, int>> GetStudentsPerClass();
        Task<Dictionary<string, int>> GetStudentsPerCountry();
        Task<double> GetStudentsAvgAge();
    }
}
