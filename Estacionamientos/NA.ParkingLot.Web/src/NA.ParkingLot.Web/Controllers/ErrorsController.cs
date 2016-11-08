using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NA.ParkingLot.Web.Controllers
{
    public class ErrorsController : Controller
    {      
        public IActionResult Index()
        {   
            return View("Error");
        }

        public IActionResult Error(string Id)
        {
            switch (Id)
            {
                case "404":
                    return View("Error404");                    
                default:
                    return View("Error");                    
            }
            
        }
    }
}
