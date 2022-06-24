using Microsoft.AspNetCore.Mvc;

namespace Geoprofs.Controllers
{
    public class InsertController : Controller
    {
        public IActionResult User(int rankid, string personeelsnaam, string password)
        {
            ViewData["rankid"] = rankid;
            ViewData["personeelsnaam"] = personeelsnaam;
            ViewData["password"] = password;

            return View();
        }

        public IActionResult Verlof(int personeelid, string vanaf, string tot, string beschrijving)
        {
            ViewData["personeelid"] = personeelid;
            ViewData["vanaf"] = vanaf;
            ViewData["tot"] = tot;
            ViewData["beschrijving"] = beschrijving;
            
            return View();
        }
    }
}
