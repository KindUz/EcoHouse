using EcoHouse.Logic.Users;
using EcoHouse.Models;
using EcoHouse.Storage.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using EcoHouse.Logic.Orders;
using EcoHouse.Logic.Dishes;
using EcoHouse.Logic.Main_Addresses;

namespace EcoHouse.Controllers;
public class UsersController : Controller
{
    private static IMain_AddressManager _managerAddress;
    private IWebHostEnvironment _env;
    private static IDishManager _managerDish;
    private static IUserManager _managerUser;
    private static IOrderManager _managerOrder;
    private readonly ILogger _logger;
    static internal User CurrentUser;
    static private User _user;
    static private bool _isUser = true;

    public UsersController(IUserManager managerUser, IOrderManager managerOrder, ILogger<AccountController> logger, IDishManager managerDish, IWebHostEnvironment? env, IMain_AddressManager managerAddress)
    {
        _managerAddress = managerAddress;
        _env = env;
        _managerUser = managerUser;
        _managerOrder = managerOrder;
        _logger = logger;
        _managerDish = managerDish;
    }

    #region Auth

    public async Task<IActionResult> SignUp()
    {
        var user = await _managerUser.GetAll();
        if (_user == null)
        {
            ViewBag.Orders = await _managerOrder.GetAll();
            return View(user);
        } else
        {
            return RedirectToAction("Personal");
        }
    }
    public async Task<IActionResult> SignIn()
    {
        if (_isUser)
        {
            ViewBag.isUser = "true";
        } else
        {
            ViewBag.isUser = "false";
        }
        if (_user == null)
        {
            ViewBag.Orders = await _managerOrder.GetAll();
            return View();
        }
        else
        {
            return RedirectToAction("Personal");
        }
    }
    public async Task<IActionResult> Personal()
    {
        ViewBag.User = _user;
        if (ViewBag.User == null)
        {
            return RedirectToAction("SignIn");
        } else
        {
            ViewBag.Orders = await _managerOrder.GetAll();
            ViewBag.Address = await _managerAddress.GetAll();
            return View();
        }
    }

    public IActionResult Logout()
    {
        HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        _managerOrder.Delete(CurrentUser.Id);
        CurrentUser = null;
        _user = null;
        _isUser = true;

        return RedirectToAction("SignIn");
    }


    [HttpPost]
    public async Task<IActionResult> SignIn(string login, string pass)
    {
        if ((CurrentUser = _managerUser.CheckPassAndLog(login, pass)) != null)
        {
            await Authenticate(login);

            var dishes = await _managerDish.GetAll();
            foreach (var dish in dishes)
            {
                dish.count = null;
                dish.OrdersID = null;
            }

            _user = CurrentUser;
            _isUser = true;
            await _managerOrder.CHTOBI_NE_BILO_TIMEOUTA();
            await _managerOrder.CreateByUser(CurrentUser.Id);

            //return RedirectToPage("/Home/Personal");
            return RedirectToAction("Personal");
        }
        else
        {
            _isUser = false;
            return RedirectToAction("SignIn");
        }
    }


    private async Task Authenticate(string Email)
    {
        var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, Email)
            };
        ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
    }

    #endregion

    #region Base

    [HttpGet]
    [Route("users")]
    public async Task<IList<User>> GetAll() => await _managerUser.GetAll();

    [HttpPost]
    public IActionResult CreateUser(string Name, string LastName, string Email, string Phone, string Login, string Password)
    {
        if (Name != null && LastName != null && Email != null && Phone != null && Login != null && Password != null)
        {
            _managerUser.Create(Name, LastName, Email, Phone, Login, Password);
            return RedirectToAction(nameof(SignIn));
        } else
        {
            ViewBag.isError = "false";
            return RedirectToAction(nameof(SignUp));
        }
    }

    [HttpPut]
    [Route("users")]
    public Task Create([FromBody] CreateUserRequest request) => _managerUser.Create(request.Name, request.LastName, request.Email, request.Phone, request.Login, request.Password);

    [HttpDelete]
    [Route("users/{id}")]
    public async Task Delete(int id)
    {
         await _managerUser.Delete(id);
         Logout();
    }


    #endregion


    //[HttpGet]
    //[Route("users/SignIn")]

    //public static Task Search(string Email) => _manager.Search(Email);


    //public IActionResult SignIn() => RedirectToPage("/Home/SignIn");
    //public IActionResult SignUp() => RedirectToPage("/Home/SignUp");

    #region Changes
    public IActionResult RePassword(string oldPassword, string newPassword)
    {
        _managerUser.RePassword(newPassword, oldPassword, CurrentUser.Id);
        CurrentUser.Password = newPassword;
        _user = CurrentUser;
        return RedirectToAction(nameof(Personal));
    }

    public IActionResult ReEmail(string newEmail)
    {
        _managerUser.ReEmail(newEmail, CurrentUser.Id);
        CurrentUser.Email = newEmail;
        _user = CurrentUser;
        return RedirectToAction(nameof(Personal));
    }

    public IActionResult RePhone(string newPhone)
    {
        _managerUser.RePhone(newPhone, CurrentUser.Id);
        CurrentUser.Phone = newPhone;
        _user = CurrentUser;
        return RedirectToAction(nameof(Personal));
    }

    [HttpPost]
    public async Task<ActionResult> AddFile(IFormFile newPhoto)
    {
        if (newPhoto != null)
        {
            string path = "/Files/avatars/" + newPhoto.FileName;
            using (var fs = new FileStream(_env.WebRootPath + path, FileMode.Create))
            {
                await newPhoto.CopyToAsync(fs);
            }

            await _managerUser.RePhoto(newPhoto.FileName, path, CurrentUser.Id);
            CurrentUser.Name_Photo = newPhoto.FileName;
            CurrentUser.Path = path;
            _user = CurrentUser;
        }

        return RedirectToAction(nameof(Personal));
    }

    public IActionResult AddAddress(string area, string street, int number_of_house, int number_of_apartment)
    {
        _managerAddress.Create(area, street, number_of_house, number_of_apartment);
        _managerUser.ADRES(_managerAddress.Return(area, street, number_of_house, number_of_apartment), CurrentUser.Id);
        _user = CurrentUser;
        return RedirectToAction(nameof(Personal));
    }

    public IActionResult ReAddress(string area, string street, int number_of_house, int number_of_apartment)
    {
        _managerAddress.Re(area, street, number_of_house, number_of_apartment, CurrentUser.AddressID);
        return RedirectToAction(nameof(Personal));
    }
    #endregion

}
