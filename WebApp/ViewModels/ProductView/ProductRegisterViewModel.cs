using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Migrations.Identity;
using WebApp.Models.Entities.Product;
using WebApp.Models.Product;

namespace WebApp.ViewModels.ProductView
{
    public class ProductRegisterViewModel
    {
        [Required(ErrorMessage = "You must enter article number")]
        [RegularExpression(@"^(?!\s)[a-zA-Z0-9\-/_]*$", ErrorMessage = "Please enter a valid article number (ASA-5000).")]
        [Display(Name = "Article Number*")]
        public string ArticleNumber { get; set; } = null!;

        [Required(ErrorMessage = "You must enter a product name")]
        [Display(Name = "Product Name*")]
        public string Name { get; set; } = null!;


        [Required(ErrorMessage = "You must enter a price")]
        [Display(Name = "Product Price*")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }


        [Required(ErrorMessage = "You must enter a product image")]
        [Display(Name = "Image URL*")]
        [DataType(DataType.Upload)]
        public IFormFile ImageUrl { get; set; } = null!;


        [Display(Name = "Description")]
        public string? Description { get; set; } = null!;



        #region implicit operators

        public static implicit operator ProductEntity(ProductRegisterViewModel model)
        {
            var entity = new ProductEntity
            {
                ArticleNumber = model.ArticleNumber,
                Name = model.Name,
                Price = model.Price,
                Description = model?.Description,

            };

            if (model.ImageUrl != null)
            {
                entity.ImageUrl = $"{model.ArticleNumber}_{model.ImageUrl?.FileName}";
            }


            return entity;
        }


        #endregion
    }

}
