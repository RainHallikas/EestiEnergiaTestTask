using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CarApp.Models
{
    public class CarSparePart
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public int CarMarkId { get; set; }
        public int SparePartId { get; set; }
        
        [ForeignKey("CarMarkId")]
        public virtual CarMark CarMark { get; set; }
        [ForeignKey("SparePartId")]
        public virtual SparePart SparePart { get; set; }
    }
}