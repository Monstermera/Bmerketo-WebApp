using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Contexts;
using WebApp.Helpers.Repositories.Product;
using WebApp.Helpers.Repositories.User;
using WebApp.Helpers.Services;
using WebApp.Helpers.Services.Contact;
using WebApp.Helpers.Services.Home;
using WebApp.Helpers.Services.Product;
using WebApp.Helpers.Services.User;
using WebApp.Models.Identity;
using static WebApp.Factories.CustomerClaims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Sql")));
builder.Services.AddDbContext<IdentityContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("IdentitySql")));

builder.Services.ConfigureApplicationCookie(x =>
{
    x.LoginPath = "/userLogin";
    x.LogoutPath = "/";
    x.AccessDeniedPath = "/accessDenied";
});

builder.Services.AddIdentity<AppUser, IdentityRole>(x =>
{
    x.SignIn.RequireConfirmedAccount = false;
    x.Password.RequiredLength = 8;
    x.User.RequireUniqueEmail = true;
})
    .AddEntityFrameworkStores<IdentityContext>()
    .AddClaimsPrincipalFactory<CustomClaimsPrincipalFactory>();


builder.Services.AddScoped<UserRepo>();
builder.Services.AddScoped<AddressRepo>();
builder.Services.AddScoped<UserAddressRepo>();

builder.Services.AddScoped<ProductRepo>();
builder.Services.AddScoped<TagRepo>();
builder.Services.AddScoped<ProductTagRepo>();

builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<TagService>();

builder.Services.AddScoped<SeedService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<AddressService>();
builder.Services.AddScoped<RoleService>();

builder.Services.AddScoped<ContactService>();

builder.Services.AddScoped<ShowcaseService>();
builder.Services.AddScoped<SaleService>();
builder.Services.AddScoped<ReviewService>();


var app = builder.Build();
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
