using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RSSWebAppGenerali.Controllers
{
    public class RSSController : Controller
    {
        // GET: RSS
        public ActionResult Index()
        {
            return View();
        }
    }
}