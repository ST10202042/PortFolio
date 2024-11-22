using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using PortFolio.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace PortFolio.Controllers
{
    public class ClaimController : Controller
    {
        // In-memory storage
        private static readonly List<Claim> claims = new List<Claim>();

        // Submit Claim GET

        public IActionResult Claim()
        {
            return View();
        }

        // Submit Claim POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Claim(Claim claim, List<Module> modules, IFormFile SupportingDocuments)
        {
            if (ModelState.IsValid)
            {
                if (SupportingDocuments != null)
                {
                    using (var ms = new MemoryStream())
                    {
                        SupportingDocuments.CopyTo(ms);
                        claim.SupportingDocuments = ms.ToArray();
                    }
                }

                claim.Modules = modules;
                claim.Status = "Pending";
                claim.DateOfClaim = DateTime.Now;

                // Add to in-memory storage
                claims.Add(claim);

                TempData["Success"] = "Claim submitted successfully!";
                return RedirectToAction(nameof(View));
            }

            return View(claim);
        }

        // View Claims
        public IActionResult View()
        {
            return View(claims);
        }

        // Claim Details
        public IActionResult Details(int id)
        {
            var claim = claims.FirstOrDefault(c => c.Id == id);
            if (claim == null)
            {
                return NotFound();
            }

            return View(claim);
        }

        // Manage Claims (for managers)
        public IActionResult Manage()
        {
            var pendingClaims = claims.Where(c => c.Status == "Pending").ToList();
            return View(pendingClaims);
        }


        [HttpPost]
        public IActionResult ApproveClaim(int id)
        {
            var claim = claims.FirstOrDefault(c => c.Id == id);
            if (claim != null)
            {
                claim.Status = "Approved";
            }

            return RedirectToAction(nameof(Manage));
        }

        [HttpPost]
        public IActionResult DeclineClaim(int id)
        {
            var claim = claims.FirstOrDefault(c => c.Id == id);
            if (claim != null)
            {
                claim.Status = "Declined";
            }

            return RedirectToAction(nameof(Manage));
        }

        // HR Page: Process Payment
        public IActionResult HRManagerDashboard()
        {
            var approvedClaims = claims.Where(c => c.Status == "Approved").ToList();
            return View(approvedClaims);
        }

        [HttpPost]
        public IActionResult MarkAsPaid(int id)
        {
            var claim = claims.FirstOrDefault(c => c.Id == id);
            if (claim != null)
            {
                claim.Status = "Paid";
            }

            return RedirectToAction(nameof(HRManagerDashboard));
        }
        // HR Page: Process Payment
        [HttpPost]
        public IActionResult ProcessPayment(int id)
        {
            var claim = claims.FirstOrDefault(c => c.Id == id);
            if (claim != null)
            {
                // Set the claim status to "Paid"
                claim.Status = "Paid";

                // Here you can add logic to handle actual payment processing (e.g., update payment records, integrate with payment gateway)
            }

            // Redirect to the HR Manager Dashboard after processing the payment
            return RedirectToAction(nameof(HRManagerDashboard));
        }
        // HR Page: Process Payment GET (for showing payment details)
        public IActionResult PaymentDetails(int id)
        {
            var claim = claims.FirstOrDefault(c => c.Id == id);
            if (claim == null)
            {
                return NotFound();
            }

            return View(claim);
        }

    }
}
