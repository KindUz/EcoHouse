using EcoHouse.Logic.Another_Address;
using EcoHouse.Models;
using EcoHouse.Storage.Entities;
using Microsoft.AspNetCore.Mvc;


namespace EcoHouse.Controllers;

public class Another_AddressController : Controller
{
    private readonly IAnother_AdressManager _manager;

    public Another_AddressController (IAnother_AdressManager manager)
    {
        _manager = manager;
    }

    public async Task<IActionResult> Main()
    {
        var address = await _manager.GetAll();

        return View(address);
    }

    [HttpGet]
    [Route("another_addresses")]
    public async Task<IList<Another_Adresses>> GetAll() => await _manager.GetAll();

    //[HttpPut]
    //[Route("another_addresses")]
    //public Task Create([FromBody] CreateAnother_AddressRequest request) => _manager.Create(request.Area, request.Street, request.Number_Of_House, request.Number_Of_Apartment);
    [HttpPost]
    public IActionResult CreateAddres(string Area, string Street, int Number_Of_House, int Number_Of_Apartment)
    {
        _manager.Create(Area, Street, Number_Of_House, Number_Of_Apartment);
        return RedirectToAction(nameof(Main));
    }
   
    [HttpDelete]
    [Route("another_addresses/{Id}")]
    public Task Delete(int id) => _manager.Delete(id);

}
