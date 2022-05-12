
namespace EcoHouse.Storage.Entities
{
    public class Dish
    {
        [Key]
        public string Dish_ID { get; set; }

        public string Name { get; set; }

        [Required]
        public string Structure_ { get; set; }

        [ForeignKey(nameof(Structure_))]
        public virtual Structure Structure { get; set; }

        public int Mass { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }

        [Required]

        public string Name_Of_Category { get; set; }

        [Required]

        public string Process_ { get; set; }

        [ForeignKey(nameof(Process_))]
        public virtual Process Process { get; set; }

        [Required]
        public string Link { get; set; }
    }
}
