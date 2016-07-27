using DataAccess.Entities;
using DataAccess.Repositories;
using PatientsDoctorsMS.Models;
using PatientsDoctorsMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientsDoctorsMS.Controllers
{
    public abstract class BaseController<T, E, L> : Controller
    where T : BaseEntity, new()
    where E : BaseEditVM, new()
    where L : BaseListVM<T>
    {
        protected abstract L CreateBaseListVM();

        protected abstract BaseRepository<T> CreateRepository();

        protected virtual void PopulateIndex(L model)
        {
            TryUpdateModel(model);
            BaseRepository<T> repo = CreateRepository();
            model.Items = repo.GetAll();
        }

        protected virtual void PopulateEdit(E editmodel, T item) { }

        protected virtual void PopulateItem(T item, E editmodel) { }

        protected abstract T PopulateCreate(T item, E editmodel);

        public ActionResult Index()
        {
            L model = CreateBaseListVM();
            PopulateIndex(model);           
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(E editmodel)
        {
            if (ModelState.IsValid)
            {
                T item = new T();
                BaseRepository<T> repo = CreateRepository();
                item = PopulateCreate(item, editmodel);
                if (item != null)
                {
                    repo.Save(item);
                }

                else
                {
                    return View("~/Views/Patients/Edit.cshtml", editmodel);
                }
                return RedirectToAction("Index");
            }
            return View("~/Views/Patients/Edit.cshtml", editmodel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            E editmodel = new E();
            T item = new T();
            BaseRepository<T> repo = CreateRepository();
            item = repo.GetById(id);
            PopulateEdit(editmodel, item);
            return View(editmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(E editmodel)
        {
            if (ModelState.IsValid)
            {
                T item = new T();
                PopulateItem(item, editmodel);
                BaseRepository<T> repo = CreateRepository();
                repo.Save(item);
                return RedirectToAction("Index");
            }
            return View(editmodel);
        }

        public virtual ActionResult Details(int? id)
        {
            E editmodel = new E();
            T item = new T();
            BaseRepository<T> repo = CreateRepository();
            item = repo.GetById(id.Value);
            PopulateEdit(editmodel, item);
            return View(editmodel);
        }

        public ActionResult Delete(int id)
        {
            BaseRepository<T> repo = CreateRepository();
            T item = repo.GetById(id);
            repo.Delete(item);
            return RedirectToAction("Index");
        }
    }
}