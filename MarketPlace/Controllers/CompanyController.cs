using MarketPlace.Models;
using MarketPlace.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarketPlace.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Shop
        public ActionResult Index()
        {

            CompanyViewModel model = new CompanyViewModel();
            DatabaseHelper db = new DatabaseHelper();
            model = db.GetCompany(SessionHelper.CompanyId);  

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CompanyViewModel company)
        {
            DatabaseHelper db = new DatabaseHelper();
            int companyId = db.CreateCompany(company);
            if (companyId > 0)
            {

                //user = db.GetUser(companyId);
                SessionHelper.SetCompanyId(companyId); 
               return RedirectToAction("Create", "LogIn");
            }
            else
            {
                return View(); //TODO: Need to add an Error Handling Page
            }
        }

        [HttpPost]
        public ActionResult Edit(CompanyViewModel company)
        {
            DatabaseHelper db = new DatabaseHelper();
            if (db.EditCompany(company))
            {
                ViewBag.Message = "Employee details edited successfully";
            }

            return RedirectToAction("Index", "Company");
        }


        //public ActionResult Edit()
        //{
        //    return View();
        //}

        public ActionResult Edit()
        {
            CompanyViewModel model = new CompanyViewModel();
            DatabaseHelper db = new DatabaseHelper();
            model = db.GetCompany(SessionHelper.CompanyId);  

            return View(model);

        }
    }
}