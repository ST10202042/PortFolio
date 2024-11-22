using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Portfolio.Middleware
{ 
public class RoleRedirectMiddleware
{
    private readonly RequestDelegate _next;

    public RoleRedirectMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        if (context.User.Identity.IsAuthenticated)
        {
            // Retrieve the user's role from claims
            var role = context.User.FindFirst("Role")?.Value;

            if (role != null)
            {
                // Determine the redirect path based on the role
                string redirectPath = role switch
                {
                    "Lecturer" => "/Dashboard/LecturerDashboard",
                    "Manager" => "/Dashboard/ManagerDashboard",
                    "HRManager" => "/Dashboard/HRManagerDashboard",
                    _ => "/Dashboard" // Default fallback
                };

                // Redirect the user to their dashboard
                context.Response.Redirect(redirectPath);
                return;
            }
        }

        // Proceed to the next middleware
        await _next(context);
    }
}
}