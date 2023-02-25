using StudentManagement.Shared.Domain;
using System.Diagnostics.Metrics;

namespace StudentManagement.Api.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _appDbContext;

        public StudentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _appDbContext.Students;
        }

        public Student GetStudentById(int studentId)
        {
            return _appDbContext.Students.FirstOrDefault(c => c.Id == studentId);
        }

        public Student AddStudent(Student student)
        {
            var addedEntity = _appDbContext.Students.Add(student);
            _appDbContext.SaveChanges();
            return addedEntity.Entity;
        }

        public Student UpdateStudent(Student student)
        {
            var foundStudent = GetStudentById(student.Id);

            if (foundStudent != null)
            {
                foundStudent.ClassId = student.ClassId;
                foundStudent.CountryId = student.CountryId;
                foundStudent.Name = student.Name;
                foundStudent.DateOfBirth = student.DateOfBirth;

                _appDbContext.SaveChanges();

                return foundStudent;
            }

            return null;
        }

        public void DeleteStudent(int studentId)
        {
            var foundStudent = GetStudentById(studentId);
            if (foundStudent == null) return;

            _appDbContext.Students.Remove(foundStudent);
            _appDbContext.SaveChanges();
        }
    }
}
