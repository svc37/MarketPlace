using MarketPlace.Models;
using MarketPlace.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarketPlace.Controllers
{
    public class LogInController : Controller
    {
        DatabaseHelper db = new DatabaseHelper();
        // GET: LogIn
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LogInViewModel model)
        {
            bool success = db.CheckPassword(model);

            if (success)
            {
                SessionHelper.SetCompanyId(db.GetPasswordCompanyId(model.UserName));
                int compId = SessionHelper.CompanyId;
                return RedirectToAction("Index", "User");
            }
            else
            {
                ViewBag.Error = "The password was incorrect";
                return View();
            }

        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(LogInViewModel model)
        {
            UserViewModel uvm = db.GetUserByEmail(model.UserName);
            SessionHelper.SetCompanyId(uvm.Id);


            byte[] salt = Security.GenerateSalt();
            byte[] password = Security.GenerateTextArray(model.PasswordText);

            model.PasswordByte = Security.GenerateSaltedHash(password, salt);
            model.Salt = salt;
            model.CompanyId = SessionHelper.CompanyId;

            db.CreateLogIn(model);

            return RedirectToAction("Index","User");
        }

    }
}