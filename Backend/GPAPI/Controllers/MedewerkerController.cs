using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using api.Models;
using System.Threading.Tasks;
using GPAPI.Models;

namespace GPAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MedewerkerController : ControllerBase
    {
        private readonly DBContext _context;

        public MedewerkerController(DBContext context) => _context = context;
        [HttpGet]
        public IEnumerable<Models.Medewerker> Get()
        {
            HttpContext.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST,PUT,DELETE,OPTIONS");
            HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            HttpContext.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Accept, Pragma, Cache-Control, Authtoken ");
            return _context.Medewerkers.ToList();

        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            HttpContext.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST,PUT,DELETE,OPTIONS");
            HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            HttpContext.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Accept, Pragma, Cache-Control, Authtoken ");
            var medewerker = _context.Medewerkers.Find(id);
            _context.Medewerkers.Remove(medewerker);
            _context.SaveChanges();
        }
        [HttpPut]
        public ActionResult Create(Medewerker medewerker)
        {
                HttpContext.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST,PUT,DELETE,OPTIONS");
                HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                HttpContext.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Accept, Pragma, Cache-Control, Authtoken ");

            _context.Medewerkers.Add(medewerker);
           _context.SaveChanges();
            return Ok();
        }
    }
}
