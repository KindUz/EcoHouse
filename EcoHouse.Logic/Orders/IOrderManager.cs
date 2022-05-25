namespace EcoHouse.Logic.Orders;
public interface IOrderManager
{
    Task<IList<Order>> GetAll();
    Task Create();
    Task Delete(int id);
    Task CreateByUser(int userId);
    Task CostUp(int price);
    Task CostDown(int price);
    Task CHTOBI_NE_BILO_TIMEOUTA();
}
