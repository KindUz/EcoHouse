namespace EcoHouse.Logic.Another_Address;
public interface IAnother_AdressManager
{
    Task<IList<Another_Adresses>> GetAll();

    Task Create(string area, string street, int number_of_house, int number_of_apartment);

    Task Delete(int Id);
}
