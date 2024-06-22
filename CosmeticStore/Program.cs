using Microsoft.EntityFrameworkCore;
using BeautyCareStore.Models;
using Microsoft.AspNetCore.Identity;
using BeautyCareStore.Services;

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
builder.Services.AddIdentityCore<CustomUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<BeautyCareDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<IAdminUserService, AdminUserService>();

// Register ProductService
builder.Services.AddScoped<ProductService>();

var app = builder.Build();

// Seed admin user during application startup
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var adminUserService = services.GetRequiredService<IAdminUserService>();

    await adminUserService.SeedAdminUserAsync(); // Ensure admin user is seeded
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

app.Run();