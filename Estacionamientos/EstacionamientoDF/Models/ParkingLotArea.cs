using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EstacionamientoDF.Models
{
    public class ParkingLotArea
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        public decimal Latitude { get; set; }

        [Required]
        public decimal Longitude { get; set; }

        [Required]
        public int Slots { get; set; }

        [Required]
        public int UsedSlots { get; set; }

        public ParkingLot ParkingLot { get; set; }

        [Required]
        public int ParkingLotId { get; set; }

    }
}