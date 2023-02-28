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

        public IEnumerable<Class> GetAllClasses()
        {
            return _appDbContext.Classes;
        }

        public Class GetClassById(int classId)
        {
            return _appDbContext.Classes.FirstOrDefault(c => c.Id == classId);
        }



        public Class AddClass(Class @class)
        {
            var addedEntity = _appDbContext.Classes.Add(@class);
            _appDbContext.SaveChanges();
            return addedEntity.Entity;
        }

        public Class UpdateClass(Class @class)
        {
            var foundClass = GetClassById(@class.Id);

            if (foundClass != null)
            {
                foundClass.ClassName = @class.ClassName;

                _appDbContext.SaveChanges();

                return foundClass;
            }

            return null;
        }

        public void DeleteClass(int @classId)
        {
            var foundClass = GetClassById(@classId);
            if (foundClass == null) return;

            _appDbContext.Classes.Remove(foundClass);
            _appDbContext.SaveChanges();
        }
    }
}
