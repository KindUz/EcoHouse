using EcoHouse.Storage;

namespace EcoHouse.Logic.Another_Address;
public class Another_AdressManager : IAnother_AdressManager
{
    private readonly UniversityContext _context;

    public Another_AdressManager(UniversityContext context)
    {
        _context = context;
    }

    public async Task<IList<Another_Adresses>> GetAll() => await _context.Another_Adresses.ToListAsync();
    public async Task Create(string area, string street, int number_of_house, int number_of_apartment)
    {
        var another_address = new Another_Adresses { Area = area, Street = street, Number_Of_House = number_of_house, Number_Of_Apartment = number_of_apartment };
        _context.Another_Adresses.Add(another_address);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int Id)
    {
        var another_address = _context.Another_Adresses.FirstOrDefault(g => g.Address_ID == Id);
        if (another_address != null)
        {
            _context.Another_Adresses.Remove(another_address);
            await _context.SaveChangesAsync();
        }
    }
}
