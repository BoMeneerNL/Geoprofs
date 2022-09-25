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
        public ActionResult CreateNewVerlof(Verlof verlof)
        {
            _context.Verlof.Add(verlof);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public ActionResult<List<VerlofSender>> GetAllVerlof() {
            var res = _context.Verlof.Include(x => x.Medewerker).Select(x => new { x.Medewerker.Naam, x.Van, x.Tot,x.Status }).ToList();
            return Ok(res);
        }
    }
}
