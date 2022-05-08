using EcoHouse.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EcoHouse.Controllers
{
    public class EcoHouseController : Controller
    {
        private readonly ILogger<EcoHouseController> _logger;

        public EcoHouseController(ILogger<EcoHouseController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Basket()
        {
            return View();
        }
        public IActionResult Delivery()
        {
            return View();
        }
        public IActionResult Dish()
        {
            return View();
        }
        public IActionResult Favorite()
        {
            return View();
        }
        public IActionResult Menu()
        {
            return View();
        }
        public IActionResult MenuChoice()
        {
            return View();
        }
        public IActionResult Order()
        {
            return View();
        }
        public IActionResult Personal()
        {
            return View();
        }
        public IActionResult SignIn()
        {
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}