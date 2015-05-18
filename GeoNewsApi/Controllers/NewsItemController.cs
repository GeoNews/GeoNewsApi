using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GeoNewsApi.Controllers
{
    public class NewsItemController : ApiController
    {
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

        // GET: api/NewsItem/5
        public Models.NewsItem Get(int id)
        {
            Database.NewsItem newsitem = new Database.Model1().NewsItems.Find(id);
            return new Models.NewsItem(newsitem);
        }

        //// POST: api/NewsItem
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/NewsItem/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/NewsItem/5
        //public void Delete(int id)
        //{
        //}
    }
}
