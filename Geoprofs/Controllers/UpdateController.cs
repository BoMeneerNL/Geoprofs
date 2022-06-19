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
    }
}
