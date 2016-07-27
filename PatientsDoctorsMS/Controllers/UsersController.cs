using DataAccess.Entities;
using DataAccess.Repositories;
using PatientsDoctorsMS.Filters;
using PatientsDoctorsMS.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace PatientsDoctorsMS.Controllers
{
    [Authenticate]
    public class UsersController : BaseController<Users, UsersEditVM, UsersListVM>
    {
        protected override UsersListVM CreateBaseListVM()
        {
            return new UsersListVM();
        }

        protected override BaseRepository<Users> CreateRepository()
        {
            return new UsersRepository();
        }

        protected override void PopulateIndex(UsersListVM model)
        {
            TryUpdateModel(model);
            BaseRepository<Users> repo = CreateRepository();

            //Expression<Func<Users, bool>> filter = null;

            //if (string.IsNullOrEmpty(model.searchString))
            //{
            //    model.Items = repo.GetAll();
            //}
            //else
            //{
            //    string[] searchArray = model.searchString.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            //    filter = u => (searchArray.Any(word => u.FirstName.Contains(word))
            //                || searchArray.Any(word => u.LastName.Contains(word))
            //                || searchArray.Any(word => u.Username.Contains(word)));
            //    model.Items = repo.GetAll(filter);
            //}
            model.Items = repo.GetAll();
        }

        protected override void PopulateEdit(UsersEditVM editmodel, Users item)
        {
            editmodel.ID = item.ID;
            editmodel.Username = item.Username;
            editmodel.Password = item.Password;
            editmodel.FirstName = item.FirstName;
            editmodel.LastName = item.LastName;        
        }

        protected override void PopulateItem(Users item, UsersEditVM editmodel)
        {
            item.ID = editmodel.ID;
            item.Username = editmodel.Username;
            item.Password = editmodel.Password;
            item.FirstName = editmodel.FirstName;
            item.LastName = editmodel.LastName;           
        }

        protected override void PopulateCreate(Users item, UsersEditVM editmodel)
        {
            item.ID = editmodel.ID;
            item.Username = editmodel.Username;
            item.Password = editmodel.Password;
            item.FirstName = editmodel.FirstName;
            item.LastName = editmodel.LastName;           
        }

        public ActionResult Create()
        {
            return View("~/Views/Users/Edit.cshtml");
        }
    }
}