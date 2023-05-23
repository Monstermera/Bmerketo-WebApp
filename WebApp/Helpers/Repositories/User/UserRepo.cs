using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApp.Contexts;
using WebApp.Models;
using WebApp.Models.Entities;
using WebApp.Models.Identity;

namespace WebApp.Helpers.Repositories.User
{
    public class UserRepo : Repo<AppUser>
    {
        public UserRepo(IdentityContext context) : base(context)
        {
        }

    }
}
