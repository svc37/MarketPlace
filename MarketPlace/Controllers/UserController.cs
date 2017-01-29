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
            model = db.GetUser(SessionHelper.CompanyId);  

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

            if (db.CreateUser(user))
            {
                //if create is successful, user the provided email to grab the record we just saved, so that we can get the ID.
                //we need this ID to associate the login info on the next page. 
                user = db.GetUserByEmail(user.Email);
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
            if (db.EditUser(user))
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
            model = db.GetUser(SessionHelper.CompanyId);  

            return View(model);

        }
    }
}