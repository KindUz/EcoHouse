using EcoHouse.Logic.Users;
using EcoHouse.Models;
using EcoHouse.Storage.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EcoHouse.Controllers;
public class UsersController : Controller
{
    private readonly IUserManager _manager;

    public UsersController(IUserManager manager)
    {
        _manager = manager;
    }

    [HttpGet]
    [Route("users")]
    public async Task<IList<User>> GetAll() => await _manager.GetAll();

    [HttpPut]
    [Route("users")]
    public Task Create([FromBody] CreateUserRequest request) => _manager.Create(request.Name, request.LastName, request.AddressID, request.Email, request.Phone, request.Food_Features_ID, request.OrdersID, request.Login, request.Password);   

    [HttpDelete]
    [Route("users/{id}")]
    public Task Delete(int id) => _manager.Delete(id);
}
