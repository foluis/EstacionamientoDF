using System;
using System.Collections.Generic;

namespace NA.ParkingLot.Web.Core.Domain
{
    public partial class Company
    {
        public Company()
        {
            ParkingLots = new HashSet<ParkingLot>();
        }

        public int Id { get; set; }
        public string AdminId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ParkingLot> ParkingLots { get; set; }
        public virtual AspNetUsers Admin { get; set; }
    }
}
