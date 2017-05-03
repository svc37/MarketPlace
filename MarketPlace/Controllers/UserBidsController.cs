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
            string strNumber = model.DisplayPrice.Replace(",", "").Replace("$", "");

            if (Decimal.TryParse(strNumber, out price))
            {
                model.Price = price;
                model.Time = string.Format("{0} {1}", model.Time, model.TimeInterval);
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
                ViewBag.PriceError = "Please do not use words.";
                return View(model);
            }

        }


        [HttpPost]
        public ActionResult EditDecline(BidViewModel model)
        {
            //BidViewModel model = new BidViewModel();
            //model = db.GetBidById(model.id);
            model.DeclineReason = model.DeclineReason;
            model.Declined = true;
            db.EditBid(model);
            return RedirectToAction("Index", "MyProjectBids");
        }

        public ActionResult Edit(int bidId)
        {
            BidViewModel model = new BidViewModel();
            model = db.GetBidById(bidId);
            return View(model);
        }

        //[HttpPost]
        //public ActionResult Edit(BidViewModel model)
        //{

        //}
        //[HttpDelete]
        public ActionResult Delete(int bidId)
        {
            if (db.DeleteBid(bidId))
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Error("There was an error deleting the bid");
                return RedirectToAction("Index");
            }
           
        }

    }
}