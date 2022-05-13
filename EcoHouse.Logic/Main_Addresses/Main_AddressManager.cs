using EcoHouse.Storage;

namespace EcoHouse.Logic.Main_Addresses;
public class Main_AddressManager : IMain_AddressManager
{
    private readonly UniversityContext _context;

    public Main_AddressManager(UniversityContext context)
    {
        _context = context;
    }

    public async Task<IList<Main_Address>> GetAll() => await _context.main_Addresses.ToListAsync();
    public async Task Create(string area, string street, int number_of_house, int number_of_apartment)
    {
        var main_address = new Main_Address { Area = area, Street = street, Number_Of_House = number_of_house, Number_Of_Apartment = number_of_apartment };
        _context.main_Addresses.Add(main_address);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int Id)
    {
        var main_address = _context.main_Addresses.FirstOrDefault(g => g.Address_ID == Id);
        if (main_address != null)
        {
            _context.main_Addresses.Remove(main_address);
            await _context.SaveChangesAsync();
        }
    }
}
