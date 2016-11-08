using NA.ParkingLot.Web.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NA.ParkingLot.Web.Core
{
    public interface IUnitOfWork : IDisposable
    {
        ICompanyRepository Companies { get; }
     
        int Complete();
    }
}
