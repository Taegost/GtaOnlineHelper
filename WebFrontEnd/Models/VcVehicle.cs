using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebFrontEnd.Models
{
    public class VcVehicle
    {
        [Required] 
        public int ID { get; set; }
        [Required] 
        public string Name { get; set; }
    } // class VcVehicle
}
