using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NA.ParkingLot.Web.Persistence;
using NA.ParkingLot.Web.Core.Domain;
using NA.ParkingLot.Web.Core;

namespace NA.ParkingLot.Web.Controllers
{
    public class CompaniesController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public CompaniesController(IUnitOfWork unitOfWork, ParkingLotContext context)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Company> companies = _unitOfWork.Companies.GetAll();
            return View(companies);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Company company)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Companies.Add(company);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }

            return View(company);
        }

        public IActionResult Delete()
        {
            var company = _unitOfWork.Companies.Get(c => c.Id == 999);

            company.Id = 999;

            _unitOfWork.Companies.Remove(company);

            return RedirectToAction("Index");
        }
    }
}
