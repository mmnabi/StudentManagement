using StudentManagement.Shared.Domain;
using System.Diagnostics.Metrics;

namespace StudentManagement.Api.Data.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly AppDbContext _appDbContext;

        public CountryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Country> GetAllCountries()
        {
            return _appDbContext.Countries;
        }

        public Country GetCountryById(int countryId)
        {
            return _appDbContext.Countries.FirstOrDefault(c => c.Id == countryId);
        }



        public Country AddCountry(Country country)
        {
            var addedEntity = _appDbContext.Countries.Add(country);
            _appDbContext.SaveChanges();
            return addedEntity.Entity;
        }

        public Country UpdateCountry(Country country)
        {
            var foundCountry = GetCountryById(country.Id);

            if (foundCountry != null)
            {
                foundCountry.Name = country.Name;

                _appDbContext.SaveChanges();

                return foundCountry;
            }

            return null;
        }

        public void DeleteCountry(int countryId)
        {
            var foundCountry = GetCountryById(countryId);
            if (foundCountry == null) return;

            _appDbContext.Countries.Remove(foundCountry);
            _appDbContext.SaveChanges();
        }
    }
}
