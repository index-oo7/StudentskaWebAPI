using Microsoft.AspNetCore.Mvc;
using StudentskaWebAPI.Data;
using StudentskaWebAPI.DataTransfer;
using StudentskaWebAPI.Models;

namespace StudentskaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesorsController : Controller
    {
        private readonly StudentskaWebApiContext _context;
        private readonly ILogger<ProfesorsController> _logger;

        public ProfesorsController(StudentskaWebApiContext context, ILogger<ProfesorsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetProfesors()
        {
            return Ok(_context.Profesors.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetProfesor(int id)
        {
            try
            {
                var profesor = _context.Profesors.Find(id);
                if (profesor == null)
                {
                    return NotFound();
                }
                return Ok(profesor);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching Profesor");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult PostProfesor(ProfesorDto dto)
        {
            try
            {
                var profesor = new Profesor
                {
                    Ime = dto.Ime,
                    Prezime = dto.Prezime,
                    Zvanje = dto.Zvanje,
                    DatumZap = dto.DatumZap
                };
                _context.Profesors.Add(profesor);
                _context.SaveChanges();
                return Ok(profesor);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating Profesor");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult PutProfesor(int id, ProfesorDto dto)
        {
            try
            {
                var profesor = _context.Profesors.Find(id);
                if (profesor == null)
                {
                    return NotFound();
                }

                profesor.Ime = dto.Ime;
                profesor.Prezime = dto.Prezime;
                profesor.Zvanje = dto.Zvanje;
                profesor.DatumZap = dto.DatumZap;

                _context.SaveChanges();
                return Ok(profesor);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while updating Profesor");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProfesor(int id)
        {
            try
            {
                var profesor = _context.Profesors.Find(id);
                if (profesor == null)
                {
                    return NotFound();
                }
                _context.Profesors.Remove(profesor);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while deleting Profesor");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    }
}
