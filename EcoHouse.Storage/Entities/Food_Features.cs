namespace EcoHouse.Storage.Entities
{
    public class Food_Features
    {
        [Key]
        public int Food_FeaturesId { get; set; }

        [Required]
        public string Name { get; set; }

    }
}
