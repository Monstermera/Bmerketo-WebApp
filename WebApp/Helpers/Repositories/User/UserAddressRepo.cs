using WebApp.Contexts;
using WebApp.Models.Entities.User;

namespace WebApp.Helpers.Repositories.User
{
    public class UserAddressRepo : Repo<UserAddressEntity>
    {
        public UserAddressRepo(IdentityContext context) : base(context)
        {
        }
    }
}
