using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiggerFRApi.Models
{
    public class LeagueSeason
    {
        public int Id { get; set; }
        public int LeagueId { get; set; }
        public int SeasonId { get; set; }

        public virtual League League { get; set; }
        public virtual Season Season { get; set; }
    }
}