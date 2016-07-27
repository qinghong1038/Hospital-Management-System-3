using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PatientsDoctorsMS
{
    public class PatientsDoctorsMVCDB : DbContext
    {
        public PatientsDoctorsMVCDB():base("name=PatientsDoctorsMSDB")
        {
        }

        public DbSet<Users> Users { get; set; }  

        public DbSet<Appointments> Appointments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointments>().HasRequired(m => m.Doctor).WithMany().HasForeignKey(m => m.DoctorId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Appointments>().HasRequired(m => m.Patient).WithMany().HasForeignKey(m => m.PatientId).WillCascadeOnDelete(false);
        }

        public System.Data.Entity.DbSet<PatientsDoctorsMS.ViewModels.AppointmentsVM.AppointmentsDetailsVM> AppointmentsDetailsVMs { get; set; }
    }
} 