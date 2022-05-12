namespace EcoHouse.Logic.Structures;
public interface IStructureManager
{
    Task<IList<Structure>> GetAll();

    Task Create (string ingredients, float proteins, float fats, float carbohydrates, float calorific);

    Task Delete (int id);
}
