using WebApp.Helpers.Repositories.User;
using WebApp.Models.Entities;
using WebApp.Models.Entities.User;
using WebApp.Models.Identity;

namespace WebApp.Helpers.Services.User
{
    public class AddressService
    {
        private readonly AddressRepo _addressRepo;
        private readonly UserAddressRepo _userAddressRepo;

        public AddressService(AddressRepo addressRepo, UserAddressRepo userAddressRepo)
        {
            _addressRepo = addressRepo;
            _userAddressRepo = userAddressRepo;
        }

        // ======================================= GET OR CREATE ================== //
        public async Task<AddressEntity> GetOrCreateAsync(AddressEntity addressEntity)
        {
            var entity = await _addressRepo.GetAsync(x =>
                x.StreetName == addressEntity.StreetName &&
                x.PostalCode == addressEntity.PostalCode &&
                x.City == addressEntity.City
            );

            entity ??= await _addressRepo.AddAsync(addressEntity);
            return entity!;
        }


        // ======================================= ADD ADDRESS ================== //
        public async Task AddAddressAsync(AppUser user, AddressEntity addressEntity)
        {
            await _userAddressRepo.AddAsync(new UserAddressEntity
            {
                UserId = user.Id,
                AddressId = addressEntity.Id,
            });
        }

    }
}
