using EcoHouse.Logic.Food_features;
using EcoHouse.Models;
using EcoHouse.Storage.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EcoHouse.Controllers;

public class Food_FeaturesController : Controller
{
    private readonly IFood_featuresManager _manager;

    public Food_FeaturesController(IFood_featuresManager manager)
    {
        _manager = manager;
    }

    [HttpGet]
    [Route("food_features")]
    public async Task<IList<Food_Features>> GetAll() => await _manager.GetAll();

    [HttpPut]
    [Route("food_features")]
    public Task Create([FromBody] CreateFood_FeaturesRequest request) => _manager.Create(request.Name);

    [HttpDelete]
    [Route("food_features/{id}")]
    public Task Delete(int id) => _manager.Delete(id);
}
