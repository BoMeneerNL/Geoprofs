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
    }
}
