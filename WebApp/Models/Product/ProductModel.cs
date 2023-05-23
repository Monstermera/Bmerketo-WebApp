using Azure;
using WebApp.Models.Entities;

namespace WebApp.Models.Product
{
	public class ProductModel
	{
        public string ArticleNumber { get; set; } = null!;
        public string Name { get; set; } = null!;

        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = null!;
        public string? Description { get; set; }
        public IEnumerable<TagModel> Tags { get; set; } = new List<TagModel>();

    }
}
