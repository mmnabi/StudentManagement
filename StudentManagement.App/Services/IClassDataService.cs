using StudentManagement.Shared.Domain;

namespace StudentManagement.App.Services
{
    public interface IClassDataService
    {
        Task<IEnumerable<Class>> GetAllClasses();
        Task<Class> GetClassById(int classId);
        Task<Class> AddClass(Class @class);
        Task UpdateClass(Class @class);
        Task DeleteClass(int classId);
    }
}
