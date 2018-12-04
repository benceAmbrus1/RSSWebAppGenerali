using System;
using System.Collections.Generic;
using System.Web.Mvc;
using RSSWebAppGenerali.Services;
using Microsoft.AspNet.Identity;
using RSSWebAppGenerali.Models;
using RSSWebAppGenerali.DAOs;
using RSSWebAppGenerali.DTOs;

namespace RSSWebAppGenerali.Controllers
{
    [Authorize]
    
    public class RSSController : Controller
    {
        // GET: RSS
        // Index called Home on Frontend
        public ActionResult Index()
        {
            FeedLinkDao db = new FeedLinkDao();
            RSSDao rssDb = new RSSDao();
            List<RSSItemDTO> rssList = new List<RSSItemDTO>();

            List<FeedLinkModel> feedLinkModels = db.LoadUserLinks(User.Identity.GetUserId());
            foreach (var feedLinkModel in feedLinkModels)
            {
                if (RSSService.Read(feedLinkModel.Link, 2, User.Identity.GetUserId()) != null)
                {
                    rssList.Add(new RSSItemDTO(RSSService.ReadTitle(feedLinkModel.Link), RSSService.Read(feedLinkModel.Link, 2, User.Identity.GetUserId())));
                }
            }
            ViewBag.Favourites = rssDb.LoadFavouriteRSSItems(User.Identity.GetUserId());
            return View(rssList);
        }
    }
}