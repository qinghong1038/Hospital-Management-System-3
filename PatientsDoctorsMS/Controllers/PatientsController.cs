using DataAccess.Entities;
using DataAccess.Repositories;
using PatientsDoctorsMS.Filters;
using PatientsDoctorsMS.Models;
using PatientsDoctorsMS.ViewModels.AppointmentsVM;
using PatientsDoctorsMS.ViewModels.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace PatientsDoctorsMS.Controllers
{
    [Authenticate]
    public class PatientsController : BaseController<Appointments, AppointmentsEditVM, AppointmentsListVM>
    {
        protected override AppointmentsListVM CreateBaseListVM()
        {
            return new AppointmentsListVM();
        }

        protected override BaseRepository<Appointments> CreateRepository()
        {
            return new AppointmentsRepository();
        }

        protected override void PopulateIndex(AppointmentsListVM model)
        {
            TryUpdateModel(model);
            BaseRepository<Appointments> repo = CreateRepository();
            model.Items = repo.GetAll(a => a.PatientId == AuthenticationManager.LoggedUser.ID);

            //if (!string.IsNullOrEmpty(model.searchString)) // Search
            //{
            //    model.Items = repo.GetAll(u => u.Doctor.Name.Contains(model.searchString));
            //}

            //Expression<Func<Appointments, bool>> filter = null;

            //if (string.IsNullOrEmpty(model.searchString))
            //{
            //    model.Items = repo.GetAll();
            //}
            //else
            //{
            //    string[] searchArray = model.searchString.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            //    filter = a => (searchArray.Any(word => a.Doctor.Name.Contains(word)));
            //    model.Items = repo.GetAll(filter);
            //}
            model.Pager = new Pager(model.Items.Count, model.Pager == null ? 1 : model.Pager.CurrentPage, "Pager.", "Index","Patients", model.Pager == null ? 3 : model.Pager.PageSize);
            model.Items = model.Items.Skip((model.Pager.CurrentPage - 1) * model.Pager.PageSize).Take(model.Pager.PageSize).ToList();
        }

        protected override void PopulateEdit(AppointmentsEditVM editmodel, Appointments item)
        {
            editmodel.ID = item.ID;
            editmodel.PatientId = item.PatientId;
            editmodel.DoctorId = item.DoctorId;
            editmodel.AppointmentDate = item.AppointmentDate;
            editmodel.Status = item.Status;

        //    UsersRepository urp = new UsersRepository();
        //    List<Users> doctorsAll = urp.GetAll(u => u.isDoctor == true);
        //    List<SelectListItem> doctors = new List<SelectListItem>();
        //    foreach (Users doctor in doctorsAll)
        //    {
        //        doctors.Add(new SelectListItem { Text = doctor.ToString(), Value = doctor.ID.ToString() });
        //    }
        //    editmodel.DoctorsList = doctors;
        }

        protected override void PopulateItem(Appointments item, AppointmentsEditVM editmodel)
        {
            item.ID = editmodel.ID;
            item.PatientId = editmodel.PatientId;
            item.DoctorId = editmodel.DoctorId;
            item.AppointmentDate = editmodel.AppointmentDate;
            item.Status = editmodel.Status;
        }

        protected override Appointments PopulateCreate(Appointments item, AppointmentsEditVM editmodel)
        {
            item.ID = editmodel.ID;
            item.PatientId = editmodel.PatientId;
            item.DoctorId = editmodel.DoctorId;
            item.AppointmentDate = editmodel.AppointmentDate;
            item.Status = editmodel.Status;

            AppointmentsRepository repo = new AppointmentsRepository();
            Appointments appointment = repo.GetAll(a => (a.AppointmentDate == item.AppointmentDate && a.DoctorId == item.DoctorId)).FirstOrDefault();

            if (appointment != null)
            {
                item = null;
                ModelState.AddModelError(string.Empty, "This appointment hour is already taken");
            }

            return item;
        }

        public ActionResult Create()
        {
            AppointmentsEditVM appEdit = new AppointmentsEditVM();

            Appointments app = new Appointments();
            appEdit.PatientId = AuthenticationManager.LoggedUser.ID;

            //UsersRepository urp = new UsersRepository();
            //List<Users> doctorsAll = urp.GetAll(u => u.isDoctor == true);
            //List<SelectListItem> doctors = new List<SelectListItem>();
            //foreach (Users doctor in doctorsAll)
            //{
            //    doctors.Add(new SelectListItem { Text = doctor.ToString(), Value = doctor.ID.ToString() });
            //}
            //appEdit.DoctorsList = doctors;

            return View("~/Views/Patients/Edit.cshtml", appEdit);
        }

        public override ActionResult Details(int? id)
        {
            AppointmentsDetailsVM appDet = new AppointmentsDetailsVM();
            TryUpdateModel(appDet);
            Appointments appointments = new Appointments();
            AppointmentsRepository asp = new AppointmentsRepository();
            appointments = asp.GetById(id.Value);

            appDet.ID = id.Value;
            appDet.Doctor = appointments.Doctor.Username;
            appDet.AppointmentDate = appointments.AppointmentDate;
            appDet.Status = appointments.Status;
            return View(appDet);
        }

        //[HttpGet]
        //public new ActionResult Request(int? id)
        //{
        //    AppointmentRequestVM model = new AppointmentRequestVM();
        //    UsersRepository userRepo = new UsersRepository();
        //    List<Users> doctorsAll = userRepo.GetAll(u => u.isDoctor == true);
        //    List<SelectListItem> doctors = new List<SelectListItem>();
        //    foreach (Users doctor in doctorsAll)
        //    {
        //        doctors.Add(new SelectListItem { Text = doctor.ToString(), Value = doctor.ID.ToString() });
        //    }
        //    model.DoctorsList = doctors;
        //    return View(model);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public new ActionResult Request(AppointmentRequestVM model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        //    Appointments app = new Appointments()
        //    {
        //        ID = model.ID,
        //        PatientId = AuthenticationManager.LoggedUser.ID,
        //        DoctorId = model.DoctorId,
        //        AppointmentDate = model.AppointmentDate
        //    };

        //    AppointmentsRepository repo = new AppointmentsRepository();

        //    Appointments appointment = repo.GetAll(a => (a.AppointmentDate == app.AppointmentDate && a.DoctorId == app.DoctorId)).FirstOrDefault();

        //    if (appointment == null)
        //    {
        //        repo.Save(app);
        //    }
        //    else
        //    {
        //        ModelState.AddModelError(string.Empty, "This appointmnet hour is already taken");
        //        return View(model);
        //    }

        //    return RedirectToAction("Index", "Patients");            
        //}

        [HttpGet]
        public new ActionResult Request(int? id)
        {
            AppointmentRequestVM model = new AppointmentRequestVM();
            UsersRepository userRepo = new UsersRepository();
            List<Users> doctorsAll = userRepo.GetAll(u => u.isDoctor == true);
            List<SelectListItem> doctors = new List<SelectListItem>();
            foreach (Users doctor in doctorsAll)
            {
                doctors.Add(new SelectListItem { Text = doctor.ToString(), Value = doctor.ID.ToString() });
            }
            model.DoctorsList = doctors;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public new ActionResult Request(AppointmentRequestVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            Appointments app = new Appointments()
            {
                ID = model.ID,
                PatientId = AuthenticationManager.LoggedUser.ID,
                DoctorId = model.DoctorId,
                AppointmentDate = model.AppointmentDate
            };
            return View();
        }
    }
}