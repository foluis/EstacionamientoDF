using System;
using System.Collections.Generic;

namespace NA.ParkingLot.Web.Core.Domain
{
    public partial class Slot
    {
        public int Id { get; set; }
        public bool IsInUse { get; set; }
        public int ParkingLotAreaId { get; set; }
        public string UserId { get; set; }

        public virtual ParkingLotArea ParkingLotArea { get; set; }
        public virtual AspNetUsers User { get; set; }
    }
}
