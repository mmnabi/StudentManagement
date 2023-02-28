using StudentManagement.Shared.Domain;

namespace StudentManagement.Api.Data.Repositories
{
    public interface ICountryRepository
    {
        IEnumerable<Country> GetAllCountries();
        Country GetCountryById(int countryId);
        Country AddCountry(Country country);
        Country UpdateCountry(Country country);
        void DeleteCountry(int countryId);
    }
}
