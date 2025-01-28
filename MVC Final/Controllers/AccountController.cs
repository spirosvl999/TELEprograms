using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Final.Models;
using MVC_Final.ViewModels;
using System.Security.Claims;

namespace MVC_Final.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly LabDBContext _context; // Declare _context

        public AccountController(SignInManager<User> signInManager,
                              UserManager<User> userManager,
                              LabDBContext context) // Inject DbContext here
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context; // Initialize _context
        }

        // Login GET action
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Login POST action
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Retrieve the user from the custom User table based on the Username
            var user = await _context.Users
                                      .FirstOrDefaultAsync(u => u.Username == model.Username);

            // If user is not found or password doesn't match (remember passwords are stored in plain text in your model)
            if (user == null || user.Password != model.Password)
            {
                // If login fails, add error to ModelState and return the login view
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(model);
            }

            // Use SignInManager's PasswordSignInAsync method to sign in the user
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home"); // Redirect to home page on successful login
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View(model);
        }

        // Logout action
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
