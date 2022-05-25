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

        public int? UserID { get; set; }

        [ForeignKey(nameof(UserID))]

        public virtual User? User { get; set; }

        [Required]
        public string Description { get; set; }
        
        public int? Address_ID { get; set; }

        [ForeignKey(nameof(Address_ID))]

        public virtual Another_Adresses? Another_Adresses { get; set; }
    }
}
