using api.Models;
using GPAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GPAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VerlofController:ControllerBase
    {
        private readonly DBContext _context;

        public VerlofController(DBContext context) => _context = context;
        [HttpPut]
        public ActionResult createNewVerlof(Verlof verlof)
        {
            //HttpContext.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST,PUT,DELETE,OPTIONS");
            //HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            //HttpContext.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Accept, Pragma, Cache-Control, Authtoken ");

            _context.Verlof.Add(verlof);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public ActionResult<List<VerlofSender>> getAllVerlof() {
            HttpContext.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST,PUT,DELETE,OPTIONS");
            HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            HttpContext.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Accept, Pragma, Cache-Control, Authtoken ");
            //List<Verlof> verloven = _context.Verlof.ToList();
            //List<VerlofSender> verlofnaam = new();
            //verloven.ForEach(x => {
            //    verlofnaam.Add(new(_context.Medewerkers.Find(x.MedewerkerID).Naam, x.Van, x.Tot));
            //});
            var res = _context.Verlof.Include(x => x.Medewerker).Select(x => new { Naam = x.Medewerker.Naam, Van = x.Van, Tot = x.Tot }).ToList();
            //return verlofnaam;
            return Ok(res);
        }
    }
}
