using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiggerFRApi.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public double GPSLatitude { get; set; }
        public double GPSLongitude { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}