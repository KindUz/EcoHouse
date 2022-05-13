namespace EcoHouse.Models;
public class CreateDishRequest
{
    //string name, int structure, int mass, int price, string description, int categoryid, string recipe, string link
    public string Name { get; set; }
    public int Structure_ { get; set; }
    public int Mass { get; set; }
    public int Price { get; set; }
    public string Description { get; set; }
    public int CategoryID { get; set; }
    public string Recipe { get; set; }
    public string Link { get; set; }

}
