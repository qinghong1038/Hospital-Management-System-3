using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Users : BaseEntity
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool isDoctor { get; set; }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
                
        public virtual string Name
        {
            get { return FirstName + " " + LastName; }
        }

        //public UsersMSEnum UsersRole { get; set; }      

        //public enum UsersMSEnum
        //{
        //    Doctors,
        //    Patients
        //}
    }
}
