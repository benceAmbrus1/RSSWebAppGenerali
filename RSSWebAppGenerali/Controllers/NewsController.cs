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
        public ActionResult Index()
        {
            FeedLinkDao linkDb = new FeedLinkDao();
            string userId = User.Identity.GetUserId();
            List<FeedLinkModel> links = linkDb.LoadUserLinks(userId);

            List<RSSItemDTO> dtos = new List<RSSItemDTO>();
            foreach (var feedLink in links)
            {
                RSSItemDTO dto = new RSSItemDTO(
                    RSSService.ReadTitle(feedLink.Link),
                     RSSService.Read(feedLink.Link, 0, userId));
                dtos.Add(dto);
            }
            return View(dtos);
        }
    }
}