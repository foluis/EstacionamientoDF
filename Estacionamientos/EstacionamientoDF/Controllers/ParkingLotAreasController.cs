using EstacionamientoDF.Models;
using EstacionamientoDF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EstacionamientoDF.Controllers
{
    public class ParkingLotAreasController : Controller
    {        
        private readonly ApplicationDbContext _context;

        public ParkingLotAreasController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index(int id)
        {
            var parkingLotAreas = _context.ParkingLotAreas.
                Where(pl => pl.ParkingLotId == id);

            var parkingLotAreasViewModel = parkingLotAreas.
                Select(pl => new ParkingLotAreaViewModel
                {
                    Id = pl.Id,
                    Name = pl.Name,
                    ParkingLotId = pl.ParkingLotId,
                    Latitude =pl.Latitude,
                    Longitude = pl.Longitude,
                    Slots = pl.Slots,
                    UsedSlots = pl.UsedSlots
                });

            return View(parkingLotAreasViewModel);
        }
    }
}