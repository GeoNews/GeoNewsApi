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
        }

        public string name { get; set; }
    }
}
