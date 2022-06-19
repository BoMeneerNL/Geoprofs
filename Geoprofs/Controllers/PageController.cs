using Geoprofs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Docs.Samples;
using Microsoft.Extensions.Logging;
using MySqlConnector;
using System;
using System.Diagnostics;

namespace Geoprofs.Controllers
{
    public class PageController : Controller
    {
        private readonly ILogger<PageController> _logger;

        public PageController(ILogger<PageController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index() => View();
        public IActionResult Privacy() => View();
        public IActionResult Register() => View();
        public IActionResult Login() => View();
        public IActionResult Verlofaanvragen() => View();
        public IActionResult Verlof() => View();

        public IActionResult Update(int id)
        {
            ViewData["id"] = id;


            return View();
        }
    }
}