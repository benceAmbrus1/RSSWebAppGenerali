using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RSSWebAppGenerali.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using RSSWebAppGenerali.Models;

namespace RSSWebAppGenerali.Controllers
{
    public class RSSController : Controller
    {
        // GET: RSS
        public ActionResult Index()
        {
            String url = "https://www.gamestar.hu/site/rss/rss.xml";
            ViewBag.UserId = User.Identity.GetUserId();
            List<RSSItemModel> rssList =  RSSService.Read(url);
            return View(rssList);
        }
    }
}