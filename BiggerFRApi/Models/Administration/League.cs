using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiggerFRApi.Models
{
    public class League
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Grade { get; set; }
        public string Region { get; set; }
        public int AdministrativeBodyId { get; set; }

        public virtual AdministrativeBody AdministrativeBody { get; set; }
        public virtual ICollection<LeagueSeason> LeagueSeasons { get; set; }
    }
}