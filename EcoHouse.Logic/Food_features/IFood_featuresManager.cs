namespace EcoHouse.Logic.Food_features;
public interface IFood_featuresManager
{
    Task<IList<Food_Features>> GetAll();

    Task Create (string name);

    Task Delete (int id);
}
