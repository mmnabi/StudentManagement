using Microsoft.EntityFrameworkCore;
using StudentManagement.Shared.Domain;

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
            return _appDbContext.Students.AsNoTracking()
                .Include(e => e.Class)
                .Include(e => e.Country)
                .Select(e => new Student
                {
                    Id = e.Id,
                    Name = e.Name,
                    DateOfBirth = e.DateOfBirth,
                    Country = new Country { Name = e.Country.Name },
                    Class = new Class { ClassName = e.Class.ClassName },
                });
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

        public Dictionary<string, int> GetStudentsPerClass()
        {
            var gResult = from a in _appDbContext.Students
                          join b in _appDbContext.Classes on a.ClassId equals b.Id
                          group a by b into g
                          select new
                          {
                              Class = g.Key.ClassName,
                              StudentCount = g.Count()
                          };
            var list = gResult.ToList();
            return list.ToDictionary(e => e.Class, e => e.StudentCount);
        }

        public Dictionary<string, int> GetStudentsPerCountry()
        {
            var gResult = from a in _appDbContext.Students
                          join b in _appDbContext.Countries on a.CountryId equals b.Id
                          group a by b into g
                          select new
                          {
                              Country = g.Key.Name,
                              StudentCount = g.Count()
                          };
            var list = gResult.ToList();
            return list.ToDictionary(e => e.Country, e => e.StudentCount);
        }

        public double GetStudentsAvgAge()
        {
            var list = _appDbContext.Students
                .AsNoTracking()
                .Select(e => e.DateOfBirth).ToList();
            return list.Average(dt => (DateTime.Now - dt.GetValueOrDefault()).TotalDays);
        }
    }
}
