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

        public void AddSingleLink(string title, string link, DateTime datepublished, int timelineId, int feedid, int resourceType = 1)
        {
            TimelineEntities db = new TimelineEntities();

            Resource newResource = new TimeLineBlog.Resource();
            newResource.ResourceTitle = title;
            newResource.ResourceUrl = link;
            newResource.DateAdded = DateTime.Now;
            newResource.DatePublished = datepublished;
            newResource.ResourceType = resourceType;
            newResource.TimelineId = timelineId;
            newResource.FeedId = feedid;

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
        public void PullDownLinksFromFeeds(RSSFeed rssFeed, List<SearchWord> searchwords)
        {
            var r = XmlReader.Create(rssFeed.FeedLink);
            var albums = SyndicationFeed.Load(r);

            foreach (var item in albums.Items)
            {
                var text = item.Title.Text;
                var punctuation = text.Where(Char.IsPunctuation).Distinct().ToArray();
                var words = text.Split().Select(x => x.Trim(punctuation));

                foreach (var word in words)
                {
                    foreach (var searchWord in searchwords)
                    {
                        if (word.ToLower() == searchWord.SearchWordString.ToLower())
                        {
                            if (OnlyAddUniqueArticle(item.Title.Text))
                            {
                                AddSingleLink(item.Title.Text, item.Links[0].Uri.AbsoluteUri, item.PublishDate.UtcDateTime, searchWord.TimelineId, rssFeed.FeedId);
                            }
                        }
                    }
                }
            }
            r.Close();
        }

        public void CheckFeedsForResources()
        {
            using (TimelineEntities db = new TimelineEntities())
            {
                var searchwords = db.SearchWords.ToList();

                var feeds = db.RSSFeeds.ToList();

                foreach (var feed in feeds)
                {
                    PullDownLinksFromFeeds(feed, searchwords);
                }
            }
        }

        public void AddSearchWord(string searchWord, int timeLineId)
        {
            using (TimelineEntities db = new TimelineEntities())
            {
                SearchWord newWord = new SearchWord
                {
                    SearchWordString = searchWord,
                    TimelineId = timeLineId
                };

                db.SearchWords.Add(newWord);
                db.SaveChanges();
            }
        }

        public bool OnlyAddUniqueArticle(string articleTitle)
        {
            using (TimelineEntities db = new TimelineEntities())
            {
                var repeats = db.Resources.Where(x => x.ResourceTitle == articleTitle).FirstOrDefault();

                if (repeats == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void AddTimelineFact(string factText, DateTime factDate, int timelineId, string factSource)
        {
            AddSingleLink("fact", factSource, factDate, timelineId, 6, 2);

        }

    }
}