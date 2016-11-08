using EstacionamientoDF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EstacionamientoDF.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompanyController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var company = _context.Companies;
            return View(company);
        }
    }
}