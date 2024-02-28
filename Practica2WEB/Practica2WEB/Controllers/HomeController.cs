using Microsoft.AspNetCore.Mvc;
using Practica2WEB.Models;
using System.Diagnostics;

namespace Practica2WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
