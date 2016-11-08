using NA.ParkingLot.Web.Core.Domain;
using System;
using System.Collections.Generic;

namespace NA.ParkingLot.Web.Core
{
    public partial class AspNetUserClaims
    {
        public int Id { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public string UserId { get; set; }

        public virtual AspNetUsers User { get; set; }
    }
}
