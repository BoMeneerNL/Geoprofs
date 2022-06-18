using Geoprofs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Docs.Samples;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

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
            ViewData["id"] = int.Parse(findechat.Content.Split(' ', StringSplitOptions.RemoveEmptyEntries)[3]);

            return View();
        }
        public IActionResult Verlof(int id)
        {
            ContentResult findechat = (ContentResult)ControllerContext.MyDisplayRouteInfo(id);
            ViewData["id"] = int.Parse(findechat.Content.Split(' ', StringSplitOptions.RemoveEmptyEntries)[3]);

            return View();

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
