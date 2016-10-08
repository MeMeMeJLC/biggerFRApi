namespace BiggerFRApi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using BiggerFRApi.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<BiggerFRApi.Models.BiggerFRApiContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "BiggerFRApi.Models.BiggerFRApiContext";
        }

        protected override void Seed(BiggerFRApi.Models.BiggerFRApiContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.AdministrativeBodies.AddOrUpdate(
                p => p.Name,
                new AdministrativeBody { Name = "FIFA" },
                new AdministrativeBody { Name = "New Zealand Football" }
                );

            context.Coaches.AddOrUpdate(
                p => p.LastName,
                new Coach { FirstName = "Bill", LastName = "Roach", TeamId = 1 },
                new Coach { FirstName = "Bobby", LastName = "Jones", TeamId = 2 }
                );

            context.Referees.AddOrUpdate(
                p => p.LastName,
                new Referee { FirstName = "Robert", LastName = "Gulman" },
                new Referee { FirstName = "John", LastName = "Xi" }
                );

            context.Locations.AddOrUpdate(
                p => p.Name,
                new Location { Name = "SBS Stadium", City = "Christchurch", Country = "New Zealand" },
                new Location { Name = "Westpac Stadium", City = "Wellington", Country = "New Zealand" }
                );

            context.Teams.AddOrUpdate(
                p => p.Name,
                new Team { Name = "Lions", LocationId = 1 },
                new Team { Name = "Tigers", LocationId = 2 }
                );

            context.Players.AddOrUpdate(
                p => p.LastName,
                new Player { FirstName = "Jeremy", LastName = "Allen", TeamId = 1 },
                new Player { FirstName = "David", LastName = "Wallis", TeamId = 1 },
                new Player { FirstName = "Jeff", LastName = "Pardo", TeamId = 1 },
                new Player { FirstName = "Hiro", LastName = "Smith", TeamId = 1 },
                new Player { FirstName = "Matt", LastName = "Fredericks", TeamId = 1 },

                new Player { FirstName = "Phil", LastName = "Cameron", TeamId = 2 },
                new Player { FirstName = "Steve", LastName = "Bell", TeamId = 2 },
                new Player { FirstName = "Jim", LastName = "Moore", TeamId = 2 },
                new Player { FirstName = "Bob", LastName = "Oldman", TeamId = 2 },
                new Player { FirstName = "William", LastName = "Goldman", TeamId = 2 }

                );

            context.Leagues.AddOrUpdate(
                p => p.Description,
                new League { Description = "New Zealand Regional", Grade = "Under 21", AdministrativeBodyId = 2 },
                new League { Description = "World Cup", Grade = "International Professional", AdministrativeBodyId = 1 }
                );

            context.LeagueSeasons.AddOrUpdate(
                p => p.LeagueId,
                new LeagueSeason { LeagueId = 1, SeasonId = 1},
                new LeagueSeason { LeagueId = 2, SeasonId = 2}
                );

           /* context.Seasons.AddOrUpdate(
                p => p.Year,
                new Season { Year = 2016, StartDate = new DateTime(2015, 12, 31), EndDate = new DateTime(2016, 4, 20) },
                new Season { Year = 2017, StartDate = new DateTime(2016, 10, 12), EndDate = new DateTime(2017, 2, 30)}
                );*/

            /*context.Games.AddOrUpdate(
                p => p.Description,
                new Game { Description = "Round 6", LocationId = 1, RefereeID = 1, GameDate = new DateTime(2016, 2, 20)},
                new Game { Description = "Round 7", LocationId = 2, RefereeID = 1, GameDate = new DateTime(2016, 2, 27)}
                );*/


        }
    }
}
