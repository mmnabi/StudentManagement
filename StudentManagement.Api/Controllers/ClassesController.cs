using Microsoft.AspNetCore.Mvc;
using StudentManagement.Api.Data.Repositories;
using StudentManagement.Shared.Domain;

namespace StudentManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : Controller
    {
        private readonly IClassRepository _classRepository;

        public ClassesController(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult GetClasses()
        {
            return Ok(_classRepository.GetAllClasses());
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult GetClassById(int id)
        {
            return Ok(_classRepository.GetClassById(id));
        }

        [HttpPost]
        public IActionResult CreateClass([FromBody] Class @class)
        {
            if (@class == null)
                return BadRequest();

            if (@class.ClassName == string.Empty)
            {
                ModelState.AddModelError("Name", "The name shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdClass = _classRepository.AddClass(@class);

            return Created("countries", createdClass);
        }

        [HttpPut]
        public IActionResult UpdateClass([FromBody] Class @class)
        {
            if (@class == null)
                return BadRequest();

            if (@class.ClassName == string.Empty)
            {
                ModelState.AddModelError("Name", "The name shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var @classToUpdate = _classRepository.GetClassById(@class.Id);

            if (@classToUpdate == null)
                return NotFound();

            _classRepository.UpdateClass(@class);

            return NoContent(); //success
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClass(int id)
        {
            if (id == 0)
                return BadRequest();

            var @classToDelete = _classRepository.GetClassById(id);
            if (@classToDelete == null)
                return NotFound();

            _classRepository.DeleteClass(id);

            return NoContent();//success
        }
    }
}
