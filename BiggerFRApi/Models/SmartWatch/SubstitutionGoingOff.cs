using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiggerFRApi.Models
{
    public class SubstitutionGoingOff
    {
        public int Id { get; set; }
        public int GamePlayerId { get; set; }

        public virtual GamePlayer GamePlayer { get; set; }
    }
}