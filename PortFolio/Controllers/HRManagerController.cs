using Microsoft.AspNetCore.Mvc;
using PortFolio.Models;

namespace PortFolio.Controllers
{
    public class HRManagerController : Controller
    {
        public IActionResult Dashboard()
        {
            return View(); // HRManagerDashboard view will be rendered
        }

        public IActionResult Manage()
        {
            return View(); // Manag eClaims view (where the HR Manager can approve/decline claims)
        }
        public IActionResult Payment()
        {
            var claims = new List<Claim>
    {
        new Claim
        {
            ClaimNumber = "C002",
            LecturerName = "Prof. Jane",
            Status = "Approved",
            Modules = new List<Module>
            {
                new Module { ModuleName = "Math", ClaimAmount = 500 },
                new Module { ModuleName = "Science", ClaimAmount = 700 }
            }
        }
    };

            return View(claims);
        }

    }
}
