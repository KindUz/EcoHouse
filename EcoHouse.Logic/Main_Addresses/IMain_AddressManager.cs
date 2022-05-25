namespace EcoHouse.Logic.Main_Addresses;
public interface IMain_AddressManager
{
    Task<IList<Main_Address>> GetAll();

    Task Create(string area, string street, int number_of_house, int number_of_apartment);

    Task Delete(int Id);

    Task Re(string area, string street, int number_of_house, int number_of_apartment, int? id);

    int Return(string area, string street, int number_of_house, int number_of_apartment);
}
