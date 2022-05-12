namespace EcoHouse.Logic.Orders;
public interface IOrderManager
{
    Task<IList<Order>> GetAll();
    Task Create(int price, int count, int dishID, string description, int DeliveryID);
    Task Delete(int id);
}
