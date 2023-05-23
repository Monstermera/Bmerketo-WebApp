using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using WebApp.Helpers.Services.User;
using WebApp.Models.Identity;

namespace WebApp.Factories
{
	public class CustomerClaims
	{
		public class CustomClaimsPrincipalFactory : UserClaimsPrincipalFactory<AppUser>
		{
            #region private fields & constructors 
            private readonly UserService _userService;

            public CustomClaimsPrincipalFactory(UserManager<AppUser> userManager, IOptions<IdentityOptions> optionsAccessor, UserService userService) : base(userManager, optionsAccessor)
            {
                _userService = userService;
            }
            #endregion

            protected override async Task<ClaimsIdentity> GenerateClaimsAsync(AppUser user)
			{
				var claimsIdentity = await base.GenerateClaimsAsync(user);

				var userProfileEntity = await _userService.GetAsync(user.Id);
				claimsIdentity.AddClaim(new Claim("DisplayName", $"{userProfileEntity.FirstName} {userProfileEntity.LastName}"));

				var roles = await UserManager.GetRolesAsync(user);
				claimsIdentity.AddClaims(roles.Select(x => new Claim(ClaimTypes.Role, x)));

				return claimsIdentity;
			}
		}
	}
}
