using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoHouse.Storage.Entities
{
    public class Orders
    {
        [Key]
        public int OrdersID { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public string Name_Of_Dish { get; set; }

        [ForeignKey(nameof(Name_Of_Dish))]

        public virtual Dish Dish { get; set; }

        [Required]
        public string Description { get; set; }
        
        [Required]
        public int Delivery_ID { get; set; }

        [ForeignKey(nameof(Delivery_ID))]

        public virtual Delivery Delivery { get; set; }
    }
}
