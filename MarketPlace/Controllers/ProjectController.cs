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
            //We cannot validate if a file was uploaded until the form is submited.  So we check this in our custom file validation method here.  (Repository/ValidateFileAttribute.cs)
            if (ModelState.IsValid)
            {
                //TODO:  Should probably pull this out so it can be used anywhere we need.
                string targetFolder = ConfigHelper.FileSaveLocation;
                targetFolder = string.Format("~{0}", targetFolder);
                string filename = Path.GetFileName(model.CadFile.FileName);
                string savePath = Path.Combine(Server.MapPath(targetFolder), filename);
                model.CadFile.SaveAs(savePath);

                model.FileName = filename;
                model.CompanyId = SessionHelper.CompanyId;
                db.CreateProject(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }


        }

        public ActionResult DownloadFile(string fileName)
        {
            string filepath = Path.Combine(Server.MapPath(ConfigHelper.FileSaveLocation), fileName);
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

        public ActionResult Edit(int id)
        {
            ProjectViewModel model = new ProjectViewModel();
            model = db.GetProjectByProjectId(id);
            return View(model);

        }

    }
}