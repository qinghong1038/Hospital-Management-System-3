using DataAccess.Entities;
using DataAccess.Repositories;
using PatientsDoctorsMS.Filters;
using PatientsDoctorsMS.Models;
using PatientsDoctorsMS.ViewModels.AppointmentsVM;
using PatientsDoctorsMS.ViewModels.Doctors;
using System.Collections.Generic;
using System.Web.Mvc;
using static DataAccess.Entities.Appointments;
using System;

namespace PatientsDoctorsMS.Controllers
{
    [Authenticate]
    public class DoctorsController : BaseController<Appointments, AppointmentsEditVM, AppointmentsListVM>
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
            model.Items = repo.GetAll(a => a.DoctorId == AuthenticationManager.LoggedUser.ID);
        }

        protected override void PopulateEdit(AppointmentsEditVM editmodel, Appointments item)
        {
            editmodel.ID = item.ID;
            editmodel.PatientId = item.PatientId;
            editmodel.DoctorId = item.DoctorId;
            editmodel.AppointmentDate = item.AppointmentDate;
            editmodel.Status = item.Status;

            //UsersRepository urp = new UsersRepository();
            //List<Users> doctorsAll = urp.GetAll(u => u.isDoctor == true);
            //List<SelectListItem> doctors = new List<SelectListItem>();
            //foreach (Users doctor in doctorsAll)
            //{
            //    doctors.Add(new SelectListItem { Text = doctor.ToString(), Value = doctor.ID.ToString() });
            //}
            //editmodel.DoctorsList = doctors;
        }

        protected override void PopulateItem(Appointments item, AppointmentsEditVM editmodel)
        {
            item.ID = editmodel.ID;
            item.PatientId = editmodel.PatientId;
            item.DoctorId = editmodel.DoctorId;
            item.AppointmentDate = editmodel.AppointmentDate;
            item.Status = editmodel.Status;
        }

        public override ActionResult Details(int? id)
        {
            AppointmentsDetailsVM appDetails = new AppointmentsDetailsVM();
            TryUpdateModel(appDetails);
            Appointments appointments = new Appointments();
            AppointmentsRepository appRepo = new AppointmentsRepository();
            appointments = appRepo.GetById(id.Value);

            appDetails.ID = id.Value;
            appDetails.AppointmentDate = appointments.AppointmentDate;
            appDetails.Status = appointments.Status;
            UsersRepository userRepo = new UsersRepository();
            Users patient = userRepo.GetById(appointments.PatientId);
            appDetails.Patient = patient.ToString();
            return View(appDetails);
        }

        [HttpGet]
        public ActionResult Review(int? id)
        {
            AppointmentsRepository appRepo = new AppointmentsRepository();
            Appointments app = appRepo.GetById(id.Value);

            AppointmentReviewVM model = new AppointmentReviewVM()
            {
                ID = app.ID,
                PatientId = app.PatientId,
                DoctorId = app.DoctorId,
                Patient = app.Patient.ToString(),
                AppointmentDate = app.AppointmentDate,
                Status = app.Status
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Review(AppointmentReviewVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            AppointmentsRepository appRepo = new AppointmentsRepository();
            Appointments app = new Appointments()
            {
                ID = model.ID,
                PatientId = model.PatientId,
                DoctorId = model.DoctorId,
                AppointmentDate = model.AppointmentDate
            };
            if (Request.Form["Approve"] != null)
            {
                model = Approve(model);
            }
            else if (Request.Form["Decline"] != null)
            {
                model = Decline(model);
            }
            app.Status = model.Status;
            appRepo.Save(app);
            return RedirectToAction("Index", "Doctors");
        }

        private AppointmentReviewVM Approve(AppointmentReviewVM model)
        {
            model.Status = AppointmentEnum.Approved;
            return model;
        }

        private AppointmentReviewVM Decline(AppointmentReviewVM model)
        {
            model.Status = AppointmentEnum.Unapproved;
            return model;
        }

        protected override Appointments PopulateCreate(Appointments item, AppointmentsEditVM editmodel)
        {
            throw new NotImplementedException();
        }
    }
}