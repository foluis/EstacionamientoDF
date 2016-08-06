using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EstacionamientoDF.Models
{
    public class ParkingLot
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]        
        public decimal Latitude { get; set; }

        [Required]
        public decimal Longitude { get; set; }

        ApplicationUser ParkingLotAdmin { get; set; }

        //[Required]
        //int ParkingLotAdminId { get; set; }
    }
}