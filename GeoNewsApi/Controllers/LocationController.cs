using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GeoNewsApi.Models;

namespace GeoNewsApi.Controllers
{
    public class LocationController : ApiController
    {
        Database.Model1 db = new Database.Model1();
        // GET: api/Location
        public IEnumerable<StoryLocation> Get()
        {
            return (IEnumerable<StoryLocation>)StoryLocation.GetStoriesFromNewsLocation(db.Locations.ToList());
        }

        // GET: api/Location/5
        public IEnumerable<StoryLocation> Get(int id)
        {
            return (IEnumerable<StoryLocation>)StoryLocation.GetStoriesFromNewsLocation(db.Locations.Find(id));
        }

        //// POST: api/Location
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Location/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Location/5
        //public void Delete(int id)
        //{
        //}
    }
}
