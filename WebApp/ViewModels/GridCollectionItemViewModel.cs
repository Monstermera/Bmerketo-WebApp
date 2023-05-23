using WebApp.Models.Entities;
using WebApp.Models.Product;

namespace WebApp.ViewModels
{
    public class GridCollectionItemViewModel
    {
        public string ArticleNumber { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public string Title { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
