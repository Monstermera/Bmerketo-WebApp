using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApp.Contexts;
using WebApp.Models.Entities.Product;

namespace WebApp.Helpers.Repositories.Product
{
    public class ProductRepo : Repo<ProductEntity>
    {
     
        public ProductRepo(DataContext context) : base(context)
        {
        }
    }
}
