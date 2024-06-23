using BeautyCareStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BeautyCareStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<CustomUser> _userManager;
        private readonly SignInManager<CustomUser> _signInManager;

        public AccountController(UserManager<CustomUser> userManager, SignInManager<CustomUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [Route("admin")]
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

            if (user == null)
            {
                // Handle user not found
                ModelState.AddModelError(string.Empty, "User not found.");
                return View("Index");
            }


            var isPasswordValid = await _userManager.CheckPasswordAsync(user, password);

            if (isPasswordValid)
            {
                var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");

                if (isAdmin)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("AdminPanel", "Admin");
                }
                else
                {
                    // Handle non-admin user
                    ModelState.AddModelError(string.Empty, "You do not have administrator privileges.");
                    return View("Index");
                }
            }
            else
            {
                // Handle invalid password
                ModelState.AddModelError(string.Empty, "User not found.");
                return View("Index");
            }
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}