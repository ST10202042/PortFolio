using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers
{
    public class ManagerController : Controller
    {
        // Dashboard for Manager
        public IActionResult Dashboard()
        {
            return View();  // This will display the Manager dashboard view
        }
    }
}