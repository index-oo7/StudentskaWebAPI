using Microsoft.AspNetCore.Mvc;
using StudentskaWebAPI.Data;
using StudentskaWebAPI.DataTransfer;
using StudentskaWebAPI.Models;

namespace StudentskaWebAPI.Controllers
{
    public class StudentPredmetsController : Controller
    {
        private readonly StudentskaWebApiContext _context;
        private readonly ILogger<StudentPredmetsController> _logger;

        public StudentPredmetsController(StudentskaWebApiContext context, ILogger<StudentPredmetsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetStudentPredmets()
        {
            return Ok(_context.StudentPredmets.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentPredmet(int id)
        {
            try
            {
                var studentPredmet = _context.StudentPredmets.Find(id);
                if (studentPredmet == null)
                {
                    return NotFound();
                }
                return Ok(studentPredmet);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching StudentPredmet");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult PostStudentPredmet(StudentPredmetDto dto)
        {
            try
            {
                var studentPredmet = new StudentPredmet
                {
                    IdStudenta = dto.IdStudenta,
                    IdPredmeta = dto.IdPredmeta,
                    SkolskaGodina = dto.SkolskaGodina
                };
                _context.StudentPredmets.Add(studentPredmet);
                _context.SaveChanges();
                return Ok(studentPredmet);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating StudentPredmet");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult PutStudentPredmet(int id, StudentPredmetDto dto)
        {
            try
            {
                var studentPredmet = _context.StudentPredmets.Find(id);
                if (studentPredmet == null)
                {
                    return NotFound();
                }

                studentPredmet.IdStudenta = dto.IdStudenta;
                studentPredmet.IdPredmeta = dto.IdPredmeta;
                studentPredmet.SkolskaGodina = dto.SkolskaGodina;

                _context.SaveChanges();
                return Ok(studentPredmet);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while updating StudentPredmet");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudentPredmet(int id)
        {
            try
            {
                var studentPredmet = _context.StudentPredmets.Find(id);
                if (studentPredmet == null)
                {
                    return NotFound();
                }
                _context.StudentPredmets.Remove(studentPredmet);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while deleting StudentPredmet");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    }
}
