namespace EcoHouse.Logic.Users;
public interface IUserManager
{
    Task<IList<User>> GetAll();
    Task Create(string name, string Lastname, int addressid, string email, string phone, int food_featID, int orderID, string login, string password);

    Task Delete(int ID);
}
