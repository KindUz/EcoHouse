using EcoHouse.Logic.Dishes;
using EcoHouse.Models;
using EcoHouse.Storage.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EcoHouse.Controllers;
public class DishController : Controller
{
    private readonly IDishManager _manager;
    public DishController(IDishManager manager)
    {
        _manager = manager;
    }

    [HttpGet]
    [Route("dishes")]
    public async Task<IList<Dish>> GetAll() => await _manager.GetAll();

    [HttpPut]
    [Route("dishes")]
    public Task Create([FromBody] CreateDishRequest request) => _manager.Create(request.Name, request.Structure_, request.Mass, request.Price, request.Description, request.CategoryID, request.Recipe, request.Link);

    [HttpDelete]    

    [Route("dishes/{id}")]
    public Task Delete(int id) => _manager.Delete(id);
}
