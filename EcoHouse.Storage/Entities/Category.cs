using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoHouse.Storage.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name_Of_Category { get; set; }

        [ForeignKey(nameof(Name_Of_Category))]
        public virtual Dish Dish { get; set; }

    }
}
