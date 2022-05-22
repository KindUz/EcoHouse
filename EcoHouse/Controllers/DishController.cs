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
    public DishController(IDishManager managerDish, IStructureManager managerStructure)
    {
        _managerDish = managerDish;
        _managerStructure = managerStructure;
    }
    public async Task<IActionResult> Menu()
    {
        ViewBag.Dishes = await _managerDish.GetAll();
        ViewBag.Structures = await _managerStructure.GetAll();
        return View();
    }
    public async Task<IActionResult> MenuChoice()
    {
        ViewBag.Dishes = await _managerDish.GetAll();
        ViewBag.Structures = await _managerStructure.GetAll();
        return View();
    }
    public async Task<IActionResult> Dish()
    {
        ViewBag.Dishes = await _managerDish.GetAll();
        ViewBag.Structures = await _managerStructure.GetAll();
        return View();
    }
    public async Task<IActionResult> Delivery()
    {
        ViewBag.Dishes = await _managerDish.GetAll();
        ViewBag.Structures = await _managerStructure.GetAll();
        return View();
    }

    [HttpGet]
    [Route("dishes")]
    public async Task<IList<Dish>> GetAll() => await _managerDish.GetAll();

    [HttpPut]
    [Route("dishes")]
    public Task Create([FromBody] CreateDishRequest request) => _managerDish.Create(request.Name, request.Structure_, request.Mass, request.Price, request.Description, request.CategoryID, request.Recipe, request.Link);

    [HttpPost]
    public async Task<IActionResult> Menu(string Text)
    {
        var dishes = await _managerDish.GetAll();
        var dish = from m in dishes
                   select m;

        if (!string.IsNullOrEmpty(Text)) 
        {
            dish = dish.Where(s => s.Name.Contains(Text));
        }
        ViewBag.Dishes = dish;
        return View();
    }

    [HttpDelete]    

    [Route("dishes/{id}")]
    public Task Delete(int id) => _managerDish.Delete(id);
}
