namespace EcoHouse.Logic.Dishes;
public interface IDishManager
{
    Task<IList<Dish>> GetAll();
    Task Create(string name, int structure, int mass, int price, string description, int categoryid, string recipe, string link);
    Task Delete(int ID);
}
