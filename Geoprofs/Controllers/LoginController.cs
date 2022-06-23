using Microsoft.AspNetCore.Mvc;

namespace Geoprofs.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult User(string username,string password)
        {
            ViewData["username"] = username;
            ViewData["password"] = password;
            return View();
        }
    }
}
