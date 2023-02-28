using StudentManagement.Shared.Domain;

namespace StudentManagement.App.Services
{
    public interface ICountryDataService
    {
        Task<IEnumerable<Country>> GetAllCountries();
        Task<Country> GetCountryById(int countryId);
        Task<Country> AddCountry(Country country);
        Task UpdateCountry(Country country);
        Task DeleteCountry(int countryId);
    }
}
