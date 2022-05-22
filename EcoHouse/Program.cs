using EcoHouse.Controllers;
using EcoHouse.Logic.Another_Address;
using EcoHouse.Logic.Categories;
using EcoHouse.Logic.Deliveries;
using EcoHouse.Logic.Food_features;
using EcoHouse.Logic.Main_Addresses;
using EcoHouse.Logic.Dishes;
using EcoHouse.Logic.Orders;
using EcoHouse.Logic.Structures;
using EcoHouse.Logic.Users;
using EcoHouse.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.
builder.Services.AddScoped<ICategoryManager, CategoryManager>();
builder.Services.AddScoped<IAnother_AdressManager, Another_AdressManager>();
builder.Services.AddScoped<IStructureManager, StructureManager>();
builder.Services.AddScoped<IOrderManager, OrderManager>();
builder.Services.AddScoped<IFood_featuresManager, Food_featuresManager>();
builder.Services.AddScoped<IDeliveryManager, DeliveryManager>();
builder.Services.AddScoped<IMain_AddressManager, Main_AddressManager>();
builder.Services.AddScoped<IDishManager, DishManager>();
//cookie
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
    options.SlidingExpiration = true;
    options.AccessDeniedPath = "/Forbidden/";
});
//


services.AddControllersWithViews();
services.AddScoped<IUserManager, UserManager>();
services.AddRazorPages();


// Add Database context.
var connectionString = builder.Configuration.GetConnectionString("DbConnection");
services.AddDbContext<UniversityContext>(param => param.UseSqlServer(connectionString));

var app = builder.Build();

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

//cookie
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapDefaultControllerRoute();
//
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dish}/{action=Menu}/{id?}");


app.Run();
