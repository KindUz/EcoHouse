using EcoHouse.Storage;
using Microsoft.Data.SqlClient;

namespace EcoHouse.Logic.Orders;
public class OrderManager : IOrderManager
{
    private readonly UniversityContext _context;

    public OrderManager(UniversityContext context)
    {
        _context = context;
    }

    public async Task<IList<Order>> GetAll() => await _context.Orders.ToListAsync();

    public async Task Create()
    {
        var order = new Order { Price = 0, Count = 0, Description = " "};
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int UserId)
    {
        await Task.Delay(0);
        var order = _context.Orders.FirstOrDefault(g => g.UserID == UserId);
        if (order != null)
        {
            foreach (var dishes in _context.dishes.Where(d => d.OrdersID == order.OrdersID))
                dishes.OrdersID = null;
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }
    }

    public async Task CHTOBI_NE_BILO_TIMEOUTA()
    {
        var order = _context.Orders.FirstOrDefault(g => g.OrdersID != 0);
        if (order != null)
        //foreach (var DELorder in _context.Orders.ToList())
        {
            foreach (var dishes in _context.dishes.Where(d => d.OrdersID == order.OrdersID))
                dishes.OrdersID = null;
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }
    }
    public async Task CreateByUser(int userId)
    { 
        var order = new Order {UserID = userId, Price = 0, Count = 0, Description = " "};
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

    }

    public async Task CostUp(int price)
    {
        var order = _context.Orders.FirstOrDefault(g => g.OrdersID != null);
        order.Price = order.Price + price;
        order.Count++;
        await _context.SaveChangesAsync();
    }

    public async Task CostDown(int price)
    {
        var order = _context.Orders.FirstOrDefault(g => g.OrdersID != null);
        order.Price = order.Price - price;
        order.Count--;
        await _context.SaveChangesAsync();
    }
}
