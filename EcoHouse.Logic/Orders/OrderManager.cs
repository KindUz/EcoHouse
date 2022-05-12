using EcoHouse.Storage;

namespace EcoHouse.Logic.Orders;
public class OrderManager : IOrderManager
{
    private readonly UniversityContext _context;

    public OrderManager(UniversityContext context)
    {
        _context = context;
    }

    public async Task<IList<Order>> GetAll() => await _context.Orders.ToListAsync();

    public async Task Create(int price, int count, int dishID, string description, int DeliveryID)
    {
        var order = new Order { Price = price, Count = count, DishID = dishID, Description = description, Delivery_ID = DeliveryID};
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var order = _context.Orders.FirstOrDefault(g => g.OrdersID == id);
        if (order != null)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }
    }
}
