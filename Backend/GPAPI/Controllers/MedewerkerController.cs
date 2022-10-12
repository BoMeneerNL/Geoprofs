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
        public IEnumerable<Medewerker> Get() => _context.Medewerkers.ToList();
        
        [HttpGet("{id}")]
        public ActionResult<Medewerker> GetMedewerker(int id) => _context.Medewerkers.Find(id) == null ? NotFound() : _context.Medewerkers.Find(id);
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _context.Authtokens.RemoveRange(_context.Authtokens.Where(x => x.Medewerker.MedewerkerID == id));
            _context.SaveChanges();
            _context.Verlof.RemoveRange(_context.Verlof.Where(x => x.Medewerker.MedewerkerID == id));
            _context.SaveChanges();
            Medewerker medewerker = _context.Medewerkers.Find(id);
            _context.Medewerkers.Remove(medewerker);
            _context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public ActionResult Create(Medewerker medewerker)
        {
            _context.Medewerkers.Add(medewerker);
           _context.SaveChanges();
            return Ok();
        }
        //public ActionResult Login(Medewerker medewerker)
        //{
            
        //    return Ok();
        //}
    }
}
