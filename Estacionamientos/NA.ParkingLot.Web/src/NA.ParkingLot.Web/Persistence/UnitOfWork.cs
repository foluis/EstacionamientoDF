using NA.ParkingLot.Web.Core;
using NA.ParkingLot.Web.Core.Repositories;
using NA.ParkingLot.Web.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NA.ParkingLot.Web.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ParkingLotContext _context;

        public UnitOfWork(ParkingLotContext context)
        {
            _context = context;
            Companies = new CompanyRepository(_context);
            
        }

        public ICompanyRepository Companies { get; private set; }        

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}