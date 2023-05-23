using Microsoft.EntityFrameworkCore;
using WebApp.Models.Entities;
using WebApp.Models.Entities.Product;

namespace WebApp.Contexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) 
    { 
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TagEntity>().HasData(
          new { Id = 1, TagName = "New" },
          new { Id = 2, TagName = "Popular" },
          new { Id = 3, TagName = "Featured" }
       );

    }

    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<TagEntity> Tags { get; set; }
    public DbSet<ProductTagEntity> ProductTags { get; set; }

    public DbSet<ContactEntity> Contacts { get; set; }
}
