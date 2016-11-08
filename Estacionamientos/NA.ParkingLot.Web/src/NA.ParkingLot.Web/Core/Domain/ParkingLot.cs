using System;
using System.Collections.Generic;

namespace NA.ParkingLot.Web.Core.Domain
{
    public partial class ParkingLot
    {
        public ParkingLot()
        {
            ParkingLotAreas = new HashSet<ParkingLotArea>();
        }

        public int Id { get; set; }
        public int CompanyId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ParkingLotArea> ParkingLotAreas { get; set; }
        public virtual Company Company { get; set; }
    }
}
