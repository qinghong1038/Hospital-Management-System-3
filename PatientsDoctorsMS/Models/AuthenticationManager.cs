using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientsDoctorsMS.Models
{
    public class AuthenticationManager
    {
        public static bool IsLogged
        {
            get { return LoggedUser != null; }
        }

        public static Users LoggedUser
        {
            get
            {
                DataAccess.Service.AuthenticationService authenticationService = null;

                if (HttpContext.Current != null && HttpContext.Current.Session["LoggedUser"] == null)
                    HttpContext.Current.Session["LoggedUser"] = new DataAccess.Service.AuthenticationService();

                authenticationService = (DataAccess.Service.AuthenticationService)HttpContext.Current.Session["LoggedUser"];
                return authenticationService.LoggedUser;
            }
        }

        public static void Authenticate(string username, string password)
        {
            DataAccess.Service.AuthenticationService authenticationService = null;

            if (HttpContext.Current != null && HttpContext.Current.Session["LoggedUser"] == null)
                HttpContext.Current.Session["LoggedUser"] = new DataAccess.Service.AuthenticationService();

            authenticationService = (DataAccess.Service.AuthenticationService)HttpContext.Current.Session["LoggedUser"];
            authenticationService.AuthenticateUser(username, password);
        }
        public static void Logout()
        {
            HttpContext.Current.Session["LoggedUser"] = null;
        }
    }
}