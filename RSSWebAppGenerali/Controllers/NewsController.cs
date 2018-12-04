using Microsoft.AspNet.Identity;
using RSSWebAppGenerali.DAOs;
using RSSWebAppGenerali.DTOs;
using RSSWebAppGenerali.Models;
using RSSWebAppGenerali.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RSSWebAppGenerali.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        // Index called News on Frontend
        public ActionResult Index()
        {
            FeedLinkDao linkDb = new FeedLinkDao();
            RSSDao rssDb = new RSSDao();

            string userId = User.Identity.GetUserId();
            List<FeedLinkModel> links = linkDb.LoadUserLinks(userId);

            List<RSSItemDTO> dtos = new List<RSSItemDTO>();
            foreach (var feedLink in links)
            {
                RSSItemDTO dto = new RSSItemDTO( feedLink.Title, rssDb.LoadRSSItems(userId, feedLink.Link));
                dtos.Add(dto);
            }
            return View(dtos);
        }

        public ActionResult SetFavourite(int id)
        {
            RSSDao db = new RSSDao();
            db.SetFavourite(id);

            return RedirectToAction("Index");
        }
    }
}