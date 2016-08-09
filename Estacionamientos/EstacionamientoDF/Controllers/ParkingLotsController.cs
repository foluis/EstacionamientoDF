using EstacionamientoDF.Models;
using EstacionamientoDF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EstacionamientoDF.Controllers
{
    public class ParkingLotsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ParkingLotsController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var parkingLots = _context.ParkingLots;

            var parkingLotsViewModel = parkingLots.
                Select(pl => new ParkingLotViewModel
                {
                    Id = pl.Id,
                    Name = pl.Name,
                    Latitude = pl.Latitude,
                    Longitude = pl.Longitude                    
                });

            return View(parkingLotsViewModel);
        }

        //[Authorize]
        public ActionResult Create()
        {
            var parkingLotViewModel = new ParkingLotViewModel();
            return View();
        }

        //[Authorize]
        [HttpPost]
        public ActionResult Create(ParkingLotViewModel viewModel)
        {
            var parkingLot = new ParkingLot
            {
                Name = viewModel.Name,
                Latitude = viewModel.Latitude,
                Longitude = viewModel.Longitude,
            };

            _context.ParkingLots.Add(parkingLot);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}