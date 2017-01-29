using MarketPlace.Models;
using MarketPlace.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarketPlace.Controllers
{
    public class UserBidsController : Controller
    {
        DatabaseHelper db = new DatabaseHelper();
        // GET: UserBids
        public ActionResult Index()
        {
            List<BidViewModel> model = new List<BidViewModel>();
            DatabaseHelper db = new DatabaseHelper();

            model = db.GetBidsByCompanyId(SessionHelper.CompanyId);
            return View(model);
        }

        public ActionResult Create(int projectId)
        {
            SessionHelper.SetProjectId(projectId);
            return View();
        }

        [HttpPost]
        public ActionResult Create(BidViewModel model)
        {
            model.ProjectId = SessionHelper.ProjectId;
            model.SupplierId = SessionHelper.CompanyId;

            if (db.CreateBid(model))
            {
                return RedirectToAction("Index", "UserBids");
            }
            else
            {
                ViewBag.Error = "There was an error";
                return View();
            }
        }


    }
}