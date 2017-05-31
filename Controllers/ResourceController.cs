using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.ServiceModel.Syndication;

namespace TimeLineBlog.Controllers
{
    public class ResourceController : Controller
    {
        public void GetLinksFromNewsSites()
        {

        }

        public void AddSingleLink(string title, string link, int timelineId)
        {
            TimelineEntities db = new TimelineEntities();

            Resource newResource = new TimeLineBlog.Resource();
            newResource.ResourceTitle = title;
            newResource.ResourceUrl = link;
            newResource.DateAdded = DateTime.Now;
            newResource.DatePublished = DateTime.Now;
            newResource.ResourceType = 1;
            newResource.TimelineId = timelineId;

            db.Resources.Add(newResource);
            db.SaveChanges();
        }

        public void AddTimeline (string title, string image, string slug)
        {
            TimelineEntities db = new TimelineEntities();

            Timeline timLin = new Timeline();

            timLin.TimelineImage = image;
            timLin.TimelineTitle = title;
            timLin.TimelineSlug = slug;

            db.Timelines.Add(timLin);
            db.SaveChanges();
        }

        public void InsertAssetIntoTimeline()
        {

        }
        public void PullDownLinksFromFeeds ()
        {
            var r = XmlReader.Create("https://fivethirtyeight.com/all/feed");
            var albums = SyndicationFeed.Load(r);

            foreach (var item in albums.Items)
            {
                AddSingleLink(item.Title.Text, item.Links[0].Uri.AbsoluteUri, 1);
            }


            r.Close();
        }


    }
}