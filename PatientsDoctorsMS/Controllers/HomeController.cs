using DataAccess.Entities;
using DataAccess.Repositories;
using PatientsDoctorsMS.Models;
using PatientsDoctorsMS.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientsDoctorsMS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string RedirectUrl)
        {
            return View(new HomeLoginVM
            {
                RedirectUrl = RedirectUrl
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(HomeLoginVM model)
        {
            if (ModelState.IsValid)
            {
                AuthenticationManager.Authenticate(model.Username, model.Password);
                if (AuthenticationManager.LoggedUser == null)
                {
                    ModelState.AddModelError(string.Empty, "Username or password is incorrect!");
                    return View(model);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            if (AuthenticationManager.LoggedUser == null)
            {
                return RedirectToAction("Login", "Home");
            }
            AuthenticationManager.Logout();

            return RedirectToAction("Login", "Home");
        }

        //public ActionResult FakeAdmin()
        //{
        //    PatientsRepository arepo = new PatientsRepository();
        //    Patients a = new Patients();
        //    a.Username = "admin";
        //    a.Password = "admin";
        //    a.LastName = "admin";
        //    a.FirstName = "admin";
        //    a.isDoctor = true;           
        //    arepo.Save(a);
        //    return View();
        //}
    }
}