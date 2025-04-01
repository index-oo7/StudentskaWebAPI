using Microsoft.AspNetCore.Mvc;
using StudentskaWebAPI.Data;
using StudentskaWebAPI.DataTransfer;
using StudentskaWebAPI.Models;

namespace StudentskaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IspitniRoksController : Controller
    {
        private readonly StudentskaWebApiContext _context;
        private readonly ILogger<IspitniRoksController> _logger;

        public IspitniRoksController(StudentskaWebApiContext context, ILogger<IspitniRoksController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/IspitniRoks
        [HttpGet]
        public IActionResult GetIspitniRoks()
        {
            return Ok(_context.IspitniRoks.ToList());
        }

        // GET: api/IspitniRoks/5
        [HttpGet("{id}")]
        public IActionResult GetIspitniRok(int id)
        {
            try
            {
                var ispitniRok = _context.IspitniRoks.Find(id);

                if (ispitniRok == null)
                {
                    return NotFound();
                }

                return Ok(ispitniRok);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching IspitniRok");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        // POST: api/IspitniRoks
        [HttpPost]
        public IActionResult PostIspitniRok(IspitniRokDto dto)
        {
            try
            {
                var ispitniRok = new IspitniRok
                {
                    Naziv = dto.Naziv,
                    SkolskaGod = dto.SkolskaGod,
                    StatusRoka = dto.StatusRoka
                };

                _context.IspitniRoks.Add(ispitniRok);
                _context.SaveChanges();

                return Ok(ispitniRok);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating IspitniRok");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        // PUT: api/IspitniRoks/5
        [HttpPut("{id}")]
        public IActionResult PutIspitniRok(int id, IspitniRokDto dto)
        {
            try
            {
                var ispitniRok = _context.IspitniRoks.Find(id);
                if (ispitniRok == null)
                {
                    return NotFound();
                }
                else
                {
                    ispitniRok.Naziv = dto.Naziv;
                    ispitniRok.SkolskaGod = dto.SkolskaGod;
                    ispitniRok.StatusRoka = dto.StatusRoka;

                    _context.SaveChanges();
                    return Ok(ispitniRok);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while updating IspitniRok");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        // DELETE: api/IspitniRoks/5
        [HttpDelete("{id}")]
        public IActionResult DeleteIspitniRok(int id)
        {
            try
            {
                var ispitniRok = _context.IspitniRoks.Find(id);
                if (ispitniRok == null)
                {
                    return NotFound();
                }
                else
                {
                    _context.IspitniRoks.Remove(ispitniRok);
                    _context.SaveChanges();
                    return Ok(ispitniRok);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while deleting IspitniRok");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    }
}
