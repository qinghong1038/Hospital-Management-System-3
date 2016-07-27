using DataAccess.Entities;
using DataAccess.Repositories;
using PatientsDoctorsMS.Filters;
using PatientsDoctorsMS.Models;
using PatientsDoctorsMS.ViewModels.AppointmentsVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientsDoctorsMS.Controllers
{
    //public class AppointmentsController : Controller
    //{
    //    // GET: Appointments
    //    public ActionResult Index()
    //    {
    //        AppointmentsRepository appointmentsRepo = new AppointmentsRepository();
    //        AppointmentsListVM model = new AppointmentsListVM();
    //        model.Items = appointmentsRepo.GetAll(a => a.PatientId == AuthenticationManager.LoggedUser.ID);
    //        return View(model);
    //    }

    //    public ActionResult Details()
    //    {
    //        AppointmentsRepository appointmentsRepo = new AppointmentsRepository();
    //        AppointmentsDetailsVM model = new AppointmentsDetailsVM();
    //        model.Items = appointmentsRepo.GetAll(a => a.PatientId == AuthenticationManager.LoggedUser.ID);
    //        return View(model);
    //    }
    //}


    //[Authenticate]
    //public class AppointmentsController : BaseController<Appointments, AppointmentsEditVM, AppointmentsListVM>
    //{
    //    protected override AppointmentsListVM CreateBaseListVM()
    //    {
    //        return new AppointmentsListVM();
    //    }

    //    protected override BaseRepository<Appointments> CreateRepository()
    //    {
    //        return new PatientsRepository();
    //    }

    //    protected override void PopulateIndex(AppointmentsListVM model)
    //    {
    //        TryUpdateModel(model);
    //        BaseRepository<Appointments> repo = CreateRepository();

            //Predicate<Appointments> filter = null;

            //if (string.IsNullOrEmpty(model.searchString))
            //{
            //    model.Items = repo.GetAll();
            //}

            //else
            //{
            //    string[] searchArray = model.searchString.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            //    filter = u => (searchArray.Any(word => u.FirstName.Contains(word))
            //                || searchArray.Any(word => u.LastName.Contains(word))
            //                || searchArray.Any(word => u.Username.Contains(word)));

            //    model.Items = repo.GetAll(filter);
            //}          
          
        //    model.Items = repo.GetAll(a => a.PatientId == AuthenticationManager.LoggedUser.ID);
        //}

        //protected override void PopulateEdit(AppointmentsEditVM editmodel, Appointments item)
        //{
        //    editmodel.ID = item.ID;
        //    editmodel.AppointmentDate = item.AppointmentDate;
        //    editmodel.Status = item.Status;           
        //}

        //protected override void PopulateItem(Appointments item, AppointmentsEditVM editmodel)
        //{
        //    item.ID = editmodel.ID;
        //    item.AppointmentDate = editmodel.AppointmentDate;
        //    item.Status = editmodel.Status;
        //}

        //protected override void PopulateCreate(Appointments item, AppointmentsEditVM editmodel)
        //{
        //    item.ID = editmodel.ID;
        //    //item.DoctorId = editmodel.Doctor;
        //    item.AppointmentDate = editmodel.AppointmentDate;
        //    item.Status = editmodel.Status;
        //}

        //public ActionResult Create()
        //{
        //    AppointmentsEditVM appEdit = new AppointmentsEditVM();
        //    PatientsRepository asp = new PatientsRepository();
        //    List<Appointments> appointmentslist = asp.GetAll();
        //    appEdit.appointments = new List<Appointments>();
        //    foreach (var item in appointmentslist)
        //    {
        //        appEdit.appointments.Add(item);
        //    }
        //    appEdit.PatientId = PatientsDoctorsMS.Models.AuthenticationManager.LoggedUser.ID;
        //    return View("~/Views/Appointments/Edit.cshtml", appEdit);
        //}

        //public override ActionResult Details(int id)
        //{
        //    AppointmentsDetailsVM appDet = new AppointmentsDetailsVM();
        //    TryUpdateModel(appDet);
        //    Appointments appointment = new Appointments();
        //    PatientsRepository asp = new PatientsRepository();
        //    appointment = asp.GetById(id);

        //    appDet.ID = id;
        //    appDet.Doctor = appointment.Doctor.Username;
        //    appDet.AppointmentDate = appointment.AppointmentDate;
        //    appDet.Status = appointment.Status;
        //    return View(appDet);
        //}

        //public ActionResult Create()
        //{
        //    return View("~/Views/Appointments/Edit.cshtml");
        //}
    //}
}