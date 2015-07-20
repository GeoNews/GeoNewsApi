using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GeoNewsApi.Database;

namespace GeoNewsApi.Controllers
{
    public class HomeController : Controller
    {
        Model1 db = new Model1();

        public ActionResult Index()
        {
            return RedirectToAction("ListStories");
        }

        public ActionResult LinkToLocation(int id)
        {
            ViewBag.StoryId = id;
            ViewBag.Headline = db.NewsItems.Find(id).HeadLine;
            return View(db.Locations);
        }

        public ActionResult ListStories()
        {
            return View(db.NewsItems.OrderByDescending(e => e.NewsItemDate));
        }

        [HttpPost]
        public ActionResult LinkToLocation(int storyId, int locationId)
        {
            Location location = db.Locations.Find(locationId);
            NewsItem newsItem = db.NewsItems.Find(storyId);
            newsItem.Locations.Add(location);
            db.SaveChanges();
            return RedirectToAction("ListStories");
        }

        public ActionResult NewLocation(int? StoryId)
        {
            ViewBag.NewsItemId = -1;
            if (StoryId != null)
            {
                NewsItem newsItem = db.NewsItems.Find(StoryId);
                ViewBag.NewsItemId = StoryId;
                ViewBag.Headline = newsItem.HeadLine;
            }
            return View();
        }

        [HttpPost]
        public ActionResult NewLocation(Location location, int? StoryId)
        {
            db.Locations.Add(location);
            if (StoryId != null)
            {
                NewsItem newsItem = db.NewsItems.Find(StoryId);
                newsItem.Locations.Add(location);
            }
            db.SaveChanges();
            return RedirectToAction("ListStories");
        }
    }
}
