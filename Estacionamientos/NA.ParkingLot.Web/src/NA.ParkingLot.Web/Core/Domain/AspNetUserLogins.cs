using System;
using System.Collections.Generic;

namespace NA.ParkingLot.Web.Core.Domain
{
    public partial class AspNetUserLogins
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string UserId { get; set; }

        public virtual AspNetUsers User { get; set; }
    }
}
