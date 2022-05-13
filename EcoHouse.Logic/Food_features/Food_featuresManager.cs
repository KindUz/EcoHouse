using EcoHouse.Storage;

namespace EcoHouse.Logic.Food_features;
public class Food_featuresManager : IFood_featuresManager
{
    private readonly UniversityContext _context;

    public Food_featuresManager(UniversityContext context)
    {
        _context = context;
    }

    public async Task<IList<Food_Features>> GetAll() => await _context.Food_Features.ToListAsync();

    public async Task Create (string name)
    {
        var features = new Food_Features { Name = name };
        _context.Food_Features.Add(features);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int ID)
    {
        var features = _context.Food_Features.FirstOrDefault(g => g.Food_FeaturesId == ID);
        if (features != null)
        {
            _context.Food_Features.Remove(features);
            await _context.SaveChangesAsync();
        }
    }
}
