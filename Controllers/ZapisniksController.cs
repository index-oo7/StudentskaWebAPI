using Microsoft.AspNetCore.Mvc;
using StudentskaWebAPI.Data;
using StudentskaWebAPI.DataTransfer;
using StudentskaWebAPI.Models;

namespace StudentskaWebAPI.Controllers
{
    public class ZapisniksController : Controller
    {
        private StudentskaWebApiContext _context;
        private ILogger<ZapisniksController> _logger;

        public ZapisniksController(StudentskaWebApiContext context, ILogger<ZapisniksController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetZapisniks()
        {
            return Ok(_context.Zapisniks.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetZapisnik(int id)
        {
            try
            {
                var zapisnik = _context.Zapisniks.Find(id);
                if (zapisnik == null)
                {
                    return NotFound();
                }
                return Ok(zapisnik);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching Zapisnik");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult PostZapisnik(ZapisnikDto dto)
        {
            try
            {
                var zapisnik = new Zapisnik
                {
                    IdIspita = dto.IdIspita,
                    IdStudenta = dto.IdStudenta,
                    Ocena = dto.Ocena,
                    Bodovi = dto.Bodovi
                };

                _context.Zapisniks.Add(zapisnik);
                _context.SaveChanges();
                return Ok(zapisnik);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating Zapisnik");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult PutZapisnik(int id, ZapisnikDto dto)
        {
            try
            {
                var zapisnik = _context.Zapisniks.Find(id);
                if (zapisnik == null)
                {
                    return NotFound();
                }

                zapisnik.IdIspita = dto.IdIspita;
                zapisnik.IdStudenta = dto.IdStudenta;
                zapisnik.Ocena = dto.Ocena;
                zapisnik.Bodovi = dto.Bodovi;

                _context.SaveChanges();
                return Ok(zapisnik);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while updating Zapisnik");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteZapisnik(int id)
        {
            try
            {
                var zapisnik = _context.Zapisniks.Find(id);
                if (zapisnik == null)
                {
                    return NotFound();
                }
                _context.Zapisniks.Remove(zapisnik);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while deleting Zapisnik");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    }
}
