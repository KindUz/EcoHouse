using Microsoft.AspNetCore.Http;

namespace EcoHouse.Logic.Users;
public interface IUserManager
{
    Task<IList<User>> GetAll();
    Task Create(string name, string Lastname, string email, string phone, string login, string password);

    Task Delete(int ID);

    User CheckPassAndLog(string email, string pass);

    Task RePassword(string password, string OldPassword, int Id);
    Task ReEmail(string email, int Id);
    Task RePhone(string phone, int Id);
    Task RePhoto(string newPhoto_name, string path, int Id);
    Task ADRES(int Aid, int Id);
}
