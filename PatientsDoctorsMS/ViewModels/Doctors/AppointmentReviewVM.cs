using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static DataAccess.Entities.Appointments;

namespace PatientsDoctorsMS.ViewModels.Doctors
{
    public class AppointmentReviewVM : BaseEditVM
    {
        [Display(Name = "Patient ID")]
        public int PatientId { get; set; }

        [Display(Name = "Doctor")]
        public int DoctorId { get; set; }

        public string Doctor { get; set; }

        public string Patient { get; set; }

        [Display(Name = "Appointment Date")]
        public DateTime AppointmentDate { get; set; }

        [Required]
        public AppointmentEnum Status { get; set; }
    }
}