using EcoHouse.Logic.Structures;
using EcoHouse.Models;
using EcoHouse.Storage.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EcoHouse.Controllers;
public class StructureController : Controller
{
    private readonly IStructureManager _manager;

    public StructureController(IStructureManager manager)
    {
        _manager = manager;
    }

    [HttpGet]
    [Route("structures")]
    public async Task<IList<Structure>> GetAll() => await _manager.GetAll();

    [HttpPut]
    [Route("structures")]
    public Task Create([FromBody] CreateStructureRequest request) => _manager.Create(request.Ingredients, request.Proteins, request.Fats, request.Carbohydrates, request.Calorific);

    [HttpDelete]
    [Route("structures/{id}")]
    public Task Delete(int id) => _manager.Delete(id);

}
