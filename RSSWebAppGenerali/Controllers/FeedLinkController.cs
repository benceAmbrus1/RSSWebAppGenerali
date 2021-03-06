﻿using Microsoft.AspNet.Identity;
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
        // Index called Manage on Frontend
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
                if(RSSService.Read(model.Link, 0, User.Identity.GetUserId()) == null)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    FeedLinkDao db = new FeedLinkDao();
                    model.Title = RSSService.ReadTitle(model.Link);
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