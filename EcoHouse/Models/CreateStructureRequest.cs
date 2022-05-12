namespace EcoHouse.Models;
public class CreateStructureRequest
{
    //Ingredients = ingredients, Proteins = proteins, Fats = fats, Carbohydrates = carbohydrates, Calorific = calorific
    public string Ingredients { get; set; }
    public float Proteins { get; set; }
    public float Fats { get; set; }
    public float Carbohydrates { get; set; }
    public float Calorific { get; set; }
}
