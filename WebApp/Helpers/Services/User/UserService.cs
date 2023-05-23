using System.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Contexts;
using WebApp.Helpers.Repositories.User;
using WebApp.Models.Identity;
using WebApp.ViewModels.AdminView;

namespace WebApp.Helpers.Services.User
{
    public class UserService
    {
        #region constructors & private fields

        private readonly UserRepo _userRepo;
        private readonly RoleService _roleService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IdentityContext _context;

        public UserService(UserRepo userRepo, RoleService roleService, UserManager<AppUser> userManager, IdentityContext context)
        {
            _userRepo = userRepo;
            _roleService = roleService;
            _userManager = userManager;
            _context = context;
        }

        #endregion
        public async Task<AppUser> AddAsync(AppUser user)
        {
            return await _userRepo.AddAsync(user);
        }

        public async Task<AppUser> GetAsync(string userId)
        {
            return await _userRepo.GetAsync(x => x.Id == userId);
        }


        public async Task<UserInformationViewModel> GetUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var model = new UserInformationViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName!,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email!,
                    PhoneNumber = user.PhoneNumber ?? "Not found",
                    Company = user.Company ?? "Not found",
                };

                var addresses = await _context.AspNetUserAddresses.Where(x => x.UserId == user.Id).Select(x => x.Address).ToListAsync();
                model.Addresses = addresses.Select(a => new AddressViewModel
                {
                    StreetName = a.StreetName,
                    PostalCode = a.PostalCode,
                    City = a.City
                }).ToList();

                return model;
            }
            return null!;

           
        }

        public async Task<IEnumerable<AppUser>> GetAllAsync()
        {
            return await _userRepo.GetAllAsync();
        }


        public async Task<IEnumerable<UserInformationViewModel>> GetAllUsersAsync()
        {
            var profiles = new List<UserInformationViewModel>();
            var users = await _userRepo.GetAllAsync();

            foreach (var user in users)
            {
                var role = await _userManager.GetRolesAsync(user);
                var addresses = await _context.AspNetUserAddresses.Where(x => x.UserId == user.Id).Select(x => x.Address).ToListAsync();
                var userInformationViewModel = new UserInformationViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName!,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email!,
                    PhoneNumber = user.PhoneNumber ?? "No phone number was given",
                    Company = user.Company ?? "No company name was given",
                    ProfileImage = user.ImageUrl,
                    Role = string.Join(",", role),

                    Addresses = addresses.Select(a => new AddressViewModel
                    {
                        StreetName = a.StreetName,
                        PostalCode = a.PostalCode,
                        City = a.City
                    }).ToList()
                };
                profiles.Add(userInformationViewModel);
            }
            return profiles;
        }

        public async Task<bool> UpdateUserRoleAsync(string userId, string newRole)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user != null)
            {
                var currentRoles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, currentRoles);
                await _userManager.AddToRoleAsync(user, newRole);
                await _userManager.UpdateAsync(user);
                return true;
            }
            return false;
        }


        public async Task<bool> DeleteAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);
                return result.Succeeded;
            }
            return false;
        }



    }
}

