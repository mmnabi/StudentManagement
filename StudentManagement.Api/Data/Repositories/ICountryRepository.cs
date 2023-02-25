using StudentManagement.Shared.Domain;

namespace StudentManagement.Api.Data.Repositories
{
    public interface ICountryRepository
    {
        IEnumerable<Country> GetAllCountries();
        Country GetCountryById(int countryId);
    }
}
