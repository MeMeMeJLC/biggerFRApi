using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiggerFRApi.Models
{
    public class Substitution
    {
        public int Id { get; set; }
        public int SubstitutionGoingOnId { get; set; }
        public int SubstitutionGoingOffId { get; set; }
        public TimeSpan SubstitutionTime { get; set; }

        public virtual SubstitutionGoingOn SubstitutionGoingOn { get; set; }
        public virtual SubstitutionGoingOff SubstitutionGoingOff { get; set; }

    }
}