using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class AccountController : Controller
    {
        // GET: /Account/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register( string email, string password, string role)
        {
            // Here, you would typically add logic to save the user to the database.
            // For now, we're just simulating user creation.

            // Simulate saving user (replace with actual logic)
            var newUser = new User
            {
               
                Email = email,
                Password = password,
                Role = role
            };

            // Redirect to the login page after successful registration
            return RedirectToAction("Login");
        }

        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string email, string password)
        {
            // Authenticate the user
            var user = AuthenticateUser(email, password);

            if (user == null)
            {
                // Invalid login attempt
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View();
            }

            // Store the user's role (you could also use Claims or Cookies for better security)
            TempData["UserRole"] = user.Role;

            // Redirect to the unified dashboard based on the user's role
            switch (user.Role)
            {
                case "Lecturer":
                    return RedirectToAction("LecturerDashboard", "Dashboard");
                case "Manager":
                    return RedirectToAction("ManagerDashboard", "Dashboard");
                case "HRManager":
                    return RedirectToAction("HRManagerDashboard", "Dashboard");
                default:
                    return RedirectToAction("Dashboard", "Home");
            }
        }

        // Sample method to simulate user authentication (replace with actual logic)
        private User AuthenticateUser(string email, string password)
        {
            // Simulate user data (replace with actual authentication logic)
            if (email == "email" && password == "password") // Dummy check
            {
                return new User
                {
                    Email = email,
                    Password = password,
                    Role = "Lecturer"  // This would be fetched from a real database or authentication system
                };
            }

            return null;
        }
    }
}
