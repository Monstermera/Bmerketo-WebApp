using WebApp.Contexts;
using WebApp.Models.Entities.Product;

namespace WebApp.Helpers.Repositories.Product
{
    public class ProductTagRepo : Repo<ProductTagEntity>
    {
        public ProductTagRepo(DataContext context) : base(context)
        {
        }
    }
}
