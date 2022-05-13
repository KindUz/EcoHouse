using EcoHouse.Storage;

namespace EcoHouse.Logic.Deliveries;
public class DeliveryManager : IDeliveryManager
{
    private readonly UniversityContext _context;

    public DeliveryManager(UniversityContext context)
    {
        _context = context;
    }

    public async Task<IList<Delivery>> GetAll() => await _context.Deliveries.ToListAsync();

    public async Task Create(int term, int addressid)
    {
        var delivery = new Delivery { Term = term, AddressID = addressid };
        _context.Deliveries.Add(delivery);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int ID)
    {
        var delivery = _context.Deliveries.FirstOrDefault(g => g.DeliveryId == ID);
        if (delivery != null)
        {
            _context.Deliveries.Remove(delivery);
            await _context.SaveChangesAsync();
        }
    }
}
