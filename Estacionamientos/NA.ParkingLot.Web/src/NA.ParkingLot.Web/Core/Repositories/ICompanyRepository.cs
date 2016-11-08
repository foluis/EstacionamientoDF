using NA.ParkingLot.Web.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NA.ParkingLot.Web.Core.Repositories
{
    public interface ICompanyRepository : IRepository<Company>
    {
        IEnumerable<Company> GetTopBiguestCompanies(int pageIndex, int pageSize);
    }
}
