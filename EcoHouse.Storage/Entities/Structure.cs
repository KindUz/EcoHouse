using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoHouse.Storage.Entities
{
    public class Structure
    {
        [Key]
        public int Structure_ID { get; set; }

        [Required]
        public string Ingredients { get; set; }

        public float Proteins { get; set; }
        public float Fats { get; set; }
        public float Carbohydrates { get; set; }
        
        [Required]
        public float Calorific { get; set; }

    }
}
