using PatientsDoctorsMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientsDoctorsMS.Filters
{
    public class AuthenticateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!AuthenticationManager.IsLogged)
            {
                filterContext.Result = new RedirectResult("~/Home/Login?RedirectUrl=" + HttpUtility.UrlEncode(HttpContext.Current.Request.Url.ToString()));
            }
        }
    }
}