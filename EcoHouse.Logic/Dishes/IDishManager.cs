namespace EcoHouse.Logic.Dishes;
public interface IDishManager
{
    Task<IList<Dish>> GetAll();
    Task Create(string name, int structure, int mass, int price, string description, int categoryid, string recipe, string link, int productID);
    Task Delete(int ID);
    Task Add(int id, int orderId);
    Task AntiAdd(int id);
}
