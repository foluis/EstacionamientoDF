using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EstacionamientoDF.Controllers
{
    public class ParkingLotsController : Controller
    {
        // GET: ParkingLot
        public ActionResult Create()
        {
            return View();
        }
    }
}