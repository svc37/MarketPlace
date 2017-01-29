using MarketPlace.Models;
using MarketPlace.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarketPlace.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Index()
        {
            DatabaseHelper db = new DatabaseHelper();
            IEnumerable<ProjectViewModel> model;
            model = db.GetAllProjects();

            return View(model);
        }

        #region Maybe Not Needed
        //public ActionResult Create()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Create(ProjectViewModel model)
        //{

        //    return RedirectToAction("Index");
        //}

        //public ActionResult Edit()
        //{

        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Edit(ProjectViewModel model)
        //{

        //    return RedirectToAction("Index");
        //}

        //public ActionResult ProjectList(ProjectViewModel model)
        //{

        //    return RedirectToAction("Index");
        //}
        #endregion
    }
}