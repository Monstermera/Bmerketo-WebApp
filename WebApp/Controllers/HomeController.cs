using Microsoft.AspNetCore.Mvc;
using WebApp.Helpers.Services.Product;
using WebApp.ViewModels;
using WebApp.ViewModels.HomeView;

namespace WebApp.Controllers;

public class HomeController : Controller
{

    #region private fields & constructors 
    private readonly ProductService _productService;

    public HomeController(ProductService productService)
    {
        _productService = productService;
    }
    #endregion 

    public IActionResult Index()
    {
        ViewData["Title"] = "Home";


        var model = new HomeIndexViewModel
        {

            BestCollection = new GridCollectionViewModel
            {
                Title = "Best Collection",
                Categories = new List<string> { "All", "Bags", "Dress", "Decoration", "Essentials", "Interior", "Laptop", "Mobile", "Beauty" },
            },

            TopSelling = new TopSellingViewModel
            {
                Title = "Top selling products in this week",
            },


        };

		return View(model);
	}
}
