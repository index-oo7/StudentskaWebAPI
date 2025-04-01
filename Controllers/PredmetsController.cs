using Microsoft.AspNetCore.Mvc;
using StudentskaWebAPI.Data;
using StudentskaWebAPI.DataTransfer;
using StudentskaWebAPI.Models;

namespace StudentskaWebAPI.Controllers
{
    public class PredmetsController : Controller
    {
        private readonly StudentskaWebApiContext _context;
        private readonly ILogger<PredmetsController> _logger;

        public PredmetsController(StudentskaWebApiContext context, ILogger<PredmetsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Predmets
        [HttpGet]
        public IActionResult GetPredmets()
        {
            return Ok(_context.Predmets.ToList());
        }

        // GET: api/Predmets/5
        [HttpGet("{id}")]
        public IActionResult GetPredmet(int id)
        {
            try
            {
                var predmet = _context.Predmets.Find(id);

                if (predmet == null)
                {
                    return NotFound();
                }

                return Ok(predmet);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching Predmet");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        // POST: api/Predmets
        [HttpPost]
        public IActionResult PostPredmet(PredmetDto dto)
        {
            try
            {
                var predmet = new Predmet
                {
                    IdProfesora = dto.IdProfesora,
                    Naziv = dto.Naziv,
                    Espb = dto.Espb,
                    Status = dto.Status
                };

                _context.Predmets.Add(predmet);
                _context.SaveChanges();

                return Ok(predmet);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating Predmet");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        // PUT: api/Predmets/5
        [HttpPut("{id}")]
        public IActionResult PutPredmet(int id, PredmetDto dto)
        {
            try
            {
                var predmet = _context.Predmets.Find(id);
                if (predmet == null)
                {
                    return NotFound();
                }
                else
                {
                    predmet.IdProfesora = dto.IdProfesora;
                    predmet.Naziv = dto.Naziv;
                    predmet.Espb = dto.Espb;
                    predmet.Status = dto.Status;

                    _context.SaveChanges();
                    return Ok(predmet);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while updating Predmet");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        // DELETE: api/Predmets/5
        [HttpDelete("{id}")]
        public IActionResult DeletePredmet(int id)
        {
            try
            {
                var predmet = _context.Predmets.Find(id);
                if (predmet == null)
                {
                    return NotFound();
                }
                else
                {
                    _context.Predmets.Remove(predmet);
                    _context.SaveChanges();
                    return Ok(predmet);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while deleting Predmet");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    }
}
