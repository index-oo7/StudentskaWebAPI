using Humanizer;
using Microsoft.AspNetCore.Mvc;
using StudentskaWebAPI.Data;
using StudentskaWebAPI.DataTransfer;
using StudentskaWebAPI.Models;

namespace StudentskaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly StudentskaWebApiContext _context;
        private readonly ILogger<StudentsController> _logger;

        public StudentsController(StudentskaWebApiContext context, ILogger<StudentsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(_context.Students.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            try
            {
                var student = _context.Students.Find(id);
                if (student == null)
                {
                    return NotFound();
                }
                return Ok(student);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching Student");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult PostStudent(StudentDto dto)
        {
            try
            {
                var student = new Student
                {
                    Ime = dto.Ime,
                    Prezime = dto.Prezime,
                    Smer = dto.Smer,
                    Broj = dto.Broj,
                    GodinaUpisa = dto.GodinaUpisa
                };

                _context.Students.Add(student);
                _context.SaveChanges();

                return Ok(student);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while adding Student");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult PutStudent(int id, StudentDto dto)
        {
            try
            {
                var student = _context.Students.Find(id);
                if (student == null)
                {
                    return NotFound();
                }
                student.Ime = dto.Ime;
                student.Prezime = dto.Prezime;
                student.Smer = dto.Smer;
                student.Broj = dto.Broj;
                student.GodinaUpisa = dto.GodinaUpisa;

                _context.SaveChanges();
                return Ok(student);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while updating Student");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            try
            {
                var student = _context.Students.Find(id);
                if (student == null)
                {
                    return NotFound();
                }
                _context.Students.Remove(student);
                _context.SaveChanges();
                return Ok(student);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while deleting Student");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    }
}
