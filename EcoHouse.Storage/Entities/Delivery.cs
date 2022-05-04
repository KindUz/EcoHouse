using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoHouse.Storage.Entities
{
    public class Delivery
    {
        [Key]
        public int DeliveryId { get; set; }

        [Required]
        public int Term { get; set; }

        [Required]
        public int AddressID { get; set; }

        [ForeignKey(nameof(AddressID))]

        public virtual Address Address { get; set; }
    }
}
