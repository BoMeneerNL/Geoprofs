using Microsoft.AspNetCore.Mvc;

namespace Geoprofs.Controllers
{
    public class UpdateController : Controller
    {
        public IActionResult User(int personeelid, int rankid, string personeelsnaam, string password)
        {
            ViewData["personeelid"] = personeelid;
            ViewData["rankid"] = rankid;
            ViewData["personeelsnaam"] = personeelsnaam;
            ViewData["password"] = password;

            return View();
        }

        public IActionResult VerlofStatusChange(int id, int status)
        {
            ViewData["id"] = id;
            ViewData["status"] = status;

            return View();

        }
    }
}
