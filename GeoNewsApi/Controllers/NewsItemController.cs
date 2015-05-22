using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace GeoNewsApi.Controllers
{
    [EnableCors("*", "*", "*")]
    public class NewsItemController : ApiController
    {
        ///<summary>Gets all stories in the database</summary>
        // GET: api/NewsItem
        public IEnumerable<Models.NewsItem> Get()
        {
            List<Models.NewsItem> list = new List<Models.NewsItem>();
            foreach (Database.NewsItem item in new Database.Model1().NewsItems)
            {
                list.Add(new Models.NewsItem(item));
            }
            return list;
        }

        ///<summary>Gets story by id</summary>
        ///<param name="id">NewsItem id</param>
        // GET: api/NewsItem/5
        public Models.NewsItem Get(int id)
        {
            Database.NewsItem newsitem = new Database.Model1().NewsItems.Find(id);
            return new Models.NewsItem(newsitem);
        }

        // POST: api/NewsItem
        public void Post(Models.NewsItem newsItem)
        {
            Database.Model1 db = new Database.Model1();
            db.NewsItems.Add(new Database.NewsItem() { HeadLine = newsItem.HeadLine, NewsItemDate = DateTime.Now });
            db.SaveChanges();
        }

        // PUT: api/NewsItem/5
        public void Put(int id, Models.NewsItem value)
        {
            Database.Model1 db = new Database.Model1();
            Database.NewsItem ni = db.NewsItems.Find(id);
            ni.HeadLine = value.HeadLine;
            ni.NewsItemDate = value.StoryDate;
            db.SaveChanges();
        }

        // DELETE: api/NewsItem/5
        public void Delete(int id)
        {
            Database.Model1 db = new Database.Model1();
            Database.NewsItem ni = db.NewsItems.Find(id);
            db.NewsItems.Remove(ni);
            db.SaveChanges();
        }
    }
}
