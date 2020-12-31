using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebFrontEnd.Models
{
    public class VcCollection
    {
        [Required] 
        public int ID { get; set; }
        [Required] 
        public int PlateId { get; set; }
        [ForeignKey("PlateId")]
        public VcPlate Plate { get; set; }
        [Required] 
        public int CollectionTypeID { get; set; }
        [ForeignKey("CollectionTypeID")]
        public VcCollectionType CollectionType { get; set; }
    }
}
