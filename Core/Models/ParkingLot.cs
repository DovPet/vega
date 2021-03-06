using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace vega.Core.Models
{
    public class ParkingLot
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        [StringLength(255)]
        public string Address { get; set; }

    }
}