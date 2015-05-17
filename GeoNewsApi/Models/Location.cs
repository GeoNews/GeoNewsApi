using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoNewsApi.Models
{
    public class Location
    {
        public Location(Database.Location dbLocation)
        {
            name = dbLocation.Name;
            latitude = dbLocation.Latitude;
            longitude = dbLocation.Longitude;
            id = dbLocation.LocationId;
        }

        public int id { get; set; }

        public string name { get; set; }

        public double latitude { get; set; }

        public double longitude { get; set; }
    }
}
