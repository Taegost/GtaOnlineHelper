using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebFrontEnd.Models
{
    public class VcPlate
    {
        [Required] 
        public int ID { get; set; }
        [Required] 
        public string Name { get; set; }
        [Required] 
        public int VehicleId { get; set; }
        [ForeignKey("VehicleId")]
        public VcVehicle Vehicle { get; set; }
        [Required] 
        public int RangeId { get; set; }
        [ForeignKey("RangeId")]
        public VcRangeType Range { get; set; }
    } // class VcVehicles
}
