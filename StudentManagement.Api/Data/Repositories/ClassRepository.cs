using StudentManagement.Shared.Domain;

namespace StudentManagement.Api.Data.Repositories
{
    public class ClassRepository : IClassRepository
    {
        private readonly AppDbContext _appDbContext;

        public ClassRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Class> GetAllCountries()
        {
            return _appDbContext.Classes;
        }

        public Class GetClassById(int classId)
        {
            return _appDbContext.Classes.FirstOrDefault(c => c.Id == classId);
        }
    }
}
