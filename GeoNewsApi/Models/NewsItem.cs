using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoNewsApi.Models
{
    public class NewsItem
    {
        public NewsItem(Database.NewsItem dbNewsItem)
        {
            this.id = dbNewsItem.NewsItemId;
            this.HeadLine = dbNewsItem.HeadLine;
            this.StoryDate = dbNewsItem.NewsItemDate;
            journalists = new List<Journalist>();
            locations = new List<Location>();
            paragraphs = new List<string>();
            foreach (Database.Paragraph p in dbNewsItem.Paragraphs)
            {
                this.paragraphs.Add(p.Text);
            }
            foreach (Database.Journalist j in dbNewsItem.Journalists)
            {
                journalists.Add(new Journalist(j));
            }
            foreach (Database.Location l in dbNewsItem.Locations)
            {
                locations.Add(new Location(l));
            }
        }

        public int id { get; set; }

        public string HeadLine { get; set; }

        public DateTime StoryDate { get; set; }

        public List<Journalist> journalists { get; set; }

        public List<Location> locations { get; set; }

        public List<string> paragraphs { get; set; }
    }
}
