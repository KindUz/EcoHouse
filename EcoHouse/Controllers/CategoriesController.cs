using EcoHouse.Logic.Categories;
using EcoHouse.Models;
using EcoHouse.Storage.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EcoHouse.Controllers;
public class CategoriesController : Controller
{
    private readonly ICategoryManager _manager;

    public CategoriesController (ICategoryManager manager)
    {
        _manager = manager;
    }

    

    [HttpGet]
    [Route("categories")]
    public async Task<IList<Category>> GetAll() => await _manager.GetAll();

    [HttpPut]
    [Route("categories")]
    public Task Create([FromBody] CreateCategoryRequest request) => _manager.Create(request.Name_Of_Category);

    [HttpDelete]
    [Route("categories/{id}")]
    public Task Delete(int id) => _manager.Delete(id);
}