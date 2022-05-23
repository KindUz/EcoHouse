using EcoHouse.Logic.Users;
using EcoHouse.Models;
using EcoHouse.Storage.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace EcoHouse.Controllers;
public class UsersController : Controller
{
    private static IUserManager _manager;
    private readonly ILogger _logger;
    static User CurrentUser;
    static private User _user;
    static private bool _isUser = true;

    public UsersController(IUserManager manager, ILogger<AccountController> logger)
    {
        _manager = manager;
        _logger = logger;
    }

    #region Auth

    public async Task<IActionResult> SignUp()
    {
        var user = await _manager.GetAll();
        if (_user == null)
        {
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
            return View();
        }
    }

    public IActionResult Logout()
    {
        HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        CurrentUser = null;
        _user = null;
        _isUser = true;
        return RedirectToAction("SignIn");
    }


    [HttpPost]
    public async Task<IActionResult> SignIn(string login, string pass)
    {
        if ((CurrentUser = _manager.CheckPassAndLog(login, pass)) != null)
        {
            await Authenticate(login);
            _user = CurrentUser;
            _isUser = true;
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

    //public async Task<IActionResult> Main()
    //{
    //    var user = await _manager.GetAll();

    //    return View(user);
    //}

    #region Base

    [HttpGet]
    [Route("users")]
    public async Task<IList<User>> GetAll() => await _manager.GetAll();

    [HttpPost]
    public IActionResult CreateUser(string Name, string LastName, string Email, string Phone, string Login, string Password)
    {
        _manager.Create(Name, LastName, Email, Phone, Login, Password);
        return RedirectToAction(nameof(SignUp));
    }

    [HttpPut]
    [Route("users")]
    public Task Create([FromBody] CreateUserRequest request) => _manager.Create(request.Name, request.LastName, request.Email, request.Phone, request.Login, request.Password);

    [HttpDelete]
    [Route("users/{id}")]
    public async Task Delete(int id)
    {
         await _manager.Delete(id);
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
        _manager.RePassword(newPassword, oldPassword, CurrentUser.Id);
        CurrentUser.Password = newPassword;
        _user = CurrentUser;
        return RedirectToAction(nameof(Personal));
    }

    public IActionResult ReEmail(string newEmail)
    {
        _manager.ReEmail(newEmail, CurrentUser.Id);
        CurrentUser.Email = newEmail;
        _user = CurrentUser;
        return RedirectToAction(nameof(Personal));
    }

    public IActionResult RePhone(string newPhone)
    {
        _manager.RePhone(newPhone, CurrentUser.Id);
        CurrentUser.Phone = newPhone;
        _user = CurrentUser;
        return RedirectToAction(nameof(Personal));
    }

    #endregion

}
