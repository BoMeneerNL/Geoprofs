using GPAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GPAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly DBContext _context;

        public TeamController(DBContext context) => _context = context;
        [HttpGet("/Teams")]
        public ActionResult GetTeams()
        {
            return Ok(_context.Teams.ToList());
        }
        [HttpGet("{id}")]
        public ActionResult GetTeam(int id)
        {
            return Ok(_context.Teams.Find(id));
        }
        [HttpPost("/addteam/{naam}")]
        public ActionResult AddTeam(string naam)
        {
            Team team = new()
            {
                Naam = naam
            };
            _context.Teams.Add(team);
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult RemoveTeam(int id)
        {
            {
                Team team = _context.Teams.Find(id);
                if (team == null)
                    return NotFound();
                _context.Teams.Remove(team);
                _context.SaveChanges();
                return Ok();
            }
        }
        [HttpPatch]
        public ActionResult EditTeam()
        {
            Team team = _context.Teams.Find(ulong.Parse(Request.Form["id"]));
            if (team == null)
                return NotFound();
            team.Naam = Request.Form["name"].ToString();
            _context.SaveChanges();
            return Ok();
        }
    }
}
