using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiggerFRApi.Models
{
    public class AdministrativeBody
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }

        public virtual ICollection<League> Leagues { get; set; }
    }
}