namespace EcoHouse.Storage.Entities
{
    public class Product
    {
        [Key]
        public int Product_ID { get; set; }

        [Required]
        public string Link { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
