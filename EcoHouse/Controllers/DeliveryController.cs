using EcoHouse.Logic.Deliveries;
using EcoHouse.Models;
using EcoHouse.Storage.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EcoHouse.Controllers;
public class DeliveryController : Controller
{
    private readonly IDeliveryManager _manager;

    public DeliveryController(IDeliveryManager manager)
    {
        _manager = manager;
    }

    [HttpGet]
    [Route("delivery")]
    public async Task<IList<Delivery>> GetAll() => await _manager.GetAll();

    [HttpPut]
    [Route("delivery")]
    public Task Create([FromBody] CreateDeliveryRequest request) => _manager.Create(request.Term, request.AddressID);

    [HttpDelete]
    [Route("delivery/{id}")]
    public Task Delete(int id) => _manager.Delete(id);
}
