using EcoHouse.Logic.Products;
using EcoHouse.Models;
using EcoHouse.Storage.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EcoHouse.Controllers;
public class ProductController : Controller
{
    private readonly IProductManager _manager;

    public ProductController(IProductManager manager)
    {
        _manager = manager;
    }

    [HttpGet]
    [Route("products")]
    public async Task<IList<Product>> GetAll() => await _manager.GetAll();

    [HttpPut]
    [Route("products")]
    public Task Create([FromBody] CreateProductRequest request) => _manager.Create(request.Link, request.Name);

    [HttpDelete]
    [Route("products/{id}")]
    public Task Delete(int id) => _manager.Delete(id);
}
