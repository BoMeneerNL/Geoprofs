using GPAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
                .Select(x => new { x.Expires, x.MedewerkerId }).FirstOrDefault();
            if (res == null)
            {
                return Unauthorized();
            }
            else if (res.Expires <= (ulong)DateTimeOffset.Now.ToUnixTimeMilliseconds()) {
                return Unauthorized();
            }
            else
            {
                Medewerker userinfo = _context.Medewerkers.Find(res.MedewerkerId);
                var rslt = new { userinfo.MedewerkerType,userinfo.Team};
                return Ok(rslt);
            }

        }
        [HttpPost]
        public ActionResult LogMeIn()
        {
            Medewerker medewerker= _context.Medewerkers
                .Where(x => x.Naam == Request.Form["name"].ToString())
                .Where(x => x.Wachtwoord == Request.Form["password"].ToString())
                .FirstOrDefault();
            if (medewerker == null)
            {
                return Unauthorized();
            }
            Authtoken token = _context.Authtokens.Where(x => x.Medewerker == medewerker).FirstOrDefault();
            
            if (token != null && token.Expires > (ulong)DateTimeOffset.Now.ToUnixTimeMilliseconds())
                return Ok(token.Token);

            string authtoken = Guid.NewGuid().ToString();
            List<string> Authtokens = _context.Authtokens.Select(x => x.Token).ToList();
            while (Authtokens.Contains(authtoken))
            {
                authtoken = Guid.NewGuid().ToString();
            }
            Authtoken _temp = new()
            {
                Medewerker = medewerker,
                Token = authtoken,
                Expires = (ulong)DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() + 10800000
            };
            _context.Add(_temp);
            _context.SaveChanges();
            return Ok(authtoken);
        }
    }
}
