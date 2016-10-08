using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiggerFRApi.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LocationId { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}