using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Contexts;
using WebApp.Helpers.Services.Product;
using WebApp.ViewModels;
using WebApp.ViewModels.ProductView;

namespace WebApp.Controllers
{
    public class ProductsController : Controller
    {

        #region constructors & private fields
        private readonly ProductService _productService;
        private readonly TagService _tagService;
        private readonly DataContext _context;

        public ProductsController(ProductService productService, TagService tagService, DataContext context)
        {
            _productService = productService;
            _tagService = tagService;
            _context = context;
        }

        #endregion

        public IActionResult Index()
        {
            ViewData["Title"] = "Products";

            var model = new ProductsIndexViewModel
            {

                All = new GridCollectionViewModel
                {
                    Title = "All Products",
                    Categories = new List<string> { "All", "Bags", "Dress", "Decoration", "Essentials", "Interior", "Laptop", "Mobile", "Beauty" },
                }
            };

           
            return View(model);
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Register()
        {
            ViewData["Title"] = "Add Products";
            ViewBag.Tags = await _tagService.GetTagsAsync();
            return View();
        }


        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> Register(ProductRegisterViewModel model, string[] tags)
        {
            if (ModelState.IsValid)
            {
                var product = await _productService.CreateAsync(model);
                if (product != null)
                {
                    if(model.ImageUrl != null)
                    {
                        await _productService.UploadImageAsync(product, model.ImageUrl);
                    }
                    await _productService.AddTagsAsync(model, tags);
                    return RedirectToAction("Index", "Products");
                }

                ModelState.AddModelError("", "A product with the same article number already exists.");
            }
            ViewBag.Tags = await _tagService.GetTagsAsync(tags);
            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> Delete(string ArticleNumber)
        {
            if (await _productService.DeleteAsync(ArticleNumber))
                return RedirectToAction("Index", "Products");

            ModelState.AddModelError("", "Something went wrong.");
            return View();
        }


        public async Task<IActionResult> ProductDetails(string ArticleNumber)
        {
            ViewData["Title"] = "Details";

            var product = await _productService.GetAsync(ArticleNumber);
            var viewModel = new ProductDetailsViewModel
            {
                Product = product,
            };
            return View(viewModel);
        }
    }
}
