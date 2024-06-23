using Microsoft.EntityFrameworkCore;
using BeautyCareStore.Models;
using Microsoft.AspNetCore.Identity;
using BeautyCareStore.Services;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add configuration
var configuration = builder.Configuration;

// Configure DbContext
builder.Services.AddDbContext<BeautyCareDbContext>(options =>
    options.UseMySql(configuration.GetConnectionString("DefaultConnection"),
                     new MySqlServerVersion(new Version(8, 0, 21))));


//Add Identity
builder.Services.AddIdentity<CustomUser, IdentityRole>(options =>
{
    // Configure password options here
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<BeautyCareDbContext>()
    .AddSignInManager<SignInManager<CustomUser>>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
.AddCookie(options =>
{
    options.LoginPath = "/Account/Index"; // Path to the login page
    options.AccessDeniedPath = "/Account/AccessDenied"; // Path to the access denied page
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    options.SlidingExpiration = true;
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
});

builder.Services.AddScoped<IAdminUserService, AdminUserService>();

// Register ProductService
builder.Services.AddScoped<ProductService>();

var app = builder.Build();

// Seed admin user during application startup
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var adminUserService = services.GetRequiredService<IAdminUserService>();

    await adminUserService.SeedAdminUserAsync();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "admin",
    pattern: "admin/{action=Index}/{id?}",
    defaults: new { controller = "Account" });

app.Run();