using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static DataAccess.Entities.Appointments;

namespace PatientsDoctorsMS.ViewModels.Patients
{
    public class PatientsDetailsVM : BaseEditVM
    {
        [Required]
        public string Doctor { get; set; }

        [Required]
        [Display(Name = "Appointment Date")]
        public DateTime AppointmentDate { get; set; }

        [Required]
        public AppointmentEnum Status { get; set; }
    }
}