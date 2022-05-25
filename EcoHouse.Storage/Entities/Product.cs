namespace EcoHouse.Storage.Entities
{
    public class Product
    {
        [Key]
        public int Product_ID { get; set; }

        public string? Link { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
