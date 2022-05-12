namespace EcoHouse.Logic.Categories;
public interface ICategoryManager
{
    Task<IList<Category>> GetAll();

    Task Create (string name_of_category);

    Task Delete (int ID);
}
