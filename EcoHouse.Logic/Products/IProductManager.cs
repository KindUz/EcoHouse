namespace EcoHouse.Logic.Products;
public interface IProductManager
{
    Task<IList<Product>> GetAll();

    Task Create(string link, string name);

    Task Delete(int ID);
}
