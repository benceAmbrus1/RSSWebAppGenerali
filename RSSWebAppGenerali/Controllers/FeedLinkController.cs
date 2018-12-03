using Microsoft.AspNet.Identity;
using RSSWebAppGenerali.DAOs;
using RSSWebAppGenerali.Models;
using RSSWebAppGenerali.Services;
using System;
using System.Web.Mvc;

namespace RSSWebAppGenerali.Controllers
{
    [Authorize]
    public class FeedLinkController : Controller
    {
        
        public ActionResult Index()
        {
            FeedLinkDao db = new FeedLinkDao();
            ViewBag.FeedList =  db.LoadUserLinks(User.Identity.GetUserId());
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddFeedLink(FeedLinkModel model)
        {
            if(ModelState.IsValid)
            {
                if(RSSService.Read(model.Link) == null)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    FeedLinkDao db = new FeedLinkDao();
                    model.UserId = User.Identity.GetUserId();
                    int records = db.SaveUserLinks(model);
                }
            }
            return RedirectToAction("Index");
        }
        
        
        public ActionResult DeleteFeedLink(int id)
        {
            FeedLinkDao db = new FeedLinkDao();
            db.DeleteUserLink(id);
            return RedirectToAction("Index");
        }
    }
}