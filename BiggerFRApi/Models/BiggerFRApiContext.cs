using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace BiggerFRApi.Models
{
    public class BiggerFRApiContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public BiggerFRApiContext() : base("name=BiggerFRApiContext")
        {
        }

        public System.Data.Entity.DbSet<BiggerFRApi.Models.Referee> Referees { get; set; }

        public System.Data.Entity.DbSet<BiggerFRApi.Models.Location> Locations { get; set; }

        public System.Data.Entity.DbSet<BiggerFRApi.Models.Coach> Coaches { get; set; }

        public System.Data.Entity.DbSet<BiggerFRApi.Models.Team> Teams { get; set; }

        public System.Data.Entity.DbSet<BiggerFRApi.Models.AdministrativeBody> AdministrativeBodies { get; set; }

        public System.Data.Entity.DbSet<BiggerFRApi.Models.League> Leagues { get; set; }

        public System.Data.Entity.DbSet<BiggerFRApi.Models.LeagueSeason> LeagueSeasons { get; set; }

        public System.Data.Entity.DbSet<BiggerFRApi.Models.Season> Seasons { get; set; }

        public System.Data.Entity.DbSet<BiggerFRApi.Models.Player> Players { get; set; }

        public System.Data.Entity.DbSet<BiggerFRApi.Models.Game> Games { get; set; }

        public System.Data.Entity.DbSet<BiggerFRApi.Models.GamePlayer> GamePlayers { get; set; }

        public System.Data.Entity.DbSet<BiggerFRApi.Models.Goal> Goals { get; set; }

        public System.Data.Entity.DbSet<BiggerFRApi.Models.PenaltyType> PenaltyTypes { get; set; }

        public System.Data.Entity.DbSet<BiggerFRApi.Models.Penalty> Penalties { get; set; }

        public System.Data.Entity.DbSet<BiggerFRApi.Models.Substitution> Substitutions { get; set; }

        public System.Data.Entity.DbSet<BiggerFRApi.Models.SubstitutionGoingOff> SubstitutionGoingOffs { get; set; }

        public System.Data.Entity.DbSet<BiggerFRApi.Models.SubstitutionGoingOn> SubstitutionGoingOns { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
