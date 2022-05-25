using EcoHouse.Logic.Dishes;
using EcoHouse.Models;
using EcoHouse.Storage.Entities;
using Microsoft.AspNetCore.Mvc;
using Korzh.EasyQuery.Linq;
using EcoHouse.Storage;
using EcoHouse.Logic.Structures;
using EcoHouse.Logic.Orders;
using EcoHouse.Logic.Users;
using EcoHouse.Logic.Products;
using EcoHouse.Logic.Categories;

namespace EcoHouse.Controllers;
public class DishController : Controller
{
    private readonly IDishManager _managerDish;
    private readonly IStructureManager _managerStructure;
    private readonly IProductManager _managerProduct;
    private readonly ICategoryManager _managerCategory;
    private static IOrderManager _managerOrder;
    static private int _dishID = -1;
    static private int _productID = -1;
    static private int _categoryID = -1;
    public DishController(IDishManager managerDish, IStructureManager managerStructure, IOrderManager managerOrder, IProductManager managerProduct, ICategoryManager managerCategory)
    {
        _managerDish = managerDish;
        _managerStructure = managerStructure;
        _managerOrder = managerOrder;
        _managerProduct = managerProduct;
        _managerCategory = managerCategory;
    }
    public async Task<IActionResult> Menu()
    {
        _dishID = -1;
        ViewBag.Dishes = await _managerDish.GetAll();
        ViewBag.Structures = await _managerStructure.GetAll();
        ViewBag.Orders = await _managerOrder.GetAll();
        ViewBag.User = UsersController.CurrentUser;
        return View();
    }
    public async Task<IActionResult> MenuChoice()
    {
        if (_productID == -1)
        {
            return Redirect("~/Home/Index");
        } else
        {
            _dishID = -1;
            ViewBag.Dishes = await _managerDish.GetAll();
            ViewBag.Structures = await _managerStructure.GetAll();
            ViewBag.Orders = await _managerOrder.GetAll();
            ViewBag.ProductID = _productID;
            ViewBag.Products = await _managerProduct.GetAll();
            ViewBag.User = UsersController.CurrentUser;
            return View();
        }
    }
    public async Task<IActionResult> MenuCategory()
    {
        if (_categoryID == -1)
        {
            return Redirect("~/Home/Index");
        }
        else
        {
            _dishID = -1;
            ViewBag.Dishes = await _managerDish.GetAll();
            ViewBag.Structures = await _managerStructure.GetAll();
            ViewBag.Orders = await _managerOrder.GetAll();
            ViewBag.CategoryID = _categoryID;
            ViewBag.Category = await _managerCategory.GetAll();
            ViewBag.User = UsersController.CurrentUser;
            return View();
        }
    }
    public async Task<IActionResult> Dish()
    {
        ViewBag.Dishes = await _managerDish.GetAll();
        ViewBag.Structures = await _managerStructure.GetAll();
        ViewBag.Orders = await _managerOrder.GetAll();
        ViewBag.SaveDish = _dishID;
        ViewBag.User = UsersController.CurrentUser;
        if (ViewBag.SaveDish == -1)
        {
            return RedirectToAction("Menu");
        }
        else
        {
            return View();
        }
    }
    public async Task<IActionResult> Delivery()
    {
        _dishID = -1;
        ViewBag.Dishes = await _managerDish.GetAll();
        ViewBag.Structures = await _managerStructure.GetAll();
        ViewBag.Orders = await _managerOrder.GetAll();
        ViewBag.User = UsersController.CurrentUser;
        return View();
    }
    public IActionResult SaveDish(int dish)
    {
        _dishID = dish;
        return RedirectToAction("Dish");
    }
    public IActionResult SaveProduct(int product)
    {
        _productID = product;
        return RedirectToAction("MenuChoice");
    }
    public IActionResult SaveCategory(int category)
    {
        _categoryID = category;
        return RedirectToAction("MenuChoice");
    }

    [HttpGet]
    [Route("dishes")]
    public async Task<IList<Dish>> GetAll() => await _managerDish.GetAll();

    [HttpPut]
    [Route("dishes")]
    public Task Create([FromBody] CreateDishRequest request) => _managerDish.Create(request.Name, request.Structure_, request.Mass, request.Price, request.Description, request.CategoryID, request.Recipe, request.Link, request.ProductID);

    [HttpPost]
    public async Task<IActionResult> Menu(string Text)
    {
        var dishes = await _managerDish.GetAll();
        var dish = from m in dishes
                   select m;

        if (!string.IsNullOrEmpty(Text))
        {
            dish = dish.Where(s => s.Name.ToLower().Contains(Text.ToLower()));
        }
        ViewBag.Dishes = dish;
        ViewBag.Structures = await _managerStructure.GetAll();
        ViewBag.Orders = await _managerOrder.GetAll();
        return View();
    }

    [HttpDelete]

    [Route("dishes/{id}")]
    public Task Delete(int id) => _managerDish.Delete(id);

    #region Bucket
    public async Task<IActionResult> Add(int id, int price)
    {
        if (UsersController.CurrentUser != null)
        {
            var arr = await _managerOrder.GetAll();
            int orderId = arr[0].OrdersID;
            await _managerOrder.CostUp(price);
            await _managerDish.Add(id, orderId);
            return Redirect("~/Home/Basket");
        }
        else
        {
            return Redirect("~/Users/SignIn");
        }
    }

    public async Task<IActionResult> AntiAdd(int id, int price)
    {
        await _managerOrder.CostDown(price);
        await _managerDish.AntiAdd(id);
        return Redirect("~/Home/Basket");
    }

    #endregion
}
