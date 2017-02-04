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
        // GET: Project
        public ActionResult Index()
        {
            DatabaseHelper db = new DatabaseHelper();
            IEnumerable<ProjectViewModel> model;
            model = db.GetAllProjects();

            return View(model);
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