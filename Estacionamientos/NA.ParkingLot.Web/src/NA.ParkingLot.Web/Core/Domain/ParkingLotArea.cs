using System;
using System.Collections.Generic;

namespace NA.ParkingLot.Web.Core.Domain
{
    public partial class ParkingLotArea
    {
        public ParkingLotArea()
        {
            Slots = new HashSet<Slot>();
        }

        public int Id { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Name { get; set; }
        public int ParkingLotId { get; set; }
        public int SlotsQuantity { get; set; }
        public int UsedSlotsQuantity { get; set; }

        public virtual ICollection<Slot> Slots { get; set; }
        public virtual ParkingLot ParkingLot { get; set; }
    }
}
