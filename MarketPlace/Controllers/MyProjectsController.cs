using MarketPlace.Models;
using MarketPlace.Repository;
using System;
using System.Collections.Generic;
using System.IO;
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
            string pathToSave = "";
            string filename = "";
            if (Request.Files[0].ContentLength != 0)
            {
                pathToSave = Server.MapPath("C:/Code/CadFiles/SavedFiles");
                filename = Path.GetFileName(Request.Files[0].FileName);

            }
            model.FileName = filename;
            model.CompanyId = SessionHelper.CompanyId;
            db.CreateProject(model);
            return RedirectToAction("Index");

        }
    }
}