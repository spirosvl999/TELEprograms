using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Final.Data;
using MVC_Final.Models;
using MVC_Final.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;


namespace MVC_Final.Controllers
{
    public class AccountController : Controller
    {
        private readonly LabDBContext _context; // Declare _context
        

        // Inject your AppDbContext directly
        public AccountController(LabDBContext context)
        {
            _context = context;
        }

        // Login GET action
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Login POST action to authenticate the user
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Search for the user in the database by username
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == model.Username);

            // If user is found and passwords match (NOTE: In production, always hash passwords!)
            if (user != null && user.Password == model.Password)
            {
                // Log the user in (simple example, not secure for production!)
                // For production, consider using cookies or JWT for authentication
                HttpContext.Session.SetInt32("UserId", user.UserId);  // Store user ID in session

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View(model);
        }

        // Logout action to clear the session
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();  // Clear the session
            return RedirectToAction("Index", "Home");
        }
    }
}
