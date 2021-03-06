﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GeoNewsApi.Controllers
{
    public class LocationController : ApiController
    {
        Database.Model1 db = new Database.Model1();

        // GET: api/Location
        public IEnumerable<Models.Location> Get()
        {
            List<Database.Location> dblocations = db.Locations.ToList();
            List<Models.Location> locations = new List<Models.Location>();
            foreach (Database.Location location in dblocations)
            {
                locations.Add(new Models.Location(location));
            }
            return locations;
        }

        // GET: api/Location/5
        public Models.Location Get(int id)
        {
            return new Models.Location(db.Locations.Find(id));
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
