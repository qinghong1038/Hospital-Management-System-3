using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Appointments : BaseEntity
    {
        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public virtual Users Patient { get; set; }

        public virtual Users Doctor { get; set; }

        public DateTime AppointmentDate { get; set; }

        public AppointmentEnum Status { get; set; }
    }

    public enum AppointmentEnum
    {
        Pending,
        Approved,
        Unapproved
    }
}
