using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Helpers.Services.User;
using WebApp.ViewModels.AccountView;
using WebApp.ViewModels.AdminView;

namespace WebApp.Controllers
{
    [Authorize]
	public class AccountController : Controller
	{
        #region private fields & constructors
        private readonly AuthService _authService;
		private readonly UserService _userService;

        public AccountController(AuthService authService, UserService userService)
        {
            _authService = authService;
            _userService = userService;
        }
        #endregion


        public async Task<IActionResult> Index()
		{
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); 
            var model = await _userService.GetUserAsync(userId!);
            if (model != null)
            {
                return View(model); 
            }
            return NotFound("User information not found"); 
        }


		public async Task<IActionResult> Logout() 
		{
			if (await _authService.LogoutAsync(User))
				return LocalRedirect("/");

			return RedirectToAction("Index", "UserLogin");
		}
	}
}
