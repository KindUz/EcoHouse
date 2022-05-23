using EcoHouse.Storage;

namespace EcoHouse.Logic.Products;
public class ProductManager : IProductManager
{
    private readonly UniversityContext _context;

    public ProductManager(UniversityContext context)
    {
        _context = context;
    }
    public async Task<IList<Product>> GetAll() => await _context.Products.ToListAsync();
    public async Task Create(string link, string name)
    {
        var product = new Product { Link = link, Name = name};
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int ID)
    {
        var product = _context.Products.FirstOrDefault(g => g.Product_ID == ID);
        if (product != null)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
