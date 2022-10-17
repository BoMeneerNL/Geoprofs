using GPAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GPAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VerlofController : ControllerBase
    {
        private readonly DBContext _context;

        public VerlofController(DBContext context) => _context = context;
        [HttpPut]
        public ActionResult CreateNewVerlof(Verlof verlof)
        {
            _context.Verlof.Add(verlof);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public ActionResult GetAllVerlof() {
            
            var res = _context.Verlof.Include(x => x.Medewerker).Select(x => new { x.Medewerker.Naam, x.Van, x.Tot, x.Status,x.Medewerker.IsAdmin }).ToList();
            return Ok(res);
        }
        [HttpPost("/changestatus/{verlofid}/{newstatus}")]
        public ActionResult ChangeVerlofStatus(int verlofid,byte newstatus)
        {
            Verlof verlof = _context.Verlof.Find(verlofid);
            if (verlof == null) 
                return NotFound();
            if(newstatus is not 2 and not 3)
            {
                return BadRequest();
            }
            verlof.Status = newstatus switch
            {
                2 => 2,
                3 => 3,
                _=> 0
            };
            _context.Verlof.Update(verlof);
            _context.SaveChanges();
            return Ok();
        }
        [HttpPost("/addreason/{verlofid}/{reason}")]
        public ActionResult AddReason(int verlofid, string reason)
        {
            Verlof verlof = _context.Verlof.Find(verlofid);
            if (verlof == null)
                return NotFound();
            verlof.Reden = reason;
            _context.Verlof.Update(verlof);
            _context.SaveChanges();
            return Ok();
        }
    }
}
