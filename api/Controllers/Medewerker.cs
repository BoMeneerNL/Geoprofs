using api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Medewerker:ControllerBase
    {
        private readonly DBContext _context;
        public Medewerker(DBContext context) => _context = context;
        [HttpPut]
        public async Task<ActionResult> UpdateStudentAsync(Medewerker Medewerker)
        {
            HttpContext.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST,PUT,DELETE,OPTIONS");
            HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            HttpContext.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Accept, Pragma, Cache-Control, Authtoken ");

            _context.Add(Medewerker);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMedewerker(int id)
        {
            HttpContext.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST,PUT,DELETE,OPTIONS");
            HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            HttpContext.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Accept, Pragma, Cache-Control, Authtoken ");
            Models.Medewerker medewerker = _context.Medewerkers.Find(id);
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
