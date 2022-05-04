using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoHouse.Storage.Entities
{
    public class Process
    {
        [Key]
        public string Process_ID { get; set; }

        public string Recipe { get; set; }
    }
}
