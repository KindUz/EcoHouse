using EcoHouse.Storage;

namespace EcoHouse.Logic.Categories;
public class CategoryManager : ICategoryManager
{
    private readonly UniversityContext _context;

    public CategoryManager(UniversityContext context)
    {
        _context = context;
    }
    public async Task<IList<Category>> GetAll() => await _context.Categories.ToListAsync();
    public async Task Create(string name_of_category)
    {
        var category = new Category { Name_Of_Category = name_of_category };
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int ID)
    {
        var category = _context.Categories.FirstOrDefault(g => g.CategoryId == ID);
        if (category != null)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}
