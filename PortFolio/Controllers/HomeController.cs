using Microsoft.AspNetCore.Mvc;
using PortFolio.Models;
using System.Diagnostics;

namespace PortFolio.Controllers
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
        public IActionResult LecturerDashboard()
        {
            // Optionally, you can use TempData to display personalized info
            var role = TempData["UserRole"];
            return View();
        }

        public IActionResult ManagerDashboard()
        {
            // Optionally, you can use TempData to display personalized info
            var role = TempData["UserRole"];
            return View();
        }

        public IActionResult HRManagerDashboard()
        {
            // Optionally, you can use TempData to display personalized info
            var role = TempData["UserRole"];
            return View();
        }

            public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
