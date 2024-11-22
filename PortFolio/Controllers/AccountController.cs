using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;

namespace PortFolio.Controllers
{
    public class AccountController : Controller
    {
        // Controllers/AccountController.cs
        public IActionResult Login()
        {
            return View();
        }
        // POST: /Account/Login (AJAX handler)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login([FromBody] UserLoginModel loginModel)
        {
            // Authenticate the user
            var user = AuthenticateUser(loginModel.Email, loginModel.Password);

            if (user == null)
            {
                // Invalid login attempt
                return BadRequest("Invalid login attempt.");
            }

            // Store the user's role in TempData or return it in the response
            TempData["UserRole"] = user.Role;

            // Return role as JSON for client-side redirection
            return Json(new { role = user.Role });
        }

        
        private User AuthenticateUser(string email, string password)
        {
           
            if (email == "test@domain.com" && password == "password") // Dummy check
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
    public class UserLoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

