using EcoHouse.Logic.Dishes;
using EcoHouse.Models;
using EcoHouse.Storage.Entities;
using Microsoft.AspNetCore.Mvc;
using Korzh.EasyQuery.Linq;
using EcoHouse.Storage;
using EcoHouse.Logic.Structures;

namespace EcoHouse.Controllers;
public class DishController : Controller
{
    private readonly IDishManager _managerDish;
    private readonly IStructureManager _managerStructure;
    static private int _dishID = -1;
    public DishController(IDishManager managerDish, IStructureManager managerStructure)
    {
        _managerDish = managerDish;
        _managerStructure = managerStructure;
    }
    public async Task<IActionResult> Menu()
    {
        _dishID = -1;
        ViewBag.Dishes = await _managerDish.GetAll();
        ViewBag.Structures = await _managerStructure.GetAll();
        return View();
    }
    public async Task<IActionResult> MenuChoice()
    {
        _dishID = -1;
        ViewBag.Dishes = await _managerDish.GetAll();
        ViewBag.Structures = await _managerStructure.GetAll();
        return View();
    }
    public async Task<IActionResult> Dish()
    {
        ViewBag.Dishes = await _managerDish.GetAll();
        ViewBag.Structures = await _managerStructure.GetAll();
        ViewBag.SaveDish = _dishID;
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
        return View();
    }
    public IActionResult SaveDish(int dish)
    {
        _dishID = dish;
        return RedirectToAction("Dish");
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
        return View();
    }

    [HttpDelete]    

    [Route("dishes/{id}")]
    public Task Delete(int id) => _managerDish.Delete(id);
}
