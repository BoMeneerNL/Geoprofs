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
        [HttpGet]
        public ActionResult GetVerlof()
        {
            //string Naam = "";
            //var res = _context.Verlof.Select(x => new {x.VerlofID, x.TeamID, x.MedewerkerID, x.RedenVerzoek, x.Status, x.Van, x.Tot, Naam }).ToArray();
            //for (int i = 0; i < res.Length; i++)
            //{
            //    string tmpnaam = _context.Medewerkers.Where(x => x.MedewerkerID == res[i].MedewerkerID).Select(x => x.Naam).FirstOrDefault();
            //    var tempobj = new { res[i].VerlofID, res[i].TeamID, res[i].MedewerkerID, res[i].RedenVerzoek, res[i].Status, res[i].Van, res[i].Tot, Naam = tmpnaam };
            //    res[i] = tempobj;
            //}

            //return Ok(res.ToList());

            var response = _context.Verlof.Include(x => x.Medewerker).Include(x => x.Team).Select(v => new
            {
                v.VerlofID,
                v.MedewerkerID,
                v.Medewerker.Naam,
                v.Van,
                v.Tot,
                v.Status,
                v.RedenVerzoek,
                v.TeamID,
                teamNaam = v.Team.Naam
            }).ToList();

            return Ok(response);
        }
        [HttpPut]
        public ActionResult CreateNewVerlof(Verlof verlof)
        {
            _context.Verlof.Add(verlof);
            _context.SaveChanges();
            return Ok();
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
            verlof.RedenVerzoek = reason;
            _context.Verlof.Update(verlof);
            _context.SaveChanges();
            return Ok();
        }
    }
}
