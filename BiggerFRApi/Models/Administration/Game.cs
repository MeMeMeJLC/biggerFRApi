using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiggerFRApi.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int LocationId { get; set; }
        public int RefereeID { get; set; }
        public DateTime GameDate { get; set; }
        public DateTime GameTime { get; set; }


        public virtual Location Location { get; set; }
        public virtual Referee Referee { get; set; }
        public virtual ICollection<GamePlayer> GamePlayers { get; set; }
    }
}