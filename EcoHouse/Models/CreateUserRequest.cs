namespace EcoHouse.Models;

public class CreateUserRequest
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }

    //var user = new User { Name = name, LastName = Lastname, Email = email, Phone = phone, Login = login, Password = password };

}
