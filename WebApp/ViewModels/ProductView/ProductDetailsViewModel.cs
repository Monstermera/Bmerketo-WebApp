using WebApp.Models.Product;

namespace WebApp.ViewModels.ProductView
{
    public class ProductDetailsViewModel
    {
        public ProductModel Product { get; set; } = null!;
        public RelatedProductsViewModel RelatedProducts { get; set; } = null!;
    }
}
