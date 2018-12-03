using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RSSWebAppGenerali.Services;

namespace RSSWebAppGenerali.Controllers
{
    public class RSSController : Controller
    {
        // GET: RSS
        public ActionResult Index()
        {
            String url = "https://www.gamestar.hu/site/rss/rss.xml";
            ViewBag.listRssItems = RSSService.Read(url);
            return View();
        }
    }


}