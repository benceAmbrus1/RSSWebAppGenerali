using System;
using System.Collections.Generic;
using System.Web.Mvc;
using RSSWebAppGenerali.Services;
using Microsoft.AspNet.Identity;
using RSSWebAppGenerali.Models;
using RSSWebAppGenerali.DAOs;

namespace RSSWebAppGenerali.Controllers
{
    [Authorize]
    public class RSSController : Controller
    {
        // GET: RSS
        public ActionResult Index()
        {
            FeedLinkDao db = new FeedLinkDao();
            List<List<RSSItemModel>> rssList = new List<List<RSSItemModel>>();

            List<FeedLinkModel> feedLinkModels = db.LoadUserLinks(User.Identity.GetUserId());
            foreach (var feedLinkModel in feedLinkModels)
            {
                if (RSSService.Read(feedLinkModel.Link, 2) != null)
                {
                    rssList.Add(RSSService.Read(feedLinkModel.Link, 2));
                }
            }
            return View(rssList);
        }
    }
}