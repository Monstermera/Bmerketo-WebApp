using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Contexts;
using WebApp.Helpers.Repositories;
using WebApp.Models;
using WebApp.Models.Identity;

namespace WebApp.Helpers.Services
{
    public class RoleService
    {
        private readonly IdentityContext _identityContext;
        private readonly UserManager<AppUser> _userManager;

        public RoleService(IdentityContext identityContext, UserManager<AppUser> userManager)
        {
            _identityContext = identityContext;
            _userManager = userManager;
        }

        public async Task<IEnumerable<IdentityRole>> GetRolesAsync()
        {
            var roles = await _identityContext.Roles.ToListAsync();
            return roles!;
        }

        public async Task<IEnumerable<RoleModel>> GetAllUserAndRolesAsync()
        {

            var userRoles = new List<RoleModel>();
            var users = await _identityContext.Users.ToListAsync();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                foreach (var roleName in roles)
                {
                    userRoles.Add(new RoleModel
                    {
                        Id = user.Id,
                        RoleName = roleName
                    });
                }
            }

            return userRoles;
        }

    }
}
