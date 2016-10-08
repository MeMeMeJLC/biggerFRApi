using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiggerFRApi.Models
{
    public class Season
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int StartDate { get; set; }
        public int EndDate { get; set; }

        public virtual ICollection<LeagueSeason> LeagueSeasons { get; set; }
    }
}