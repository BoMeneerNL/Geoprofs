using Geoprofs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Docs.Samples;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Geoprofs.Controllers
{
    public class DeleteController : Controller
    {
        private readonly ILogger<DeleteController> _logger;

        public DeleteController(ILogger<DeleteController> logger)
        {
            _logger = logger;
        }

        public IActionResult User(int id)
        {
            ContentResult findechat = (ContentResult)ControllerContext.MyDisplayRouteInfo(id);
            ViewData["id"] = long.Parse(findechat.Content.Split(' ', StringSplitOptions.RemoveEmptyEntries)[3]);

            return View();

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
