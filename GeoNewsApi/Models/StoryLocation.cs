using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoNewsApi.Models
{
    public class StoryLocation
    {
        public StoryLocation(Database.Location location, Database.NewsItem newsItem)
        {
            id = location.LocationId + "-" + newsItem.NewsItemId;
            HeadLine = newsItem.HeadLine;
            Latitude = location.Latitude;
            Longitude = location.Longitude;
            StoryDate = newsItem.NewsItemDate;
            Journalists = new List<string>();
            foreach (Database.Journalist j in newsItem.Journalists)
            {
                Journalists.Add(j.FirstName + " " + j.LastName);
            }
        }

        public string id { get; set; }

        public string HeadLine { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public DateTime StoryDate { get; set; }

        public List<string> Journalists { get; set; }

        public string StoryText { get; set; }

        public static List<StoryLocation> GetStoriesFromNewsLocation(Database.Location location)
        {
            List<StoryLocation> stories = new List<StoryLocation>();
            foreach (Database.NewsItem newsItem in location.NewsItems)
            {
                stories.Add(new StoryLocation(location,newsItem));
            }
            return stories;
        }

        public static List<StoryLocation> GetStoriesFromNewsLocation(List<Database.Location> locations)
        {
            List<StoryLocation> stories = new List<StoryLocation>();
            foreach (Database.Location location in locations)
            {
                stories.AddRange(GetStoriesFromNewsLocation(location));
            }
            return stories;
        }
    }
}
