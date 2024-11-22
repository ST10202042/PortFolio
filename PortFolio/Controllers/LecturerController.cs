using Microsoft.AspNetCore.Mvc;
using PortFolio.Models;

namespace PortFolio.Controllers
{
    public class LecturerController : Controller
    {
        // GET: Lecturer/Claim
        // LecturerController.cs
        [HttpGet]
        public IActionResult Claim()
        {
            // Return the Claim view
            return View(new Claim());
        }


        // POST: Lecturer/Claim
        [HttpPost]
        public IActionResult Claim(Claim claim)
        {
            if (ModelState.IsValid)
            {
                // Handle the claim submission (save to in-memory data or database)
               
                return RedirectToAction("View");
            }
            return View(claim); // If validation fails, return to the form
        }

        // GET: Lecturer/ViewClaims
        public IActionResult View()
        {
            var claims = new List<Claim>
            {
                new Claim { ClaimNumber = "001", LecturerName = "John Doe", DateOfClaim = DateTime.Now, Status = "Pending" },
                new Claim { ClaimNumber = "002", LecturerName = "Jane Smith", DateOfClaim = DateTime.Now, Status = "Approved" }
            };
            return View(claims); // Returns the View Claims view
        }

        // GET: Lecturer/Details/5
        public IActionResult Details(int id)
        {
            var claim = new Claim { ClaimNumber = "001", LecturerName = "John Doe", DateOfClaim = DateTime.Now, Status = "Pending" };
            return View(claim); // Returns the details of a single claim
        }
    }
}
