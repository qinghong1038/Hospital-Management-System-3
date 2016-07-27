using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static DataAccess.Entities.Appointments;

namespace PatientsDoctorsMS.ViewModels.AppointmentsVM
{
    public class AppointmentsListVM : BaseListVM<Appointments>
    {
    }
}