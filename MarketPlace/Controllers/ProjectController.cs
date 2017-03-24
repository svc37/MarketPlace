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
    public class ProjectController : Controller
    {
        DatabaseHelper db = new DatabaseHelper();

        // GET: Project
        public ActionResult Index()
        {
            IEnumerable<ProjectViewModel> model;
            model = db.GetAllProjects();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(ProjectViewModel model)
        {
            string targetFolder = ConfigHelper.FileSaveLocation;
            string filename = Path.GetFileName(model.CadFile.FileName);
            string savePath = Path.Combine(targetFolder, filename);
            model.CadFile.SaveAs(savePath);

            model.FileName = filename;
            model.CompanyId = SessionHelper.CompanyId;
            db.CreateProject(model);
            return RedirectToAction("Index");

        }


        public ActionResult DownloadFile(string fileName)
        {
            string filepath = Path.Combine(ConfigHelper.FileSaveLocation, fileName);
            byte[] filedata = System.IO.File.ReadAllBytes(filepath);
            string contentType = MimeMapping.GetMimeMapping(filepath);

            var cd = new System.Net.Mime.ContentDisposition
            {
                FileName = fileName,
                Inline = true,
            };

            Response.AppendHeader("Content-Disposition", cd.ToString());

            return File(filedata, contentType);
        }

        // GET: MyProjects
        public ActionResult MyProjects()
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