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
            List<Verlof> verloven = _context.Verlof.ToList();
            verloven.ForEach(x => {
                if (x.MedewerkerId == id)
                {
                    _context.Verlof.Remove(x);
                }
            });
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
    }
}
