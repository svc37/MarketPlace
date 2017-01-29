using MarketPlace.Models;
using MarketPlace.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarketPlace.Controllers
{
    public class MyProjectBidsController : Controller
    {
        DatabaseHelper db = new DatabaseHelper();

        // GET: MyProjectBids
        public ActionResult Index()
        {
            List<BidViewModel> model = new List<BidViewModel>();
            //get all projects associated with the company
            List<ProjectViewModel> projs = db.GetProjectsByCompanyId(SessionHelper.CompanyId);

            // check each project and see if there are any that don't have an accepted bid
            foreach (ProjectViewModel proj in projs)
            {
                if (proj.SupplierId == 0)
                {
                    //Grab bids for the current project "proj"
                    List<BidViewModel> bvm = new List<BidViewModel>();
                    bvm = db.GetBidsByProjectId(proj.Id);
                    //add the bids to the model that was created above
                    foreach (BidViewModel bid in bvm)
                    {
                        model.Add(bid);
                    }
                }

            }
            return View(model);
        }
    }
}