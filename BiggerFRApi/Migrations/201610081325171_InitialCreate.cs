namespace BiggerFRApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdministrativeBodies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Region = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Leagues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Grade = c.String(),
                        Region = c.String(),
                        AdministrativeBodyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AdministrativeBodies", t => t.AdministrativeBodyId)
                .Index(t => t.AdministrativeBodyId);
            
            CreateTable(
                "dbo.LeagueSeasons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LeagueId = c.Int(nullable: false),
                        SeasonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Leagues", t => t.LeagueId)
                .ForeignKey("dbo.Seasons", t => t.SeasonId)
                .Index(t => t.LeagueId)
                .Index(t => t.SeasonId);
            
            CreateTable(
                "dbo.Seasons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                        StartDate = c.Int(nullable: false),
                        EndDate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Coaches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeamId = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.TeamId)
                .Index(t => t.TeamId);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LocationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        TeamId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.TeamId)
                .Index(t => t.TeamId);
            
            CreateTable(
                "dbo.GamePlayers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlayerId = c.Int(nullable: false),
                        GameId = c.Int(nullable: false),
                        IsCaptain = c.Boolean(nullable: false),
                        IsSubstitute = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.GameId)
                .ForeignKey("dbo.Players", t => t.PlayerId)
                .Index(t => t.PlayerId)
                .Index(t => t.GameId);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        LocationId = c.Int(nullable: false),
                        RefereeID = c.Int(nullable: false),
                        GameDate = c.DateTime(nullable: false),
                        GameTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.LocationId)
                .ForeignKey("dbo.Referees", t => t.RefereeID)
                .Index(t => t.LocationId)
                .Index(t => t.RefereeID);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StreetAddress = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        GPSLatitude = c.Double(nullable: false),
                        GPSLongitude = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Referees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Goals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsOwnGoal = c.Boolean(nullable: false),
                        GamePlayerId = c.Int(nullable: false),
                        GoalTime = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GamePlayers", t => t.GamePlayerId)
                .Index(t => t.GamePlayerId);
            
            CreateTable(
                "dbo.Penalties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PenaltyTypeId = c.Int(nullable: false),
                        GamePlayerId = c.Int(nullable: false),
                        PenaltyTime = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GamePlayers", t => t.GamePlayerId)
                .ForeignKey("dbo.PenaltyTypes", t => t.PenaltyTypeId)
                .Index(t => t.PenaltyTypeId)
                .Index(t => t.GamePlayerId);
            
            CreateTable(
                "dbo.PenaltyTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubstitutionGoingOffs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GamePlayerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GamePlayers", t => t.GamePlayerId)
                .Index(t => t.GamePlayerId);
            
            CreateTable(
                "dbo.SubstitutionGoingOns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GamePlayerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GamePlayers", t => t.GamePlayerId)
                .Index(t => t.GamePlayerId);
            
            CreateTable(
                "dbo.Substitutions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubstitutionGoingOnId = c.Int(nullable: false),
                        SubstitutionGoingOffId = c.Int(nullable: false),
                        SubstitutionTime = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SubstitutionGoingOffs", t => t.SubstitutionGoingOffId)
                .ForeignKey("dbo.SubstitutionGoingOns", t => t.SubstitutionGoingOnId)
                .Index(t => t.SubstitutionGoingOnId)
                .Index(t => t.SubstitutionGoingOffId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Substitutions", "SubstitutionGoingOnId", "dbo.SubstitutionGoingOns");
            DropForeignKey("dbo.Substitutions", "SubstitutionGoingOffId", "dbo.SubstitutionGoingOffs");
            DropForeignKey("dbo.SubstitutionGoingOns", "GamePlayerId", "dbo.GamePlayers");
            DropForeignKey("dbo.SubstitutionGoingOffs", "GamePlayerId", "dbo.GamePlayers");
            DropForeignKey("dbo.Penalties", "PenaltyTypeId", "dbo.PenaltyTypes");
            DropForeignKey("dbo.Penalties", "GamePlayerId", "dbo.GamePlayers");
            DropForeignKey("dbo.Goals", "GamePlayerId", "dbo.GamePlayers");
            DropForeignKey("dbo.Coaches", "TeamId", "dbo.Teams");
            DropForeignKey("dbo.Players", "TeamId", "dbo.Teams");
            DropForeignKey("dbo.GamePlayers", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.Games", "RefereeID", "dbo.Referees");
            DropForeignKey("dbo.Games", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.GamePlayers", "GameId", "dbo.Games");
            DropForeignKey("dbo.LeagueSeasons", "SeasonId", "dbo.Seasons");
            DropForeignKey("dbo.LeagueSeasons", "LeagueId", "dbo.Leagues");
            DropForeignKey("dbo.Leagues", "AdministrativeBodyId", "dbo.AdministrativeBodies");
            DropIndex("dbo.Substitutions", new[] { "SubstitutionGoingOffId" });
            DropIndex("dbo.Substitutions", new[] { "SubstitutionGoingOnId" });
            DropIndex("dbo.SubstitutionGoingOns", new[] { "GamePlayerId" });
            DropIndex("dbo.SubstitutionGoingOffs", new[] { "GamePlayerId" });
            DropIndex("dbo.Penalties", new[] { "GamePlayerId" });
            DropIndex("dbo.Penalties", new[] { "PenaltyTypeId" });
            DropIndex("dbo.Goals", new[] { "GamePlayerId" });
            DropIndex("dbo.Games", new[] { "RefereeID" });
            DropIndex("dbo.Games", new[] { "LocationId" });
            DropIndex("dbo.GamePlayers", new[] { "GameId" });
            DropIndex("dbo.GamePlayers", new[] { "PlayerId" });
            DropIndex("dbo.Players", new[] { "TeamId" });
            DropIndex("dbo.Coaches", new[] { "TeamId" });
            DropIndex("dbo.LeagueSeasons", new[] { "SeasonId" });
            DropIndex("dbo.LeagueSeasons", new[] { "LeagueId" });
            DropIndex("dbo.Leagues", new[] { "AdministrativeBodyId" });
            DropTable("dbo.Substitutions");
            DropTable("dbo.SubstitutionGoingOns");
            DropTable("dbo.SubstitutionGoingOffs");
            DropTable("dbo.PenaltyTypes");
            DropTable("dbo.Penalties");
            DropTable("dbo.Goals");
            DropTable("dbo.Referees");
            DropTable("dbo.Locations");
            DropTable("dbo.Games");
            DropTable("dbo.GamePlayers");
            DropTable("dbo.Players");
            DropTable("dbo.Teams");
            DropTable("dbo.Coaches");
            DropTable("dbo.Seasons");
            DropTable("dbo.LeagueSeasons");
            DropTable("dbo.Leagues");
            DropTable("dbo.AdministrativeBodies");
        }
    }
}
