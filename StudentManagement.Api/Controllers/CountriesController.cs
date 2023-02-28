using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Api.Data.Repositories;
using StudentManagement.Shared.Domain;

namespace StudentManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : Controller
    {
        private readonly ICountryRepository _countryRepository;

        public CountriesController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult GetCountries()
        {
            return Ok(_countryRepository.GetAllCountries());
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult GetCountryById(int id)
        {
            return Ok(_countryRepository.GetCountryById(id));
        }

        [HttpPost]
        public IActionResult CreateCountry([FromBody] Country country)
        {
            if (country == null)
                return BadRequest();

            if (country.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "The name shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdCountry = _countryRepository.AddCountry(country);

            return Created("countries", createdCountry);
        }

        [HttpPut]
        public IActionResult UpdateCountry([FromBody] Country country)
        {
            if (country == null)
                return BadRequest();

            if (country.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "The name shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var countryToUpdate = _countryRepository.GetCountryById(country.Id);

            if (countryToUpdate == null)
                return NotFound();

            _countryRepository.UpdateCountry(country);

            return NoContent(); //success
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCountry(int id)
        {
            if (id == 0)
                return BadRequest();

            var countryToDelete = _countryRepository.GetCountryById(id);
            if (countryToDelete == null)
                return NotFound();

            _countryRepository.DeleteCountry(id);

            return NoContent();//success
        }
    }
}
