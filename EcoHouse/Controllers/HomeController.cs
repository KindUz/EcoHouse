using EcoHouse.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using EcoHouse.Logic.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace EcoHouse.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        //////////////private readonly IUserManager _UserManager;
        //public HomeController(ILogger<HomeController> logger /*, IUserManager UserManager*/)
        //{
        //    _logger = logger;
        //    //////////////_UserManager = UserManager;
        //}

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Basket()
        {
            return View();
        }
        public IActionResult Favorite()
        {
            return View();
        }
        public IActionResult Order()
        {
            return View();
        }
        //////////public IActionResult SignIn()
        //////////{
        //////////    return View();
        //////////}
        

        //public IActionResult SignUp()
        //{
        //    return View();
        //}

        ////////////public IActionResult Logout()
        ////////////{
        ////////////    HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        ////////////    return RedirectToAction("SignIn");
        ////////////}

        //////////////[HttpPost]
        //////////////public async Task<IActionResult> SignIn(string login, string pass)
        //////////////{
        //////////////    if (_UserManager.Search(login, pass))
        //////////////    {
        //////////////        await Authenticate(login);
        //////////////        //return RedirectToPage("/Home/Personal");
        //////////////        return RedirectToAction("Personal");
        //////////////    }
        //////////////    else 
        //////////////    {
        //////////////        return RedirectToAction("SignIn");
        //////////////    }
        //////////////}

        ////////////////[HttpPost]
        ////////////////public async Task<IActionResult> SignUp(int a)
        ////////////////{
        ////////////////    await Task.Delay(0);
        ////////////////    return RedirectToPage("/Home/SignIn");
        ////////////////}

        //////////////////////private async Task Authenticate(string Email)
        //////////////////////{ 
        //////////////////////    var claims = new List<Claim>
        //////////////////////    {
        //////////////////////        new Claim(ClaimsIdentity.DefaultNameClaimType, Email)
        //////////////////////    };
        //////////////////////    ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        //////////////////////    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        //////////////////////}


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}