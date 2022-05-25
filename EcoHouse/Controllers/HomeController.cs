using EcoHouse.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using EcoHouse.Logic.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using EcoHouse.Logic.Dishes;
using EcoHouse.Logic.Orders;
using EcoHouse.Logic.Products;
using EcoHouse.Logic.Main_Addresses;

namespace EcoHouse.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDishManager _managerDish;
        private readonly IOrderManager _managerOrder;
        private readonly IProductManager _managerProduct;
        private readonly IMain_AddressManager _managerAddress;
        private static bool _buy;
        //private readonly ILogger<HomeController> _logger;
        //////////////private readonly IUserManager _UserManager;
        //public HomeController(ILogger<HomeController> logger /*, IUserManager UserManager*/)
        //{
        //    _logger = logger;
        //    //////////////_UserManager = UserManager;
        //}
        public HomeController(IDishManager managerDish, IOrderManager managerOrder, IProductManager managerProduct, IMain_AddressManager managerAddress)
        {
            _managerDish = managerDish;
            _managerOrder = managerOrder;
            _managerProduct = managerProduct;
            _managerAddress = managerAddress;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Dishes = await _managerDish.GetAll();
            ViewBag.Orders = await _managerOrder.GetAll();
            ViewBag.Address = await _managerAddress.GetAll();
            ViewBag.Products = await _managerProduct.GetAll();
            ViewBag.User = UsersController.CurrentUser;
            _buy = false;
            return View();
        }
        public async Task<IActionResult> Basket()
        {
            if (UsersController.CurrentUser != null)
            {
                ViewBag.Dishes = await _managerDish.GetAll();
                ViewBag.Orders = await _managerOrder.GetAll();
                ViewBag.User = UsersController.CurrentUser;
                return View();
            }
            else
            {
                return Redirect("~/Users/SignIn");
            }
        }
        public async Task<IActionResult> Order()
        {
            ViewBag.Orders = await _managerOrder.GetAll();
            ViewBag.Address = await _managerAddress.GetAll();
            ViewBag.User = UsersController.CurrentUser;
            if (ViewBag.Orders[0].Count == 0)
            {
                _buy = false;
            } else
            {
                _buy = true;
            }
            if (_buy == true)
            {
                return View();
            } else
            {
                return RedirectToAction("Index");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}