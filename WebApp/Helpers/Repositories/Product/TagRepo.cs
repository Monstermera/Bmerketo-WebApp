using WebApp.Contexts;
using WebApp.Models.Entities.Product;

namespace WebApp.Helpers.Repositories.Product
{
    public class TagRepo : Repo<TagEntity>
    {
        public TagRepo(DataContext context) : base(context)
        {
        }
    }
}
