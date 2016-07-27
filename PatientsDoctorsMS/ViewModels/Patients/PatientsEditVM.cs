using DataAccess.Entities;
using PatientsDoctorsMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static DataAccess.Entities.Appointments;

namespace PatientsDoctorsMS.ViewModels.Patients
{
    public class PatientsEditVM : BaseEditVM
    {
        [Required(ErrorMessage = "Patient ID is required")]
        [Display(Name = "Patient ID")]
        public int PatientId { get; set; }

        [Required(ErrorMessage = "Doctor ID is required")]
        [Display(Name = "Doctor")]
        public int DoctorId { get; set; }

        public string Doctor { get; set; }

        public List<SelectListItem> DoctorsList { get; set; }

        public List<DataAccess.Entities.Appointments> appointments;            

        [Display(Name = "Appointment Date")]
        public DateTime AppointmentDate { get; set; }

        public AppointmentEnum Status { get; set; }

        public Pager Pager { get; set; }
    }
}