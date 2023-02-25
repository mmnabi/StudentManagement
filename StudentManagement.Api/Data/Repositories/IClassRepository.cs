using StudentManagement.Shared.Domain;

namespace StudentManagement.Api.Data.Repositories
{
    public interface IClassRepository
    {
        IEnumerable<Class> GetAllCountries();
        Class GetClassById(int classId);
    }
}
