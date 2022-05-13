namespace EcoHouse.Logic.Deliveries;
public interface IDeliveryManager
{
    Task<IList<Delivery>> GetAll();

    Task Create(int term, int addressid);

    Task Delete(int id);
}
