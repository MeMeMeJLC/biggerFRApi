using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiggerFRApi.Models
{
    public class Goal
    {
        public int Id { get; set; }
        public bool IsOwnGoal { get; set; }
        public int GamePlayerId { get; set; }
        public TimeSpan GoalTime { get; set; }

        public GamePlayer GamePlayer { get; set; }
    }
}