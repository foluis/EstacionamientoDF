using EstacionamientoDF.Models;
using EstacionamientoDF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EstacionamientoDF.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        public UsersController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var allUsers = _context.Users.ToList();

            //var users = allusers.Where(x => x.Roles.Select(role => role.Name).
            //Contains("User")).
            //ToList();

            var usersViewModel = allUsers.Select(user => new UserViewModel
            {
                UserEmail = user.Email
                //,
                //Roles = string.Join(",", user.Roles.Select(role => role.Name))
            }).ToList();

            //var admins = allusers.Where(x => x.Roles.Select(role => role.Name).Contains("Admin")).ToList();
            //var adminsVM = admins.Select(user => new UserViewModel { Username = user.FullName, Roles = string.Join(",", user.Roles.Select(role => role.Name)) }).ToList();
            //var model = new GroupedUserViewModel { Users = userVM, Admins = adminsVM };

            return View(usersViewModel);
        }
    }
}