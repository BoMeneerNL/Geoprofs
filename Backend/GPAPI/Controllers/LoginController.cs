using api.Models;
using GPAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace GPAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly DBContext _context;

        public LoginController(DBContext context) => _context = context;
        [HttpGet("{authtoken}")]
        public ActionResult Returnlogin(string authtoken)
        {
            var res = _context.Authtokens
                .Where(x => x.Token == authtoken)
                .Select(x=> new {x.Expires,x.Medewerker.IsAdmin})
                ;
            if (!res.Any())
            {
                return NotFound();
            }
            else if (res.Select(x => x.Expires).First() <= (ulong)DateTimeOffset.Now.ToUnixTimeMilliseconds()) {
                return Unauthorized();
            }
            else
            {
                return Ok(res.Select(x=>x.IsAdmin).First());
            }
           
        }
    }
}
