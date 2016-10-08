using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiggerFRApi.Models
{
    public class GamePlayer
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int GameId { get; set; }
        public bool IsCaptain { get; set; }
        public bool IsSubstitute { get; set; }

        public virtual Player Player { get; set; }
        public virtual Game Game { get; set; }
    }
}