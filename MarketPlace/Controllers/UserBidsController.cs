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
            decimal price;
            model.ProjectId = SessionHelper.ProjectId;
            model.SupplierId = SessionHelper.CompanyId;
            string strNumber = model.DisplayPrice.Replace(",", "");

            if (Decimal.TryParse(strNumber, out price))
            {
                model.Price = price;
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
            else
            {
                ViewBag.PriceError = "Please do not use words nor $";
                return View(model);
            }

        }


        [HttpPost]
        public ActionResult Edit(BidViewModel model)
        {
            //BidViewModel model = new BidViewModel();
            //model = db.GetBidById(model.id);
            model.DeclineReason = model.DeclineReason;
            model.Declined = true;
            db.EditBid(model);
            return RedirectToAction("Index", "MyProjectBids");
        }



    }
}