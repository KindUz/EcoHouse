using EcoHouse.Logic.Orders;
using EcoHouse.Models;
using EcoHouse.Storage.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EcoHouse.Controllers;

public class OrderController : Controller
{
    private readonly IOrderManager _manager;

    public OrderController(IOrderManager manager)
    {
        _manager = manager;
    }
    [HttpGet]
    [Route("order")]
    public async Task<IList<Order>> GetAll() => await _manager.GetAll();

    [HttpPut]
    [Route("order")]
    public Task Create([FromBody] CreateOrderRequest request) => _manager.Create();




    [HttpDelete]
    [Route("order/{id}")]
    public Task Delete(int id) => _manager.Delete(id); 
}
