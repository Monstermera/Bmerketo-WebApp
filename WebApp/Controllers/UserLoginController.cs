using Microsoft.AspNetCore.Mvc;
using WebApp.Helpers.Services.User;
using WebApp.ViewModels.AccountView;

namespace WebApp.Controllers
{
    public class UserLoginController : Controller
	{
        #region private fields & constructors 
        private readonly AuthService _authService;

        public UserLoginController(AuthService authService)
        {
            _authService = authService;
        }
        #endregion


        public IActionResult Index()
		{
            ViewData["Title"] = "Log in";
            return View();
		}

		[HttpPost]
        public async Task<IActionResult> Index(UserLoginViewModel model)
        {
			if (ModelState.IsValid)
			{
				if (await _authService.LoginAsync(model))
					return RedirectToAction("Index", "Account");

				ModelState.AddModelError("", "Incorrect email or password");
			}

			return View(model);
		}
    }
}
