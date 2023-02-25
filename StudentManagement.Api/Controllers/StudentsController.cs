using Microsoft.AspNetCore.Mvc;
using StudentManagement.Api.Data.Repositories;
using StudentManagement.Shared.Domain;

namespace StudentManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            return Ok(_studentRepository.GetAllStudents());
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            return Ok(_studentRepository.GetStudentById(id));
        }

        [HttpPost]
        public IActionResult CreateStudent([FromBody] Student student)
        {
            if (student == null)
                return BadRequest();

            if (student.Name == string.Empty)
            {
                ModelState.AddModelError("Name/", "The name shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdStudent = _studentRepository.AddStudent(student);

            return Created("student", createdStudent);
        }

        [HttpPut]
        public IActionResult UpdateStudent([FromBody] Student student)
        {
            if (student == null)
                return BadRequest();

            if (student.Name == string.Empty)
            {
                ModelState.AddModelError("Name/", "The name shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var studentToUpdate = _studentRepository.GetStudentById(student.Id);

            if (studentToUpdate == null)
                return NotFound();

            _studentRepository.UpdateStudent(student);

            return NoContent(); //success
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            if (id == 0)
                return BadRequest();

            var studentToDelete = _studentRepository.GetStudentById(id);
            if (studentToDelete == null)
                return NotFound();

            _studentRepository.DeleteStudent(id);

            return NoContent();//success
        }
    }
}
