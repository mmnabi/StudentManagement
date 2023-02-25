using StudentManagement.Shared.Domain;

namespace StudentManagement.Api.Data.Repositories
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAllStudents();
        Student GetStudentById(int studentId);
        Student AddStudent(Student student);
        Student UpdateStudent(Student student);
        void DeleteStudent(int studentId);
    }
}
