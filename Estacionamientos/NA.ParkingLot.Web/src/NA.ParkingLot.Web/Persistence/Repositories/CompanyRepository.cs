using NA.ParkingLot.Web.Core.Domain;
using NA.ParkingLot.Web.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NA.ParkingLot.Web.Persistence.Repositories
{
    public class CompanyRepository:Repository<Company>,ICompanyRepository
    {
        //private ParkingLotContext _context;

        public CompanyRepository(ParkingLotContext context) 
            : base(context)
        {
        }

        public IEnumerable<Company> GetTopBiguestCompanies(int pageIndex, int pageSize = 10)
        {
            return ParkingLotContext.Companies                 
                 .OrderBy(c => c.Name)
                 .Skip((pageIndex - 1) * pageSize)
                 .Take(pageSize)
                 .ToList();
        }

        public ParkingLotContext ParkingLotContext
        {
            get { return Context as ParkingLotContext; }
        }
    }
}
