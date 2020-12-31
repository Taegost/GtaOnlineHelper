using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebFrontEnd.Models
{
    public class UserVcVehicle
    {
        [Required]
        public string ID { get; set; }
        [Required] 
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public IdentityUser User { get; set; }
        [Required] 
        public int PlateId { get; set; }
        [ForeignKey("PlateId")]
        public VcPlate Plate { get; set; }
    }
}
