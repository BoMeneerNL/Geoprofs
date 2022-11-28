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
                .Select(x => new { x.Expires, x.MedewerkerID }).FirstOrDefault();
            if (res == null)
            {
                return Unauthorized();
            }
            else if (res.Expires <= (ulong)DateTimeOffset.Now.ToUnixTimeMilliseconds()) {
                return Unauthorized();
            }
            else
            {
                Medewerker userinfo = _context.Medewerkers.Find(res.MedewerkerID);
                var rslt = new { userinfo.MedewerkerID, userinfo.MedewerkerType, userinfo.TeamID };
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
            Authtoken token = _context.Authtokens.Where(x => x.MedewerkerID == medewerker.MedewerkerID).FirstOrDefault();
            
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
                MedewerkerID = medewerker.MedewerkerID,
                Token = authtoken,
                Expires = (ulong)DateTimeOffset.Now.AddHours(1).ToUnixTimeMilliseconds()
            };
            _context.Add(_temp);
            _context.SaveChanges();
            return Ok(authtoken);
        }
    }
}
