using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TimeLineBlog.Controllers
{
    public class TimelineController : Controller
    {
        // GET: Timeline
        public ActionResult LoadTimeline(string slug)
        {
            Timeline findTimeLine;
            TimelineEntities db = new TimelineEntities();

            findTimeLine = db.Timelines.Include("Resources").Where(x => x.TimelineSlug == slug).FirstOrDefault();

           var orderedResources = db.Resources.Where(x => x.TimelineId == findTimeLine.TimelineId).OrderByDescending(y => y.DatePublished).ToList();

            ViewBag.Resources = orderedResources;

            return View(findTimeLine);

        }
    }
}