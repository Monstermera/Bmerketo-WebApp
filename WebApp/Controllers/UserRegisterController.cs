using Microsoft.AspNetCore.Mvc;
using WebApp.Helpers.Services.User;
using WebApp.ViewModels.AccountView;
using WebApp.ViewModels.AdminView;

namespace WebApp.Controllers
{
    public class UserRegisterController : Controller
	{
        #region private fields & constructors 
        private readonly AuthService _authService;

        public UserRegisterController(AuthService authService)
        {
            _authService = authService;
        }
        #endregion

        public IActionResult Index()
		{
            ViewData["Title"] = "Register new account";
            return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(UserRegisterViewModel model)
		{
			if (ModelState.IsValid)
			{
				if (await _authService.UserExists(x => x.Email == model.Email))
					ModelState.AddModelError("", "User with the same Email already exists");

				if (await _authService.RegisterAsync(model))
					return RedirectToAction("Index", "UserLogin");

			}

			return View(model);
		}
    }
}
