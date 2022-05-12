using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoHouse.Storage.Entities
{
    public class Order
    {
        [Key]
        public int OrdersID { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public int DishID { get; set; }

        [ForeignKey(nameof(DishID))]

        public virtual Dish Dish { get; set; }

        [Required]
        public string Description { get; set; }
        
        [Required]
        public int Delivery_ID { get; set; }

        [ForeignKey(nameof(Delivery_ID))]

        public virtual Delivery Delivery { get; set; }
    }
}
