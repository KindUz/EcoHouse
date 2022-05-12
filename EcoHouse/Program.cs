using EcoHouse.Controllers;
using EcoHouse.Logic.Another_Address;
using EcoHouse.Logic.Categories;
using EcoHouse.Logic.Structures;
using EcoHouse.Logic.Users;
using EcoHouse.Storage;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.
builder.Services.AddScoped<ICategoryManager, CategoryManager>();
builder.Services.AddScoped<IAnother_AdressManager, Another_AdressManager>();
builder.Services.AddScoped<IStructureManager, StructureManager>();


services.AddControllersWithViews();
services.AddScoped<IUserManager, UserManager>();


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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
