using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Models.Product;

namespace WebApp.Models.Entities.Product
{
    public class ProductEntity
    {

        [Key]
        public string ArticleNumber { get; set; } = null!;
        public string Name { get; set; } = null!;

        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string ImageUrl { get; set; } = null!;
        public ICollection<ProductTagEntity> ProductTags { get; set; } = new HashSet<ProductTagEntity>();


        #region implicit operators 
        public static implicit operator ProductModel(ProductEntity entity)
        {

            return new ProductModel
            {
                ArticleNumber = entity.ArticleNumber,
                Name = entity.Name,
                Price = entity.Price,
                ImageUrl = entity.ImageUrl,
                Description = entity.Description,
            };

        }
        #endregion

    }
}
