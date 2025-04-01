using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentskaWebAPI.Data;
using StudentskaWebAPI.DataTransfer;
using StudentskaWebAPI.Models;
using System.Threading.Tasks;

namespace StudentskaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IspitsController : Controller
    {
        private readonly StudentskaWebApiContext _context;
        private readonly ILogger<IspitsController> _logger;

        public IspitsController(StudentskaWebApiContext context, ILogger<IspitsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Ispits
        [HttpGet]
        public IActionResult GetIspits()
        {
            return Ok(_context.Ispits.ToList());
        }

        // GET: api/Ispits/5
        [HttpGet("{id}")]
        public IActionResult GetIspit(int id)
        {
            try
            {
                var ispit = _context.Ispits.Find(id);

                if (ispit == null)
                {
                    return NotFound();
                }
                return Ok(ispit);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching Ispit");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }


        // POST: api/Ispits
        [HttpPost]
        public IActionResult PostIspit(IspitDto dto)
        {
            try
            {
                var ispit = new Ispit
                {
                    IdRoka = dto.IdRoka,
                    IdPredmeta = dto.IdPredmeta,
                    Datum = dto.Datum
                };

                _context.Ispits.Add(ispit);
                _context.SaveChanges();

                return Ok(ispit);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating Ispit");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        // PUT: api/Ispits/5
        [HttpPut("{id}")]
        public IActionResult PutIspit(int id, IspitDto dto)
        {
            try
            {
                var ispit = _context.Ispits.Find(id);
                if (ispit == null)
                {
                    return NotFound();
                }
                else
                {
                    ispit.IdRoka = dto.IdRoka;
                    ispit.IdPredmeta = dto.IdPredmeta;
                    ispit.Datum = dto.Datum;

                    _context.SaveChanges();
                    return Ok(ispit);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while updating Ispit");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        // DELETE: api/Ispits/5
        [HttpDelete("{id}")]
        public IActionResult DeleteIspit(int id)
        {
            try
            {
                var ispit = _context.Ispits.Find(id);
                if (ispit == null)
                {
                    return NotFound();
                }
                else
                {
                    _context.Ispits.Remove(ispit);
                    _context.SaveChanges();
                    return Ok(ispit);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while deleting Ispit");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    }
}
