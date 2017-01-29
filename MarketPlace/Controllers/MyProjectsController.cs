using MarketPlace.Models;
using MarketPlace.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarketPlace.Controllers
{
    public class MyProjectsController : Controller
    {
        DatabaseHelper db = new DatabaseHelper();

        // GET: MyProjects
        public ActionResult Index()
        {
            IEnumerable<ProjectViewModel> model;
            model = db.GetProjectsByCompanyId(SessionHelper.CompanyId);
            if (!model.Any())
            {
                ViewBag.NoProjects = "You have no active projects";
                return View();
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProjectViewModel model)
        {
            model.CompanyId = SessionHelper.CompanyId;
            db.CreateProject(model);
            return RedirectToAction("Index");

        }
    }
}