using Microsoft.AspNetCore.Identity;

namespace WebApp.Helpers.Services.User
{
    public class SeedService
    {
        #region private fields & constructors 
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedService(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        #endregion
        public async Task SeedRoles()
        {

            if (!await _roleManager.RoleExistsAsync("admin"))
                await _roleManager.CreateAsync(new IdentityRole("admin"));

            if (!await _roleManager.RoleExistsAsync("user"))
                await _roleManager.CreateAsync(new IdentityRole("user"));
        }

    }
}
