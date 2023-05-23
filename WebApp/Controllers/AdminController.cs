using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.Helpers.Services.User;
using WebApp.Models.Identity;

namespace WebApp.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
	{
        #region private fields & constructors 
        private readonly AuthService _authService;
        private readonly UserService _userService;
        private readonly UserManager<AppUser> _userManager;

        public AdminController(AuthService authService, UserService userService, UserManager<AppUser> userManager)
        {
            _authService = authService;
            _userService = userService;
            _userManager = userManager;
        }
        #endregion

        public IActionResult Index()
		{
            ViewData["Title"] = "Back Office";
            return View();
		}

        public async Task<IActionResult> AllUsers()
        {
            ViewData["Title"] = "All User";
            var users = await _userService.GetAllUsersAsync();
            return View(users);
        }

        [HttpPost]
        public async Task<IActionResult> Update(string userId, string newRole)
        {
            if (string.IsNullOrEmpty(userId))
            {
                ModelState.TryAddModelError("userId", "User not found");
                return View("AllUsers", await _userService.GetAllUsersAsync());
            }

            await _userService.UpdateUserRoleAsync(userId, newRole);
            return RedirectToAction("AllUsers", "Admin");
        }


        [HttpPost]
        public async Task<IActionResult> Delete(string Id)
        {
            if (await _userService.DeleteAsync(Id))
                return RedirectToAction("AllUsers", "Admin");

            ModelState.AddModelError("", "Something went wrong.");
            return View();
        }
    }
}
