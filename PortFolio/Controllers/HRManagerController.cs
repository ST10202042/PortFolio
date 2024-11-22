using Microsoft.AspNetCore.Mvc;

namespace PortFolio.Controllers
{
    public class HRManagerController : Controller
    {
        public IActionResult Dashboard()
        {
            return View(); // HRManagerDashboard view will be rendered
        }

        public IActionResult ManageClaims()
        {
            return View(); // ManageClaims view (where the HR Manager can approve/decline claims)
        }
    }
}
