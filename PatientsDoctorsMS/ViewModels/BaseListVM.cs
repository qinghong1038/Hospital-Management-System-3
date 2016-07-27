using DataAccess.Entities;
using PatientsDoctorsMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientsDoctorsMS.ViewModels
{
    public class BaseListVM<Entity> where Entity : BaseEntity
    {
        public List<Entity> Items { get; set; }

        public Pager Pager { get; set; }

        public string searchString { get; set; }
    }
}