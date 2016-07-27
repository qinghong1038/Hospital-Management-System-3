using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class PatientsDoctorsMSDB<T> : DbContext where T : BaseEntity
    {
        public PatientsDoctorsMSDB()
            : base("name=PatientsDoctorsMSDB")
        {
        }

        public DbSet<T> Items { get; set; }
    }
}