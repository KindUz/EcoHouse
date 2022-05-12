using EcoHouse.Storage;

namespace EcoHouse.Logic.Structures;
public class StructureManager : IStructureManager
{
    private readonly UniversityContext _context;

    public StructureManager(UniversityContext context)
    {
        _context = context;
    }
    public async Task<IList<Structure>> GetAll() => await _context.structures.ToListAsync();
    public async Task Create(string ingredients, float proteins, float fats, float carbohydrates, float calorific)
    {
        var structure = new Structure { Ingredients = ingredients, Proteins = proteins, Fats = fats, Carbohydrates = carbohydrates, Calorific = calorific };
        _context.structures.Add(structure);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int ID)
    {
        var structure = _context.structures.FirstOrDefault(g => g.Structure_ID == ID);
        if (structure != null)
        {
            _context.structures.Remove(structure);
            await _context.SaveChangesAsync();
        }
    }
}
