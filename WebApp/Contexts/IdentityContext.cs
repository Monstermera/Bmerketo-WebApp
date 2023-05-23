using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.Entities.User;
using WebApp.Models.Identity;

namespace WebApp.Contexts;

public class IdentityContext : IdentityDbContext<AppUser>
{
	public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
	{
	}

    public DbSet<AddressEntity> AspNetAddresses { get; set; }
    public DbSet<UserAddressEntity> AspNetUserAddresses { get; set; }
}
