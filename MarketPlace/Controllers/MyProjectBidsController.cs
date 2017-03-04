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
                //these values are null in the DB, but translated into 0 when brought into c#
                if (proj.SupplierId == 0)
                {
                    //Grab bids for the current project "proj"
                    List<BidViewModel> bvm = new List<BidViewModel>();
                    bvm = db.GetBidsByProjectId(proj.Id);
                    //add the bids to the model that was created above
                    foreach (BidViewModel bid in bvm)
                    {
                        if (!bid.Declined)
                        {
                            model.Add(bid);
                        }
                    }
                }

            }
            return View(model);
        }

        public ActionResult Accept(int projectId, int bidId)
        {
            List<BidViewModel> models = new List<BidViewModel>();
            models = db.GetBidsByProjectId(projectId);

            //check each bid for the project
            foreach (BidViewModel bid in models)
            {
                //check for chosen bid.  There can only be one. Highlander!!!
                if (bid.Id == bidId)
                {
                    bid.AcceptedBy = SessionHelper.CurrentUser;
                    bid.AcceptedDate = DateTime.Today;

                    ProjectViewModel proj = new ProjectViewModel();
                    proj = db.GetProjectByProjectId(bid.ProjectId);
                    proj.SupplierId = bid.SupplierId;
                    proj.AcceptedBy = SessionHelper.CurrentUser;
                    proj.AcceptedDate = DateTime.Today;

                    db.EditProject(proj);
                    db.EditBid(bid);
                }
                //if this bid wasn't the chosen one then decline
                else
                {
                    bid.Declined = true;
                    bid.DeclineReason = "Another bid was accepted";

                    db.EditBid(bid);
                }
            }


            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(IEnumerable<BidViewModel> model)
        {
            //BidViewModel model = new BidViewModel();
            //model = db.GetBidById(bidId);
            //model.DeclineReason = model.DeclineReason;
            //model.Declined = true;
            //db.EditBid(model);
            return RedirectToAction("Index", "MyProjectBids");
        }

    }
}