using Microsoft.AspNetCore.Mvc;
using WebApp.Helpers.Services;
using WebApp.Helpers.Services.Contact;
using WebApp.ViewModels.ContactView;

namespace WebApp.Controllers
{
    public class ContactsController : Controller
    {
        #region private fields & constructors 
        private readonly ContactService _contactService;

        public ContactsController(ContactService contactService)
        {
            _contactService = contactService;
        }
        #endregion
        public IActionResult Index()
        {
            ViewData["Title"] = "Contact Us";
            return View();
        }

        [HttpPost]
		public async Task<IActionResult> Index(ContactFormViewModel model)
		{
            if (ModelState.IsValid)
            {
                await _contactService.RegisterAsync(model);
                return RedirectToAction("Index", "Contacts");
            }
            ModelState.AddModelError("", "Please fill in all the required fields");

            return View(model);
		}


	}
}
