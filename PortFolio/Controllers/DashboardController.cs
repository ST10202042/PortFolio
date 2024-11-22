using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers
{ 
public class DashboardController : Controller
{
    public IActionResult LecturerDashboard()
    {
        return View();
    }

    public IActionResult ManagerDashboard()
    {
        return View();
    }

    public IActionResult HRManagerDashboard()
    {
        return View();
    }

    public IActionResult Dashboard()
    {
        return View();
    }
}
}