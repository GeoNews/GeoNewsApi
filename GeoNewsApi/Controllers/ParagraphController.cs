using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using GeoNewsApi.Database;

namespace GeoNewsApi.Controllers
{
    [EnableCors("*","*","*")]
    public class ParagraphController : ApiController
    {
        Model1 db = new Model1();

        public void Post([FromBody]int storyId, [FromBody]string paragraphText) {
            Paragraph p = new Paragraph() { NewsItemId = storyId, Text = paragraphText };
            int paraNo;
            if (db.Paragraphs.Where(e => e.NewsItemId == storyId).Count() == 0)
            {
                paraNo = 1;
            }
            else
            {
                paraNo = db.Paragraphs.Where(e => e.NewsItemId == storyId).OrderByDescending(e => e.ParagraphNumber).First().ParagraphNumber + 1;
            }
            p.ParagraphNumber = paraNo;
            try
            {
                db.Paragraphs.Add(p);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                HttpResponseException httpEx = new HttpResponseException(HttpStatusCode.Conflict);
                throw httpEx;
            }
        }

        public void Delete(int id) {
            db.Paragraphs.RemoveRange(db.Paragraphs.Where(e => e.NewsItemId == id));
            db.SaveChanges();
        }
    }
}
