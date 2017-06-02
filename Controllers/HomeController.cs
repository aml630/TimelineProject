using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TimeLineBlog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Timeline> context;
            using (TimelineEntities db = new TimelineEntities())
            {
                 context = db.Timelines.ToList();
            }

            return View(context);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}