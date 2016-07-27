using DataAccess.Entities;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using static DataAccess.Entities.Appointments;

namespace PatientsDoctorsMS.ViewModels.AppointmentsVM
{
    public class AppointmentsEditVM : BaseEditVM
    {
        [Required(ErrorMessage = "Patient ID is required")]
        [Display(Name = "Patient ID")]
        public int PatientId { get; set; }

        [Required(ErrorMessage = "Doctor ID is required")]
        [Display(Name = "Doctor")]
        public int DoctorId { get; set; }

        public string Doctor { get; set; }

        public List<SelectListItem> DoctorsList
        {
            get
            {
                UsersRepository urp = new UsersRepository();
                List<Users> doctorsAll = urp.GetAll(u => u.isDoctor == true);
                List<SelectListItem> doctors = new List<SelectListItem>();
                foreach (Users doctor in doctorsAll)
                {
                    doctors.Add(new SelectListItem { Text = doctor.ToString(), Value = doctor.ID.ToString() });
                }
                return doctors;
            }
        }


        //public List<SelectListItem> DoctorsList { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Appointment Date")]
        public DateTime AppointmentDate { get; set; }

        public AppointmentEnum Status { get; set; }
    }
}