using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoNewsApi.Models
{
    public class Journalist
    {
        public Journalist(Database.Journalist dbJurno)
        {
            FullName = dbJurno.FirstName + " " + dbJurno.LastName;
            id = dbJurno.JournalistId;
        }

        public int id { get; set; }

        public string FullName { get; set; }
    }
}
