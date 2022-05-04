using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoHouse.Storage.Entities
{
    public class Address
    {
        [Key]
        public int Address_ID { get; set; }

        [Required]
        public string Area { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public int Number_Of_House { get; set; }

        [Required]
        public int Number_Of_Apartment { get; set; }
    }
}
