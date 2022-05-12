namespace EcoHouse.Models;

public class CreateAnother_AddressRequest
{
    //Area = area, Street = street, Number_Of_House = number_of_house, Number_Of_Apartment = number_of_apartment
    public string Area { get; set; }
    public string Street { get; set; }
    public int Number_Of_House { get; set; }
    public int Number_Of_Apartment { get; set; }

}
