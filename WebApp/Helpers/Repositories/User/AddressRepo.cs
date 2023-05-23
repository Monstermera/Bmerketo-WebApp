using WebApp.Contexts;
using WebApp.Models.Entities.User;

namespace WebApp.Helpers.Repositories.User
{
    public class AddressRepo : Repo<AddressEntity>
    {
        public AddressRepo(IdentityContext context) : base(context)
        {
        }
    }
}
