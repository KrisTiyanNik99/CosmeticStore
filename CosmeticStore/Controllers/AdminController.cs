using BeautyCareStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BeautyCareStore.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<CustomUser> _userManager;

        public AdminController(UserManager<CustomUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ValidatePrivileges(string username, string password)
        {
            if (string.IsNullOrEmpty(username))
            {
                //ModelState.AddModelError(string.Empty, "Username is required.");
                return View("Index");
            }

            if (string.IsNullOrEmpty(password))
            {
                //ModelState.AddModelError(string.Empty, "Password is required.");
                return View("Index");
            }

            var user = await _userManager.FindByNameAsync(username);

            if (user != null)
            {
                var isPasswordValid = await _userManager.CheckPasswordAsync(user, password);

                if (isPasswordValid)
                {
                    // Password is correct, proceed with admin panel actions
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    // Handle invalid password
                    //ModelState.AddModelError(string.Empty, "Invalid password.");
                    return View("Index");
                }
            }
            else
            {
                // Handle user not found
                ModelState.AddModelError(string.Empty, "User not found.");
                return View("Index");
            }
        }
    }
}