using MarketPlace.Models;
using MarketPlace.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarketPlace.Controllers
{
    public class UserController : Controller
    {
        // GET: Shop
        public ActionResult Index()
        {

            UserViewModel model = new UserViewModel();
            DatabaseHelper db = new DatabaseHelper();
            model = db.GetCompany(SessionHelper.CompanyId);  

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserViewModel user)
        {
            DatabaseHelper db = new DatabaseHelper();
            int companyId = db.CreateCompany(user);
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
        public ActionResult Edit(UserViewModel user)
        {
            DatabaseHelper db = new DatabaseHelper();
            if (db.EditCompany(user))
            {
                ViewBag.Message = "Employee details edited successfully";
            }

            return RedirectToAction("Index", "User");
        }


        //public ActionResult Edit()
        //{
        //    return View();
        //}

        public ActionResult Edit()
        {
            UserViewModel model = new UserViewModel();
            DatabaseHelper db = new DatabaseHelper();
            model = db.GetCompany(SessionHelper.CompanyId);  

            return View(model);

        }
    }
}