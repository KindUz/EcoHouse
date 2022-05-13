using EcoHouse.Storage;

namespace EcoHouse.Logic.Dishes;
public class DishManager : IDishManager
{
    private readonly UniversityContext _context;
    public DishManager(UniversityContext context)
    {
        _context = context;
    }
    public async Task<IList<Dish>> GetAll() => await _context.dishes.ToListAsync();

    public async Task Create(string name, int structure, int mass, int price, string description, int categoryid, string recipe, string link)
    {
        var dish = new Dish { Name = name, Structure_ = structure, Mass = mass, Price = price, Description = description, CategoryID = categoryid, Recipe = recipe, Link = link };

        _context.dishes.Add(dish);

        await _context.SaveChangesAsync();
    }

    public async Task Delete(int ID)
    {
        var dish = _context.dishes.FirstOrDefault(g => g.Dish_ID == ID);

        if (dish != null)
        {
            _context.dishes.Remove(dish);

            await _context.SaveChangesAsync();
        }
    }
}
