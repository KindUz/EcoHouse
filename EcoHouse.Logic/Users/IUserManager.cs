namespace EcoHouse.Logic.Users;
public interface IUserManager
{
    Task<IList<User>> GetAll();
    Task Create(string name);

    Task Delete(int ID);
}
