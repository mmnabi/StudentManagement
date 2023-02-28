using StudentManagement.Shared.Domain;

namespace StudentManagement.Api.Data.Repositories
{
    public interface IClassRepository
    {
        IEnumerable<Class> GetAllClasses();
        Class GetClassById(int classId);
        Class AddClass(Class @class);
        Class UpdateClass(Class @class);
        void DeleteClass(int @classId);
    }
}
