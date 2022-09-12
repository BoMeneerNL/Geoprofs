using api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MedewerkerController:ControllerBase
    {
        private readonly DBContext _context;
        [HttpOptions]
        public ActionResult A()
        {
            HttpContext.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST,PUT,DELETE,OPTIONS");
            HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            HttpContext.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Accept, Pragma, Cache-Control");
            return Ok();
        }
        public MedewerkerController(DBContext context) => _context = context;
        [HttpGet]
        public ActionResult<IEnumerable<Medewerker>> Get()
        {
            HttpContext.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST,PUT,DELETE,OPTIONS");
            HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            HttpContext.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Accept, Pragma, Cache-Control");
            return _context.Medewerkers.ToList();
        }
        [HttpGet("{id}")]
        public ActionResult<Medewerker> GetByID(int id)
        {
            HttpContext.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST,PUT,DELETE,OPTIONS");
            HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            HttpContext.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Accept, Pragma, Cache-Control");
            return _context.Medewerkers.Find(id);
        }
        [HttpPut]
        public async Task<ActionResult<Medewerker>> UpdateStudentAsync(Medewerker medewerker)
        {
            HttpContext.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST,PUT,DELETE,OPTIONS");
            HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            HttpContext.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Accept, Pragma, Cache-Control, Authtoken ");
            _context.Add(medewerker);
            await _context.SaveChangesAsync();
            return medewerker;
        }

        [HttpGet("delete/{id}")]
        public ActionResult DeleteMedewerker(int id)
        {
            HttpContext.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST,PUT,DELETE,OPTIONS");
            HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            HttpContext.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Accept, Pragma, Cache-Control, Authtoken ");
            Medewerker medewerker = _context.Medewerkers.Find(id);
            if(medewerker == null)
            {
                return NotFound();
            }
            _context.Remove(medewerker);
            _context.SaveChanges();
            return Ok();

        }
    }
}
