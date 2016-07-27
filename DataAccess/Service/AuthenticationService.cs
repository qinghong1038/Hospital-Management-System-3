using DataAccess.Entities;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Service
{
    public class AuthenticationService
    {
        public Users LoggedUser { get; private set; }

        public void AuthenticateUser(string username, string password)
        {
            UsersRepository userRepo = new UsersRepository();
            LoggedUser = userRepo.GetAll(u => u.Username == username && u.Password == password).FirstOrDefault();
        }
    }
}
