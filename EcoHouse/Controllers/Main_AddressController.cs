using EcoHouse.Logic.Main_Addresses;
using EcoHouse.Models;
using EcoHouse.Storage.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EcoHouse.Controllers
{
    public class Main_AddressController : Controller
    {
        private readonly IMain_AddressManager _manager;

        public Main_AddressController(IMain_AddressManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        [Route("main_address")]
        public async Task<IList<Main_Address>> GetAll() => await _manager.GetAll();

        [HttpPut]
        [Route("main_address")]
        public Task Create([FromBody] CreateMain_AddressRequest request) => _manager.Create(request.Area, request.Street, request.Number_Of_House, request.Number_Of_Apartment);

        [HttpDelete]
        [Route("main_address/{id}")]
        public Task Delete(int id) => _manager.Delete(id);

        //public async Task<IActionResult> Main()
        //{
        //    var address = await _manager.GetAll();

        //    return View(address);
        //}

        //[HttpGet]
        //[Route("another_addresses")]
        //public async Task<IList<Another_Adresses>> GetAll() => await _manager.GetAll();

        //[HttpPut]
        //[Route("another_addresses")]
        //public Task Create([FromBody] CreateAnother_AddressRequest request) => _manager.Create(request.Area, request.Street, request.Number_Of_House, request.Number_Of_Apartment);
        //[HttpPost]
        //public IActionResult CreateAddres(string Area, string Street, int Number_Of_House, int Number_Of_Apartment)
        //{
        //    _manager.Create(Area, Street, Number_Of_House, Number_Of_Apartment);
        //    return RedirectToAction(nameof(Main));
        //}

        //[HttpDelete]
        //[Route("another_addresses/{Id}")]
        //public Task Delete(int id) => _manager.Delete(id);

    }

}
