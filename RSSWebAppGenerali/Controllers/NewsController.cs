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
            string userId = User.Identity.GetUserId();
            RSSService service = new RSSService();
            
            return View(service.ReturnUserAllRssWithTitle(userId));
        }

        public ActionResult SetFavourite(int id)
        {
            RSSDao db = new RSSDao();
            db.SetFavourite(id);

            return RedirectToAction("Index");
        }

        
        public ActionResult GetRSSByTitle(string title)
        {
            if(title == "All")
            {
                string userId = User.Identity.GetUserId();
                RSSService service = new RSSService();

                return Json(service.ReturnUserAllRssWithTitle(userId), JsonRequestBehavior.AllowGet);
            }
            else
            {
                FeedLinkDao linkDb = new FeedLinkDao();
                RSSDao rssDb = new RSSDao();
                string userId = User.Identity.GetUserId();

                List<FeedLinkModel> FeedLink = linkDb.LoadUserLinks(userId, title);
                List<RSSItemDTO> dtos = new List<RSSItemDTO>();

                dtos.Add( new RSSItemDTO(title, rssDb.LoadRSSItems(userId, FeedLink[0].Link)));
                return Json(dtos, JsonRequestBehavior.AllowGet);
            }
        }
    }
}