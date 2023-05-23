using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security.Claims;
using WebApp.Contexts;
using WebApp.Models.Identity;
using WebApp.ViewModels.AccountView;

namespace WebApp.Helpers.Services.User
{
    public class AuthService
    {
       #region private fields & constructors 
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IdentityContext _identityContext;
        private readonly SeedService _seedService;
        private readonly AddressService _addressService;

        public AuthService(UserManager<AppUser> userManager, IdentityContext identityContext, SignInManager<AppUser> signInManager, SeedService seedService, AddressService addressService)
        {
            _userManager = userManager;
            _identityContext = identityContext;
            _signInManager = signInManager;
            _seedService = seedService;
            _addressService = addressService;
        }
        #endregion

        // ================================================ CHECK IF USER EXIST ========================================== //
        public async Task<bool> UserExists(Expression<Func<IdentityUser, bool>> expression)
        {
            return await _userManager.Users.AnyAsync(expression);
        }


        // =========================================================== USER ADDS ACCOUNT ============================================= //
        public async Task<bool> RegisterAsync(UserRegisterViewModel model)
        {
            try
            {
                await _seedService.SeedRoles();
                var roleName = "user";

                if (!await _userManager.Users.AnyAsync())
                    roleName = "admin";

                AppUser appUser = model;
                var result = await _userManager.CreateAsync(appUser, model.Password);

                await _userManager.AddToRoleAsync(appUser, roleName);

                if (result.Succeeded)
                {
                    var addressEntity = await _addressService.GetOrCreateAsync(model);
                    if (addressEntity != null)
                    {
                        await _addressService.AddAddressAsync(appUser, addressEntity);
                        return true;
                    }
                }
                return false;
            }
            catch { return false; }
        }

        // =============================================================== LOG IN ============================================= //

        public async Task<bool> LoginAsync(UserLoginViewModel model)
        {
            var appUser = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == model.Email);
            if (appUser != null)
            {
                var result = await _signInManager.PasswordSignInAsync(appUser, model.Password, model.RememberMe, false);
                return result.Succeeded;

            }
            return false;
        }


        // =============================================================== LOG OUT ============================================= //
        public async Task<bool> LogoutAsync(ClaimsPrincipal user)
        {
            await _signInManager.SignOutAsync();
            return _signInManager.IsSignedIn(user);
        }
    }
}
