﻿namespace EcoHouse.Storage.Entities
{
    public class Dish
    {
        [Key]
        public int Dish_ID { get; set; }

        public string Name { get; set; }

        [Required]
        public int Structure_ { get; set; }

        [ForeignKey(nameof(Structure_))]
        public virtual Structure Structure { get; set; }
        public int Mass { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }

        [Required]
        public int CategoryID { get; set; }

        [ForeignKey(nameof(CategoryID))]
        public virtual Category Category { get; set; }

        [Required]
        public string Recipe { get; set; }

        [Required]
        public string Link { get; set; }

        public string? Text { get; set; }

        public string? Special { get; set; }
        public int? count { get; set; }

        [Required]
        public int ProductID { get; set; }

        [ForeignKey(nameof(ProductID))]
        public virtual Product? Product { get; set; }

        public int? OrdersID { get; set; }

        [ForeignKey(nameof(OrdersID))]
        public virtual Order? Order { get; set; }

    }
}
